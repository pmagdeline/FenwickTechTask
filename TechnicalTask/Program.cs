using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TechnicalTask
{
    class Program
    {
        //Assign the path where the text file has to be created
        public static string filePath = @"C:\\TechnicalTask.txt";
        static void Main(string[] args)
        {
            try
            {

                int[] commands = { 1, 2, 3 };
                Console.WriteLine("Enter" + "\n" + " 1 for Help " + "\n" + " 2 for Record " + "\n" + " 3 for Summary ");
                int command = Int32.Parse(Console.ReadLine());
                Boolean quitNow = false;
                while (!quitNow)
                {
                    switch (command)
                    {
                        case 1:
                            DisplayHelp();
                            return;
                        case 2:
                            Console.WriteLine("For record command, needs to give record size and numeric values");
                            RecordDataToFile(filePath);
                            ReadDataFromFile(filePath);
                            return;
                        case 3:
                            Console.WriteLine("Summary command summarizes the information recorded using Record command");
                            DisplayFileSummary(filePath);
                            return;
                        default:
                            Console.WriteLine("The selection has to be between 1 and 3. Please re-enter");
                            return;
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);

            }
            finally
            {
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }

        }
        static void RecordDataToFile(string fpath)
        {
            try
            {
                //Variable to assign the record size of the file
                int recordSize = 0;
                Console.Write("Enter Record size : ");
                recordSize = Int32.Parse(Console.ReadLine());
                //Array to store the numerical values
                float[] x = new float[recordSize];
                Console.Write("Record " + recordSize + " numerical values: ");
                //Reading data to the float srray
                for (int i = 0; i < recordSize; i++)
                {
                    x[i] = float.Parse(Console.ReadLine());
                }
                //Pass the file path and file name to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(filePath, true);
                for (int i = 0; i < x.Length; i++)
                {
                    sw.WriteLine(x[i]);
                }
                //Clear the buffer
                sw.Flush();
                //Close the file
                sw.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }
        static void ReadDataFromFile(string fpath)
        {
            try
            {
                // Open the file to read from.
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string s = "";
                    Console.WriteLine("------------------------------------------------");
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] lines = File.ReadAllLines(filePath);
                        Console.WriteLine(">> TechnicalTask.exe record numeric value >> " + s);

                    }

                }
                Console.WriteLine("------------------------------------------------");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("[Text File Missing] {0}", e);
                throw new FileNotFoundException(@"[Technicaltask.txt not in c:\ directory]", e);
            }


        }
        public static void DisplayHelp()
        {
            try
            {
                Console.WriteLine(File.ReadAllText(@"C:\\Help.txt"));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("[Text File Missing] {0}", e);
                throw new FileNotFoundException(@"[Help.txt not in c:\ directory]", e);
            }

        }
        static void DisplayFileSummary(string fpath)
        {
            try
            {
                //Declare variables to store maximum, minimum, total and average values
                float max = 0;
                float min = 999999;
                float score = 0;
                int count;
                float totalVal = 0;
                float avgVal = 0;
                // Open the file to read from.
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string s = "";
                    count = 0;
                    Console.WriteLine("\r\n\tTechnicalTask.txt Summary\r\n");
                    Console.WriteLine("-----------------------------------------");
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] lines = File.ReadAllLines(filePath);
                        count++;
                        totalVal = 0;
                        foreach (string line in lines)
                        {
                            if (float.TryParse(line, out score))
                            {
                                if (score > max)
                                    max = score;
                                if (score < min)
                                    min = score;
                            }
                            totalVal += float.Parse(line);

                        }

                    }
                    avgVal = (totalVal / count);
                    Console.WriteLine("|" + "\t" + "# of items" + "\t" + "|" + "\t" + count + "\t" + "|");
                    Console.WriteLine("|" + "\t" + "Min value" + "\t" + "|" + "\t" + min + "\t" + "|");
                    Console.WriteLine("|" + "\t" + "Max value" + "\t" + "|" + "\t" + max + "\t" + "|");
                    Console.WriteLine("|" + "\t" + "Average value" + "\t" + "|" + "\t" + avgVal.ToString("0.00") + "\t" + "|");
                    Console.WriteLine("-----------------------------------------");
                }


            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("[Text File Missing] {0}", e);
                throw new FileNotFoundException(@"[TechnicalTask.txt not in c:\ directory]", e);
            }


        }


    }
}
