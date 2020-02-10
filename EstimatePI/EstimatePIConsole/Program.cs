using EstimatePI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace EstimatePIConsole
{
    class Program
    {

        #region Variables
        #endregion Variables

        static void Main(string[] args)
        {
            string PathToDir = @"C:\EstimatePI\";
            string SecurityCode = "123456789";

            if (args.Length != 2)
            {
                Console.WriteLine("How to use the app");
                Console.WriteLine("------------------");
                Console.WriteLine("Ex: EstimatePIConsole 100000000 100");
                Console.WriteLine("");
                Console.WriteLine("EstimatePIConsole DartCount Parts");
                Console.WriteLine("");
                Console.WriteLine("Args");
                Console.WriteLine("DartCount --- should be an int representing the number of Darts to throw");
                Console.WriteLine("      value should be between 1 and 1000000000 and bigger than Parts");
                Console.WriteLine("Parts --- should be an int representing the number of parts to subdivide the DartCount");
                Console.WriteLine("      value should be between 1 and 100 and smaller than DartCount");
                Console.WriteLine("");
                Console.WriteLine($@"The output will be automatically created under the C:\EstimatePI\EstimatedPIResults.csv");
            }
            else
            {
                int DartCount = int.Parse(args[0]);
                if (DartCount < 1 || DartCount > 1000000000)
                {
                    Console.WriteLine(@"Sorry: first arg ""DartCount"" should be between 1 and 1000000000");
                    return;
                }

                int Parts = int.Parse(args[1]);
                if (Parts < 1 || Parts > 100)
                {
                    Console.WriteLine(@"Sorry: second arg ""Parts"" should be between 1 and 100");
                    return;
                }

                if (Parts > DartCount)
                {
                    Console.WriteLine(@"Sorry: second arg ""Parts"" should be bigger than first arg ""DartCount""");
                    return;
                }

                string retStr = RunAllEstimatePIParts(DartCount, Parts, PathToDir, SecurityCode);

                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    Console.WriteLine(@"Sorry: an error occured during the execution of the app");
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

                    Console.WriteLine($"Count [{estimatedPIResult.Count}] In Circle [{estimatedPIResult.InCircle}] Estimated PI [{estimatedPIResult.EstimatedPI.ToString("F8")}] In Seconds [{estimatedPIResult.Seconds}]");
                    Console.WriteLine("");
                    Console.WriteLine("Done...");
                }
            }
        }

        #region Private Functions
        private static string RunAllEstimatePIParts(int DartCount, int Parts, string PathToDir, string SecurityCode)
        {
            DateTime StartTime = DateTime.Now;

            List<Process> processList = new List<Process>();

            int DartsPerFile = DartCount / Parts;

            for (int i = 1; i < Parts + 1; i++)
            {
                string args = $" {SecurityCode} {DartsPerFile} {i}";
                Process process = new Process();
                process = Process.Start($@"C:\B\EstimatePI\EstimatePIPartConsole\bin\Debug\netcoreapp3.1\EstimatePIPartConsole.exe", args);

                processList.Add(process);
            }

            int processStillRunning = processList.Where(c => c.HasExited == false).Count();

            while (processStillRunning > 0)
            {
                processStillRunning = processList.Where(c => c.HasExited == false).Count();
            }

            DirectoryInfo di = new DirectoryInfo(PathToDir);

            if (!di.Exists)
            {
                return $@"Could not find directory [{di.FullName}]";
            }

            List<FileInfo> fiList = di.GetFiles().Where(c => c.Name.StartsWith("EstimatePIResult_")).ToList();

            EstimatedPIResult estimatedPIResultFinal = new EstimatedPIResult();

            foreach (FileInfo fi in fiList)
            {
                string FirstLine = $"Count,InCircle,PI,Seconds";
                StreamReader sr = fi.OpenText();
                string FirstLineRead = sr.ReadLine();
                if (FirstLineRead != FirstLine)
                {
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

            StreamWriter sw = fiResult.CreateText();
            sw.WriteLine($"Count,InCircle,PI,Seconds");
            sw.WriteLine($"{estimatedPIResultFinal.Count},{estimatedPIResultFinal.InCircle},{estimatedPIResultFinal.EstimatedPI.ToString("F8")},{timeSpan.Seconds}");
            sw.Close();

            return "";
        }

        #endregion Private Functions
    }
}
