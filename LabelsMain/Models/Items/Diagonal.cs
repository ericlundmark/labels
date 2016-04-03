using System.Drawing;
using LabelsMain.Printers;

namespace LabelsMain.Models.Items
{
    public class Diagonal : LabelItem
    {
        public Diagonal(Point point, int width, int height, int thickness, Color color, string orientation)
        {
            Point = point;
            Width = width;
            Height = height;
            Thickness = thickness;
            Color = color;
            Orientation = orientation;
        }

        public Point Point { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Thickness { get; set; }
        public Color Color { get; set; }
        public string Orientation { get; set; }

        public override void Print(IPrinter printer)
        {
            printer.Print(this);
        }
    }
}