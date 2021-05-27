using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string directory = @"C:\Users\dzzn\Desktop\CPSC5031_02\week8\homework6\files\";
            var lines = readTextFile(textFile_1);
            foreach(var line in lines)
            {
                Console.WriteLine(line);
            }

            var dot = generateDotFileBody(lines);
            Console.WriteLine(dot);

            Console.WriteLine("Generate image file");
            generateImage("adj1.dot", "adj1.png", directory);
            Console.WriteLine("done");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textFileName"></param>
        /// <param name="imageFileName"></param>
        /// <param name="dotFileName"></param>
        /// <param name="directory"></param>
        public bool GraphVizGenerator(string textFileName, string imageFileName, string dotFileName, string directory)
        {
            //null check for all required inputs
            if(textFileName != null || imageFileName != null || dotFileName != null || directory != null)
            {
                //check to make sure user don't provide empty string for any inputs
                if(textFileName.Equals(string.Empty) || imageFileName.Equals(string.Empty) || dotFileName.Equals(string.Empty) || directory.Equals(string.Empty))
                {
                    var lines = readTextFile(directory + textFileName);
                    var dotFileBody = generateDotFileBody(lines);
                    var dotFilePath = directory + dotFileName;
                    var dotFile = dotFileCompose(dotFileBody, dotFilePath);
                    generateImage(dotFile, imageFileName, directory);
                    return true;
                }
                else
                {
                    return false;
                }                
            }
            else
            {
                return false;
            }            
        }

        /// <summary>
        /// read text file
        /// </summary>
        /// <param name="path">file location</param>
        /// <returns>lines of text files</returns>
        private static string[] readTextFile(string path)
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
        /// List of pre-populated Node name for a graph
        /// assuming the maximum nodes for a graph is 24
        /// </summary>
        /// <returns>list of node names</returns>
        private static char[] Letters()
        {
            char[] letters =  { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X'};
            return letters;
        }

        /// <summary>
        /// Take array of string and generate a file body for a dot file
        /// list of connect between nodes within a graph
        /// </summary>
        /// <param name="lines">list of lines between two nodes</param>
        /// <returns>string body for a dot file</returns>
        private static string generateDotFileBody(string[] lines)
        {
            if(lines != null)
            {
                string lineOne = "graph adj1 {";
                string lastLine = "}";
                //assign name for each node in the graph
                var nodes = Letters();
                string dotFileoBody;
                dotFileoBody = lineOne + "\n";
                //to keep track of all the nodes
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
                                dotFileoBody = dotFileoBody + nodes[i] + "--" + nodes[j] + "\n";
                                completedNodes.Add(part1);
                                completedNodes.Add(part2);
                            }
                        }
                    }
                }
                dotFileoBody = dotFileoBody + lastLine;
                return dotFileoBody;
            }
            else
            {
                return null;
            }           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringbody">Dot file string body</param>
        /// <param name="path">location and file name for the dot file</param>
        private static string dotFileCompose(string stringbody, string path)
        {
            //delete the file if it already exsited in the foler
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            //write text into dot file
            using(StreamWriter writer = File.CreateText(path))
            {
                writer.Write(stringbody);
            }
            return path;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dotFilePath"></param>
        /// <param name="imageFilePath"></param>
        /// <param name="directory"></param>
        private static void generateImage(string dotFile, string imageFile, string directory)
        {
            string commandTemplate = "dot -Tpng {0} -o {1}";
            string application = "cmd.exe";
            string command = String.Format(commandTemplate, dotFile, imageFile);
            using(Process process = new Process())
            {
                process.StartInfo = new ProcessStartInfo(application)
                {
                    RedirectStandardInput = true,
                    UseShellExecute = false,                    
                    WorkingDirectory = directory
                };
                process.Start();
                process.StandardInput.WriteLine(command);
                process.WaitForExit();
            }
        }
    }
}
