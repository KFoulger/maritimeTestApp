using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace maritimeTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double arithmeticMean = 0, standardDeviation = 0, dataTotal = 0, squaredDeviationTotal = 0;
            int[] frequencyTotals = new int[10];
            string csvData = File.ReadAllText("SampleData.csv");
            string[] splitData = csvData.Split(',');
            
            //Gets the sum of the data in the file and finds the frequency in bins of 10 eg/0-10, 10-20
            foreach(string data in splitData)
            {
                double parsedData = double.Parse(data);
                dataTotal += parsedData;

                if(parsedData < 10)
                {
                    frequencyTotals[0]++;
                }
                else if(parsedData < 20)
                {
                    frequencyTotals[1]++;
                }
                else if (parsedData < 30)
                {
                    frequencyTotals[2]++;
                }
                else if (parsedData < 40)
                {
                    frequencyTotals[3]++;
                }
                else if (parsedData < 50)
                {
                    frequencyTotals[4]++;
                }
                else if (parsedData < 60)
                {
                    frequencyTotals[5]++;
                }
                else if (parsedData < 70)
                {
                    frequencyTotals[6]++;
                }
                else if (parsedData < 80)
                {
                    frequencyTotals[7]++;
                }
                else if (parsedData < 90)
                {
                    frequencyTotals[8]++;
                }
                else
                {
                    frequencyTotals[9]++;
                }
            }
            arithmeticMean = dataTotal / splitData.Length;

            //Deducts the mean from each number and squares the result for calculating the standard deviation
            foreach(string data in splitData)
            {
                double parsedData = double.Parse(data);
                parsedData -= arithmeticMean;
                parsedData *= parsedData;
                squaredDeviationTotal += parsedData;
            }
            squaredDeviationTotal = squaredDeviationTotal / splitData.Length;
            standardDeviation = Math.Sqrt(squaredDeviationTotal);

            Console.WriteLine("Arithmetic Mean: " + Math.Round(arithmeticMean, 7));
            Console.WriteLine("Standard Deviation: " + Math.Round(standardDeviation, 7));
            for(int i = 0; i < frequencyTotals.Length; i++)
            {
                Console.WriteLine("Numbers between " + (i * 10) + " & " + ((i * 10) + 10) + ": " + frequencyTotals[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
