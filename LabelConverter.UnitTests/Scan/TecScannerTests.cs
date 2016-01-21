using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabelsMain.Scan;

namespace LabelConverter.UnitTests.Scan
{
    [TestClass]
    public class TecScannerTests
    {
        [TestMethod]
        public void ParseTestLabel_ShouldRemoveNewline()
        {
            var parser = new TecScanner();
            var label = File.ReadAllText("TecLabel.txt");
            var tokens = parser.Scan(label);
            var newline = tokens.Any(t => t.Command.Contains("\n") || t.Command.Contains("\r"));
            Assert.IsFalse(newline);
        }

        [TestMethod]
        public void ParseTestLabel_ShouldRemoveTab()
        {
            var parser = new TecScanner();
            var label = File.ReadAllText("TecLabel.txt");
            var tokens = parser.Scan(label);
            var tab = tokens.Any(t => t.Command.Contains("\t"));
            Assert.IsFalse(tab);
        }

        [TestMethod]
        public void Parse_OneCommandWithTwoParams_OneToken()
        {
            var parser = new IntermecScanner();
            var tokens = parser.Scan(@"[ESC] XR; aaaa, bbbb [LF] [NUL] ");
            Assert.AreEqual(1, tokens.Count());
        }

        [TestMethod]
        public void Parse_OneCommandWithTwoParams_TwoParams()
        {
            var parser = new IntermecScanner();
            var tokens = parser.Scan(@"[ESC] XR; aaaa, bbbb [LF] [NUL] ");
            Assert.AreEqual(2, tokens.First().Parameters.Count());
        }

        [TestMethod]
        public void Parse_OneCommandWithTwoParams_CommandExtracted()
        {
            var parser = new IntermecScanner();
            var tokens = parser.Scan(@"[ESC] XR; aaaa, bbbb [LF] [NUL] ");
            Assert.AreEqual("XR", tokens.First().Command);
        }

        [TestMethod]
        public void Parse_OneCommandWithTwoParams_ParamsExtracted()
        {
            var parser = new IntermecScanner();
            var tokens = parser.Scan(@"[ESC] XR; aaaa, bbbb [LF] [NUL] ");
            var token = tokens.First();
            Assert.AreEqual("aaaa", token.Parameters[0]);
            Assert.AreEqual("bbbb", token.Parameters[1]);
        }
    }
}
