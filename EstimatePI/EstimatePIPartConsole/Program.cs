using EstimatePI;
using System;
using System.IO;

namespace EstimatePIPartConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string SecurityCode = "123456789";

            if (args.Length != 3)
            {
                Console.WriteLine("How to use the app");
                Console.WriteLine("------------------");
                Console.WriteLine("Ex: EstimatePIPartConsole 123456789 100000 1");
                Console.WriteLine("");
                Console.WriteLine("EstimatePIPartConsole SecurityCode NumberOfDarts FileNumber");
                Console.WriteLine("");
                Console.WriteLine("Args");
                Console.WriteLine("SecurityCode --- should be 123456789");
                Console.WriteLine("NumberOfDarts --- should be an int representing the number of Darts to throw");
                Console.WriteLine("      value should be between 1 and 1000000000");
                Console.WriteLine("FileNumber --- should be an int used to create a unique file and should be between 1 and 10000");
                Console.WriteLine("");
                Console.WriteLine(@"The output will be automatically created under the C:\EstimatePI\EstimatePIResult_{FileNumber}.csv where FileNumber is replaced by the pass arg FileNumber");
            }
            else
            {
                string SecurityCodePassed = args[0].ToString();
                if (SecurityCodePassed != SecurityCode)
                {
                    Console.WriteLine($@"Sorry: first arg ""SecurityCode"" needs to be [{SecurityCode}]");
                    return;
                }

                int NumberOfDarts = int.Parse(args[1]);
                if (NumberOfDarts < 1 || NumberOfDarts > 1000000000)
                {
                    Console.WriteLine(@"Sorry: second arg ""NumberOfDarts"" should be between 1 and 1000000000");
                    return;
                }

                int FileNumber = int.Parse(args[2]);
                if (FileNumber < 1 || FileNumber > 10000)
                {
                    Console.WriteLine(@"Sorry: third arg ""FileNumber"" should be between 1 and 10000");
                    return;
                }

                Estimate estimate = new Estimate();

                estimate.EstimatePI(NumberOfDarts, FileNumber);

                // should close itself when running from process
            }
        }
    }
}
