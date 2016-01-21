using System.Drawing;
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
            Assert.AreEqual(box.X, 0);
            Assert.AreEqual(box.Y, 0);
            Assert.AreEqual(1, box.Width);
            Assert.AreEqual(1, box.Height);
            Assert.AreEqual(1, box.Thickness);
            Assert.AreEqual(Color.Black, box.Color);
            Assert.AreEqual(0, box.Rounding);
        }

        [TestMethod]
        public void Parse_BoxWithParameters_ParsedWithSpecifiedValues()
        {
            var builder = new FluentZebraBuilder();
            var tokens = builder.Rectangle("2", "2", "2", "W", "2").Build();

            var parser = new ZebraParser();
            var label = parser.Parse(tokens);
            Assert.AreEqual(1, label.Items.Count);
            var box = label.Items[0] as Box;
            Assert.IsNotNull(box);
            Assert.AreEqual(2, box.Width);
            Assert.AreEqual(2, box.Height);
            Assert.AreEqual(2, box.Thickness);
            Assert.AreEqual(Color.White, box.Color);
            Assert.AreEqual(2, box.Rounding);
        }

        [TestMethod]
        public void Parse_BoxWithPreceedingFO_ParsedWithSpecifiedOrigin()
        {
            var builder = new FluentZebraBuilder();
            var tokens = builder.Origin(10, 10).Rectangle().Build();

            var parser = new ZebraParser();
            var label = parser.Parse(tokens);
            Assert.AreEqual(1, label.Items.Count);
            var box = label.Items[0] as Box;
            Assert.IsNotNull(box);
            Assert.AreEqual(10, box.X);
            Assert.AreEqual(10, box.Y);
        }

        [TestMethod]
        public void Parse_BoxWithFoDirectlyFollowdByFs_ParsedWithOrigoAsOrigin()
        {
            var builder = new FluentZebraBuilder();
            var tokens = builder.Origin(10, 10).Separate().Rectangle().Build();

            var parser = new ZebraParser();
            var label = parser.Parse(tokens);
            Assert.AreEqual(1, label.Items.Count);
            var box = label.Items[0] as Box;
            Assert.IsNotNull(box);
            Assert.AreEqual(0, box.X);
            Assert.AreEqual(0, box.Y);
        }
    }
}