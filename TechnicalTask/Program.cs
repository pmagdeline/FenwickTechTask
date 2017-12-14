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
                //Function to record data to the text file
                RecordDataToFile(filePath);
                //Function to read data from the text file
                ReadDataFromFile(filePath);
                //Function to display the summary of the text file
                DisplayFileSummary(filePath);

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
            //Variable to assign the record size of the file
            int recordSize = 0;
            Console.Write("Enter Record size: ");
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
        static void ReadDataFromFile(string fpath)
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
        static void DisplayFileSummary(string fpath)
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
                avgVal = totalVal / count;
                Console.WriteLine("|" + "\t" + "# of items" + "\t" + "|" + "\t" + count + "\t" + "|");
                Console.WriteLine("|" + "\t" + "Min value" + "\t" + "|" + "\t" + min + "\t" + "|");
                Console.WriteLine("|" + "\t" + "Max value" + "\t" + "|" + "\t" + max + "\t" + "|");
                Console.WriteLine("|" + "\t" + "Average value" + "\t" + "|" + "\t" + avgVal + "\t" + "|");
                Console.WriteLine("-----------------------------------------");

            }
        }


        }
    }
