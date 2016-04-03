using System.Drawing;
using LabelsMain.Printers;

namespace LabelsMain.Models.Items
{
    public class TextField : LabelItem
    {
        public TextField(Point point, string font, Orientation orientation, int width, int height, string data)
        {
            Point = point;
            Font = font;
            Orientation = orientation;
            Width = width;
            Height = height;
            Data = data;
        }

        public override void Print(IPrinter printer)
        {
            printer.Print(this);
        }

        public Point Point { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Data { get; set; }
        public string Font { get; set; }
        public Orientation Orientation { get; set; }
    }
}