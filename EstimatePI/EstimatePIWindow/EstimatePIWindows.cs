using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EstimatePI;

namespace EstimatePIWindow
{
    public partial class EstimatePIWindows : Form
    {
        #region Properties
        public string PathToDir { get; set; } = @"C:\EstimatePI\";
        public string ResultFileName { get; set; } = @"";
        #endregion Properties

        #region Constructors
        public EstimatePIWindows()
        {
            InitializeComponent();
        }
        #endregion Constructors

        #region Events
        private void butStartEstimatingPI_Click(object sender, EventArgs e)
        {
            int DartCount = int.Parse(textBoxNumberOfDarts.Text);
            int Parts = int.Parse(textBoxParts.Text);
            string SecurityCode = "123456789";

            if (DartCount < 1 || DartCount > 1000000000)
            {
                richTextBoxStatus.AppendText(@"Sorry: first arg ""DartCount"" should be between 1 and 1000000000\r\n");
                return;
            }

            if (Parts < 1 || Parts > 100)
            {
                richTextBoxStatus.AppendText(@"Sorry: second arg ""Parts"" should be between 1 and 100\r\n");
                return;
            }

            if (Parts > DartCount)
            {
                richTextBoxStatus.AppendText(@"Sorry: second arg ""Parts"" should be bigger than first arg ""DartCount""\r\n");
                return;
            }

            string retStr = RunAllEstimatePIParts(DartCount, Parts, PathToDir, SecurityCode);

            if (!string.IsNullOrWhiteSpace(retStr))
            {
                richTextBoxStatus.AppendText(@"Sorry: an error occured during the execution of the app\r\n");
                return;
            }
            else
            {
                FileInfo fiResult = new FileInfo($@"{PathToDir}EstimatedPIResults.csv");

                if (!fiResult.Exists)
                {
                    Console.WriteLine($"Could not find file [{fiResult.FullName}]");
                    return;
                }

                string FirstLine = $"Count,InCircle,PI,Seconds";
                StreamReader sr = fiResult.OpenText();
                string FirstLineRead = sr.ReadLine();
                if (FirstLineRead != FirstLine)
                {
                    Console.WriteLine($"First line of file [{fiResult.FullName}] is not equal to [{FirstLine}]");
                }
                string SecondLineRead = sr.ReadLine();
                List<string> SecondLineValueTextList = SecondLineRead.Split(",".ToCharArray(), StringSplitOptions.None).ToList();
                // second line should contain the values of Count,InCircle,PI,Seconds
                if (SecondLineValueTextList.Count != 4)
                {
                    sr.Close();
                    Console.WriteLine($"Second line of file [{fiResult.FullName}] does not have 4 items. It has [{SecondLineRead}]");
                }

                sr.Close();

                EstimatedPIResult estimatedPIResult = new EstimatedPIResult();

                estimatedPIResult.Count = int.Parse(SecondLineValueTextList[0]);
                estimatedPIResult.InCircle = int.Parse(SecondLineValueTextList[1]);
                estimatedPIResult.EstimatedPI = double.Parse(SecondLineValueTextList[2]);
                estimatedPIResult.Seconds = int.Parse(SecondLineValueTextList[3]);

                richTextBoxStatus.AppendText($"Count [{estimatedPIResult.Count}] In Circle [{estimatedPIResult.InCircle}] Estimated PI [{estimatedPIResult.EstimatedPI.ToString("F8")}] In Seconds [{estimatedPIResult.Seconds}]\r\n");
                richTextBoxStatus.AppendText("\r\n");
                richTextBoxStatus.AppendText("Done...\r\n");
            }
        }
        #endregion Events

        #region Private Functions
        private string RunAllEstimatePIParts(int DartCount, int Parts, string PathToDir, string SecurityCode)
        {
            DateTime StartTime = DateTime.Now;

            List<Process> processList = new List<Process>();

            int DartsPerFile = DartCount / Parts;

            for (int i = 1; i < Parts + 1; i++)
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.Arguments = $" {SecurityCode} {DartsPerFile} {i}";
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processStartInfo.FileName = $@"C:\B\EstimatePI\EstimatePIPartConsole\bin\Debug\netcoreapp3.1\EstimatePIPartConsole.exe";
                processStartInfo.CreateNoWindow = true;

                Process process = new Process();
                process = Process.Start(processStartInfo);

                processList.Add(process);

                lblStatus.Text = $"Process count [{i}]";
                lblStatus.Refresh();
                Application.DoEvents();
            }

            int processStillRunning = processList.Where(c => c.HasExited == false).Count();

            while (processStillRunning > 0)
            {
                processStillRunning = processList.Where(c => c.HasExited == false).Count();

                lblStatus.Text = $"Process count [{processStillRunning}]";
                lblStatus.Refresh();
                Application.DoEvents();
            }

            DirectoryInfo di = new DirectoryInfo(PathToDir);

            if (!di.Exists)
            {
                return $@"Could not find director [{di.FullName}]";
            }

            List<FileInfo> fiList = di.GetFiles().Where(c => c.Name.StartsWith("EstimatePIResult_")).ToList();

            EstimatedPIResult estimatedPIResultFinal = new EstimatedPIResult();

            foreach (FileInfo fi in fiList)
            {
                lblStatus.Text = $"Reading temp files [{fi.FullName}]";
                lblStatus.Refresh();
                Application.DoEvents();

                string FirstLine = $"Count,InCircle,PI,Seconds";
                StreamReader sr = fi.OpenText();
                string FirstLineRead = sr.ReadLine();
                if (FirstLineRead != FirstLine)
                {
                    sr.Close();
                    return $"First line of file [{fi.FullName}] is not equal to [{FirstLine}]";
                }
                string SecondLineRead = sr.ReadLine();
                List<string> SecondLineValueTextList = SecondLineRead.Split(",".ToCharArray(), StringSplitOptions.None).ToList();
                // second line should contain the values of Count,InCircle,PI,Seconds
                if (SecondLineValueTextList.Count != 4)
                {
                    sr.Close();
                    return $"Second line of file [{fi.FullName}] does not have 4 items. It has [{SecondLineRead}]";
                }

                sr.Close();

                int Count = int.Parse(SecondLineValueTextList[0]);
                int InCircle = int.Parse(SecondLineValueTextList[1]);

                estimatedPIResultFinal.Count += Count;
                estimatedPIResultFinal.InCircle += InCircle;
            }

            foreach (FileInfo fi in fiList)
            {
                try
                {
                    lblStatus.Text = $"Deleting temp files [{fi.FullName}]";
                    lblStatus.Refresh();
                    Application.DoEvents();
                    fi.Delete();
                }
                catch (Exception ex)
                {
                    return $"Error while trying to delete [{fi.FullName}]";
                }
            }

            estimatedPIResultFinal.EstimatedPI = 4.0D * (double)estimatedPIResultFinal.InCircle / (double)estimatedPIResultFinal.Count;


            FileInfo fiResult = new FileInfo($@"{PathToDir}EstimatedPIResults.csv");

            DateTime EndTime = DateTime.Now;

            TimeSpan timeSpan = new TimeSpan(EndTime.Ticks - StartTime.Ticks);

            lblStatus.Text = $"Creating result file [{fiResult.FullName}]";
            lblStatus.Refresh();
            Application.DoEvents();

            StreamWriter sw = fiResult.CreateText();
            sw.WriteLine($"Count,InCircle,PI,Seconds");
            sw.WriteLine($"{estimatedPIResultFinal.Count},{estimatedPIResultFinal.InCircle},{estimatedPIResultFinal.EstimatedPI.ToString("F8")},{timeSpan.Seconds}");
            sw.Close();

            lblStatus.Text = $"Done...";
            lblStatus.Refresh();
            Application.DoEvents();

            return "";
        }
        #endregion Private Functions
    }
}
