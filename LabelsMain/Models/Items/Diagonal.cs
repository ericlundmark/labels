using System.Drawing;

namespace LabelsMain.Models.Items
{
    internal class Diagonal : LabelItem
    {
        public Diagonal(int x, int y, int width, int height, int thickness, Color color, string orientation)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Thickness = thickness;
            Color = color;
            Orientation = orientation;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Thickness { get; set; }
        public Color Color { get; set; }
        public string Orientation { get; set; }
    }
}