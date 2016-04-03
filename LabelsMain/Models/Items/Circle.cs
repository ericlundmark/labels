using System.Drawing;
using LabelsMain.Printers;

namespace LabelsMain.Models.Items
{
    public class Circle : LabelItem
    {
        public Color Color { get; set; }
        public int Diameter { get; set; }
        public int Thickness { get; set; }
        public Point Point { get; set; }

        public Circle(Point point, int diameter, int thickness, Color color)
        {
            Point = point;
            Diameter = diameter;
            Thickness = thickness;
            Color = color;
        }

        public override void Print(IPrinter printer)
        {
            printer.Print(this);
        }
    }
}