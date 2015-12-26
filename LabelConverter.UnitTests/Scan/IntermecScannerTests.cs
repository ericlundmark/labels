using System.IO;
using System.Linq;
using LabelsMain.Scan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabelConverter.UnitTests.Scan
{
    [TestClass]
    [DeploymentItem(@"Scan\TestFiles")]
    public class IntermecScannerTests
    {
        [TestMethod]
        public void ParseTestLabel_ShouldRemoveNewline()
        {
            var parser = new IntermecScanner();
            var label = File.ReadAllText("IntermecLabel.txt");
            var tokens = parser.Scan(label);
            var newline = tokens.Any(t => t.Command.Contains("\n") || t.Command.Contains("\r"));
            Assert.IsFalse(newline);
        }

        [TestMethod]
        public void ParseTestLabel_ShouldRemoveTab()
        {
            var parser = new IntermecScanner();
            var label = File.ReadAllText("IntermecLabel.txt");
            var tokens = parser.Scan(label);
            var tab = tokens.Any(t => t.Command.Contains("\t"));
            Assert.IsFalse(tab);
        }

        [TestMethod]
        public void Parse_OneCommandWithTwoParams_OneToken()
        {
            var parser = new IntermecScanner();
            var tokens = parser.Scan(@"<STX>H0;o35,40;c25;<ETX>");
            Assert.AreEqual(1, tokens.Count());
        }

        [TestMethod]
        public void Parse_OneCommandWithTwoParams_TwoParams()
        {
            var parser = new IntermecScanner();
            var tokens = parser.Scan(@"<STX>H0;o35,40;c25;<ETX>");
            Assert.AreEqual(2, tokens.First().Parameters.Count());
        }

        [TestMethod]
        public void Parse_OneCommandWithTwoParams_CommandExtracted()
        {
            var parser = new IntermecScanner();
            var tokens = parser.Scan(@"<STX>H0;o35,40;c25;<ETX>");
            Assert.AreEqual("H0", tokens.First().Command);
        }

        [TestMethod]
        public void Parse_OneCommandWithTwoParams_ParamsExtracted()
        {
            var parser = new IntermecScanner();
            var tokens = parser.Scan(@"<STX>H0;o35,40;c25;<ETX>");
            var token = tokens.First();
            Assert.AreEqual("o35,40", token.Parameters[0]);
            Assert.AreEqual("c25", token.Parameters[1]);
        }
    }
}
