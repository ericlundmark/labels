using System.Drawing;
using System.Linq;
using LabelsMain.Parse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabelConverter.UnitTests.Parse
{
    [TestClass]
    public class ZebraParserTests
    {
        [TestMethod]
        public void Parse_BoxWithoutParameters_ParsedWithDefaultValues()
        {
            var builder = new FluentZebraBuilder();
            var tokens = builder.Rectangle().Build();

            var parser = new ZebraParser();
            var label = parser.Parse(tokens);
            Assert.AreEqual(1, label.Items.Count);
            var box = label.Items[0] as Box;
            Assert.IsNotNull(box);
            Assert.AreEqual(1, box.Width);
            Assert.AreEqual(1, box.Height);
            Assert.AreEqual(1, box.Thickness);
            Assert.AreEqual(Color.Black, box.Color);
            Assert.AreEqual(0, box.Rounding);
        }
    }
}