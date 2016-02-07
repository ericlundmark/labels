using System.IO;
using System.Linq;
using LabelsMain.Scan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabelConverter.UnitTests.Scan
{
    [TestClass]
    [DeploymentItem(@"Scan\TestFiles")]
    public class ZebraScannerTests
    {
        [TestMethod]
        public void ParseTestLabel_ShouldParseCommands()
        {
            var parser = new ZebraScanner();
            var label = File.ReadAllText("TestLabel.txt");
            var tokens = parser.Scan(label);
        }

        [TestMethod]
        public void Parse_OneCommandWithTwoParams_OneToken()
        {
            var parser = new ZebraScanner();
            var tokens = parser.Scan(@"^AAarg1,arg2");
            Assert.AreEqual(1, tokens.Count());
        }

        [TestMethod]
        public void Parse_OneCommandWithTwoParams_TwoParams()
        {
            var parser = new ZebraScanner();
            var tokens = parser.Scan(@"^AAarg1,arg2");
            Assert.AreEqual(2, tokens.First().Parameters.Count());
        }

        [TestMethod]
        public void Parse_OneCommandWithTwoParams_CommandExtracted()
        {
            var parser = new ZebraScanner();
            var tokens = parser.Scan(@"^AAarg1,arg2");
            Assert.AreEqual("AA", tokens.First().Command);
        }

        [TestMethod]
        public void Parse_OneCommandWithTwoParams_ParamsExtracted()
        {
            var parser = new ZebraScanner();
            var tokens = parser.Scan(@"^AAarg1,arg2");
            var token = tokens.First();
            Assert.AreEqual("arg1", token.Parameters[0]);
            Assert.AreEqual("arg2", token.Parameters[1]);
        }

        [TestMethod]
        public void Parse_Tilde_ExtractedAsCommand()
        {
            var parser = new ZebraScanner();
            var tokens = parser.Scan(@"~JR");
            var token = tokens.First();
            Assert.AreEqual("JR", token.Command);
        }
    }
}