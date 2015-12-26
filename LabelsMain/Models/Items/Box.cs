using System.Drawing;
using LabelsMain.Models;

namespace LabelsMain.Parse
{
    internal class Box : LabelItem
    {
        private Color _color;
        private int _height;
        private int _thickness;
        private int _width;
        private int _x;
        private int _y;

        public Box(int x, int y, int width, int height, int thickness, Color color)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _thickness = thickness;
            _color = color;
        }
    }
}