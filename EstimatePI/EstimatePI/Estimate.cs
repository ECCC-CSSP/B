using System;
using System.IO;

namespace EstimatePI
{
    public class Estimate
    {
        #region Variables
        #endregion Variables

        #region Properties
        public string TempDirPath { get; set; } = @"C:\EstimatePI\";
        public string ResultFileName { get; set; } = @"";
        public int DartCount { get; set; } = 1000;
        #endregion Properties

        #region Constructors
        public void EstimatePI(int dartCount, int fileCount)
        {
            DateTime StartTime = DateTime.Now;
            
            DartCount = dartCount;
            ResultFileName = $"EstimatePIResult_{fileCount}.csv";
            
            // will stop if error during setup
            if (!string.IsNullOrWhiteSpace(Setup()))
            {
                return;
            }
            
            // everything ok in the setup, continue
            EstimatedPIResult estimatedPIResult = DoEstimate();

            DateTime EndTime = DateTime.Now;

            FileInfo fi = new FileInfo($"{TempDirPath}{ResultFileName}");

            TimeSpan timeSpan = new TimeSpan(EndTime.Ticks - StartTime.Ticks);

            StreamWriter sw = fi.CreateText();
            sw.WriteLine($"Count,InCircle,PI,Seconds");
            sw.WriteLine($"{estimatedPIResult.Count},{estimatedPIResult.InCircle},{estimatedPIResult.EstimatedPI},{timeSpan.Seconds}");
            sw.Close();
        }
        #endregion Constructors

        #region Events
        public virtual void ErrorEvent(ErrorEventArgs e)
        {
            ErrorHandler?.Invoke(this, e);
        }
        public event EventHandler<ErrorEventArgs> ErrorHandler;
        public virtual void StatusTempEvent(StatusEventArgs e)
        {
            StatusTempHandler?.Invoke(this, e);
        }
        public event EventHandler<StatusEventArgs> StatusTempHandler;
        public virtual void StatusPermanentEvent(StatusEventArgs e)
        {
            StatusPermanentHandler?.Invoke(this, e);
        }
        public event EventHandler<StatusEventArgs> StatusPermanentHandler;
        public virtual void ClearPermanentEvent(StatusEventArgs e)
        {
            ClearPermanentHandler?.Invoke(this, e);
        }
        public event EventHandler<StatusEventArgs> ClearPermanentHandler;
        #endregion Events

        #region Public Functions
        #endregion Public Functions

        #region Private Functions
        private string ClearDirectory()
        {
            StatusTempEvent(new StatusEventArgs($"Clearing up directory [{TempDirPath}]"));

            DirectoryInfo di = new DirectoryInfo(TempDirPath);

            if (!di.Exists)
            {
                try
                {
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                }
                catch (Exception ex)
                {
                    ErrorEvent(new ErrorEventArgs(ex.Message));
                    return ex.Message;
                }
            }

            return ""; // everything ok, return empty string otherwise return error message
        }
        private EstimatedPIResult DoEstimate()
        {
            EstimatedPIResult estimatedPIResult = new EstimatedPIResult();

            Random r = new Random();

            int Count = 0;
            int InCircle = 0;

            for (int i = 0; i < DartCount; i++)
            {
                double x = r.NextDouble();
                double y = r.NextDouble();

                if (IsInCircle(x, y))
                {
                    InCircle++;
                }

                Count++;
            }

            estimatedPIResult.Count = Count;
            estimatedPIResult.InCircle = InCircle;
            estimatedPIResult.EstimatedPI = 4.0D * (double)InCircle / (double)Count;

            return estimatedPIResult;
        }
        private bool IsInCircle(double x, double y)
        {
            double dist = Math.Sqrt(x * x + y * y);
            if (dist > 1.0D)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private string Setup()
        {
            string retStr = SetupDirectory();

            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = ClearDirectory();

            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return ""; // everything ok, return empty string otherwise return error message
        }
        private string SetupDirectory()
        {
            StatusTempEvent(new StatusEventArgs($"Setting up directory [{TempDirPath}]"));

            DirectoryInfo di = new DirectoryInfo(TempDirPath);

            if (!di.Exists)
            {
                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    ErrorEvent(new ErrorEventArgs(ex.Message));
                    return ex.Message;
                }
            }

            return ""; // everything ok, return empty string otherwise return error message
        }
        #endregion Private Functions
    }

    #region Sub Classes
    public class EstimatedPIResult
    {
        public int Count { get; set; }
        public int InCircle { get; set; }
        public double EstimatedPI { get; set; }
        public int Seconds { get; set; }
    }
    public class ErrorEventArgs : EventArgs
    {
        public ErrorEventArgs(string Error)
        {
            this.Error = Error;
        }

        public string Error { get; set; }
    }
    public class StatusEventArgs : EventArgs
    {
        public StatusEventArgs(string Status)
        {
            this.Status = Status;
        }

        public string Status { get; set; }
    }
    #endregion Sub Classes
}
