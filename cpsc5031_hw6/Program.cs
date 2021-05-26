using System;
using System.Collections.Generic;
using System.IO;

namespace cpsc5031_hw6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Homework 6");
            string textFile_1 = @"C:\Users\dzzn\Desktop\CPSC5031_02\week8\homework6\files\adj1.txt";
            string dotFile_1 = @"C:\Users\dzzn\Desktop\CPSC5031_02\week8\homework6\files\adj1.dot";
            var lines = ReadTextFile(textFile_1);
            foreach(var line in lines)
            {
                Console.WriteLine(line);
            }

            var dot = GenerateFile(lines, dotFile_1);
            Console.WriteLine(dot);

            Console.WriteLine("Generate image file");
            generateImage("", "");
            Console.WriteLine("done");
        }

        /// <summary>
        /// read text file
        /// </summary>
        /// <param name="path">file location</param>
        /// <returns>lines of text files</returns>
        public static string[] ReadTextFile(string path)
        {
            if(path != null)
            {
                string[] lines;
                lines = System.IO.File.ReadAllLines(path);
                return lines;
            }
            else
            {
                return null;
            }           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static char[] Letters()
        {
            char[] letters =  { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X'};
            return letters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GenerateFile(string[] lines, string path)
        {
            if(lines != null && path != null)
            {
                string lineOne = "graph adj1 {";
                string lastLine = "}";
                var nodes = Letters();
                string dot;
                dot = lineOne + "\n";
                List<string> completedNodes = new List<string>();
                for (int i = 0; i < lines.Length; i++)
                {
                    var list = lines[i].Trim().Replace(" ", string.Empty);
                    for (int j = 0; j < list.Length; j++)
                    {
                        if (list[j].Equals('1'))
                        {
                            string part1 = nodes[i] + "--" + nodes[j];
                            string part2 = nodes[j] + "--" + nodes[i];
                            if (!completedNodes.Contains(part1) && !completedNodes.Contains(part2))
                            {
                                dot = dot + nodes[i] + "--" + nodes[j] + "\n";
                                completedNodes.Add(part1);
                                completedNodes.Add(part2);
                            }
                        }
                    }
                }

                dot = dot + lastLine;
                DotFileCompose(dot, path);
                return dot;
            }
            else
            {
                return null;
            }
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="path"></param>
        private static void DotFileCompose(string text, string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using(StreamWriter writer = File.CreateText(path))
            {
                writer.Write(text);
            }
        }

        private static void generateImage(string dotFilePath, string imageFilePath)
        {
            //string commandLine;
            //commandLine = "dot -Tpng adj1.dot -o adj1.png";
            //System.Diagnostics.Process.Start("CMD.exe", commandLine);
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "dot -Tpng adj1.dot -o adj1.png";
            //process.StartInfo = startInfo;
            //process.Start();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = "CMD.exe";
            process.StartInfo.Arguments = "dot -Tpng C:\\Users\\dzzn\\Desktop\\CPSC5031_02\\week8\\homework6\files\adj1.dot -o C:\\Users\\dzzn\\Desktop\\CPSC5031_02\\week8\\homework6\files\adj1.png";
            string command = "dot -Tpng C:\\Users\\dzzn\\Desktop\\CPSC5031_02\\week8\\homework6\files\adj1.dot -o C:\\Users\\dzzn\\Desktop\\CPSC5031_02\\week8\\homework6\files\adj1.png";
            System.Diagnostics.Process.Start("CMD.exe", command);
        }
    }
}
