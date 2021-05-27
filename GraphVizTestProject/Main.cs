using Microsoft.VisualStudio.TestTools.UnitTesting;
using cpsc5031_hw6;

namespace GraphVizTestProject
{
    [TestClass]
    public class Main
    {
        //set initial directory for testing
        //string directory = @"C:\Users\mr4eyesn\Desktop\CPSC5031_2\week8\homework\code\cpsc5031_hw6\files\";
        string directory = @"C:\Users\dzzn\Desktop\CPSC5031_02\week8\homework6\files\";
        [TestMethod]
        public void TestCase_4by4Matrix_1_HappyPath_Graph()
        {
            Program graph = new Program();
            var check = graph.GraphVizGeneratorV2("adj1.txt", "adj1.png", "adj1.dot", directory, false); 
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void TestCase_4by4Matrix_2_HappyPath_Graph()
        {
            Program graph = new Program();
            var check = graph.GraphVizGeneratorV2("adj2.txt", "adj2.png", "adj2.dot", directory, false);
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void TestCase_5by5Matrix_1_HappyPath_Graph()
        {
            Program graph = new Program();
            var check = graph.GraphVizGeneratorV2("adj3.txt", "adj3.png", "adj3.dot", directory, false);
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void TestCase_6by6Matrix_1_HappyPath_Graph()
        {
            Program graph = new Program();
            var check = graph.GraphVizGeneratorV2("adj4.txt", "adj4.png", "adj4.dot", directory, false);
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void TestCase_4by4Matrix_1_HappyPath_Digraph()
        {
            Program graph = new Program();
            var check = graph.GraphVizGeneratorV2("adj1.txt", "adj5.png", "adj5.dot", directory, true);
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void TestCase_4by4Matrix_2_HappyPath_Digraph()
        {
            Program graph = new Program();
            var check = graph.GraphVizGeneratorV2("adj2.txt", "adj6.png", "adj6.dot", directory, true);
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void TestCase_5by5Matrix_1_HappyPath_Digraph()
        {
            Program graph = new Program();
            var check = graph.GraphVizGeneratorV2("adj3.txt", "adj7.png", "adj7.dot", directory, true);
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void TestCase_6by6Matrix_1_HappyPath_Digraph()
        {
            Program graph = new Program();
            var check = graph.GraphVizGeneratorV2("adj4.txt", "adj8.png", "adj8.dot", directory, true);
            Assert.AreEqual(true, check);
        }
    }
}
