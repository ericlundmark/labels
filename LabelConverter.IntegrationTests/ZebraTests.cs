using System;
using System.IO;
using LabelsMain.Create;
using LabelsMain.Parse;
using LabelsMain.Scan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabelConverter.IntegrationTests
{
    [TestClass]
    [DeploymentItem(@"TestFiles")]
    public class ZebraTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var scanner = new ZebraScanner();
            var content = File.ReadAllText("TestLabel.txt");
            var tokens = scanner.Scan(content);
            var parser = new ZebraParser();
            var label = parser.Parse(tokens);
            Assert.IsNotNull(label);
        }
    }
}
