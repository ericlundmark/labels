using System.Drawing;
using LabelsMain.Printers;

namespace LabelsMain.Models.Items
{
    public class Box : LabelItem
    {
        public Point Point { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Thickness { get; set; }
        public Color Color { get; set; }
        public int Rounding { get; set; }

        public Box(Point point, int width, int height, int thickness, Color color, int rounding)
        {
            Point = point;
            Width = width;
            Height = height;
            Thickness = thickness;
            Color = color;
            Rounding = rounding;
        }

        public override void Print(IPrinter printer)
        {
            printer.Print(this);
        }
    }
}