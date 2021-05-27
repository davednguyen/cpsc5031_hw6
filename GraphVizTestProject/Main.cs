using Microsoft.VisualStudio.TestTools.UnitTesting;
using cpsc5031_hw6;

namespace GraphVizTestProject
{
    [TestClass]
    public class Main
    {
        //set initial directory for testing
        string directory = @"C:\Users\mr4eyesn\Desktop\CPSC5031_2\week8\homework\code\cpsc5031_hw6\files\";

        [TestMethod]
        public void TestCase_4by4Matrix_1_HappyPath()
        {
            Program graph = new Program();
            
            var check = graph.GraphVizGeneratorV2("adj1.txt", "adj1.png", "adj1.dot", directory);
            //GraphVizGenerator("adj2.txt", "adj2.png", "adj2.dot", directory);
            //GraphVizGenerator("adj3.txt", "adj3.png", "adj3.dot", directory);
            //GraphVizGenerator("adj4.txt", "adj4.png", "adj4.dot", directory);
            Assert.AreEqual(true, check);
        }
    }
}
