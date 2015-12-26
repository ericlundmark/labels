using System.Drawing;

namespace LabelsMain.Models.Items
{
    internal class Circle : LabelItem
    {
        private Color _color;
        private int _diameter;
        private int _thickness;
        private int _x;
        private int _y;

        public Circle(int x, int y, int diameter, int thickness, Color color)
        {
            _x = x;
            _y = y;
            _diameter = diameter;
            _thickness = thickness;
            _color = color;
        }
    }
}