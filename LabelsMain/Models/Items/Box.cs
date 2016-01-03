using System.Drawing;
using LabelsMain.Models;

namespace LabelsMain.Parse
{
    public class Box : LabelItem
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Thickness { get; set; }
        public Color Color { get; set; }
        public int Rounding { get; set; }

        public Box(int x, int y, int width, int height, int thickness, Color color, int rounding)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Thickness = thickness;
            Color = color;
            Rounding = rounding;
        }
    }
}