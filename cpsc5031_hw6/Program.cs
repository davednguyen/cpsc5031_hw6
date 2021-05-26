using System;

namespace cpsc5031_hw6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Homework 6");
            var lines = ReadTextFile(@"C:\Users\dzzn\Desktop\CPSC5031_02\week8\homework6\files\adj1.txt");
            foreach(var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        /// <summary>
        /// read text file
        /// </summary>
        /// <param name="path">file location</param>
        /// <returns>lines of text files</returns>
        public static string[] ReadTextFile(string path)
        {
            string[] lines;
            lines = System.IO.File.ReadAllLines(path);
            return lines;
        }
    }
}
