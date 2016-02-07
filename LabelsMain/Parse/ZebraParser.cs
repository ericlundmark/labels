using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using LabelsMain.Models;
using LabelsMain.Models.Items;
using LabelsMain.Models.Tokens;

namespace LabelsMain.Parse
{
    public class ZebraParser : IParser
    {
        private readonly List<Token> _unSupported;

        public ZebraParser()
        {
            _unSupported = new List<Token>();
        }

        public Point Origin { get; set; }
        public Point Home { get; set; }

        public Label Parse(IEnumerable<Token> tokens)
        {
            var label = new Label();
            Origin = new Point(0, 0);
            foreach (var token in tokens)
            {
                Execute(token, label);
            }
            if (_unSupported.Count <= 0) return label;
            var sb = new StringBuilder();
            foreach (var token in _unSupported.GroupBy(p => p.Command).Select(g => g.First()).ToList())
            {
                sb.Append(token.Command + Environment.NewLine);
            }
            throw new ArgumentException(sb.ToString());
        }

        private void Execute(Token token, Label label)
        {
            switch (token.Command)
            {
                case "FD":
                    var tf = CreateTextField(token);
                    label.Items.Add(tf);
                    break;
                case "FO":
                    Origin = new Point(Home.X + token.ParameterOrDefault(0, 0), Home.Y + token.ParameterOrDefault(1, 0));
                    break;
                case "FS":
                    ResetFieldDefinition();
                    break;
                case "FT":
                    Origin = new Point(token.ParameterOrDefault(0, 0), token.ParameterOrDefault(1, 0));
                    break;
                case "GB":
                    var box = CreateBox(token);
                    label.Items.Add(box);
                    break;
                case "GC":
                    var circle = CreateCircle(token);
                    label.Items.Add(circle);
                    break;
                case "GD":
                    var diagonal = CreateDiagonal(token);
                    label.Items.Add(diagonal);
                    break;
                case "LH":
                    var x = token.ParameterOrDefault(0, 0);
                    var y = token.ParameterOrDefault(1, 0);
                    Home = new Point(x, y);
                    break;
                case "PW":
                    label.Width = token.ParameterOrDefault(0, 0);
                    break;
                case "XA":
                    break;
                case "XZ":
                    break;
                default:
                    _unSupported.Add(token);
                    break;
            }
        }

        private TextField CreateTextField(Token token)
        {
            var x = Origin.X;
            var y = Origin.Y;
            var text = token.Parameters[0];
            return new TextField();
        }

        private Diagonal CreateDiagonal(Token token)
        {
            var x = Origin.X;
            var y = Origin.Y;
            var width = token.ParameterOrDefault(0, 1);
            var height = token.ParameterOrDefault(1, 1);
            var thickness = token.ParameterOrDefault(2, 1);
            var color = token.ParameterOrDefault(3, "B").Equals("W") ? Color.White : Color.Black;
            var orientation = token.ParameterOrDefault(4, "R").Equals("L") ? "L" : "R";
            return new Diagonal(x, y, width, height, thickness, color, orientation);
        }

        private Box CreateBox(Token token)
        {
            var x = Origin.X;
            var y = Origin.Y;
            var width = token.ParameterOrDefault(0, 1);
            var height = token.ParameterOrDefault(1, 1);
            var thickness = token.ParameterOrDefault(2, 1);
            var color = token.ParameterOrDefault(3, "B").Equals("W") ? Color.White : Color.Black;
            var rounding = token.ParameterOrDefault(4, 0);
            return new Box(x, y, width, height, thickness, color, rounding);
        }

        private Circle CreateCircle(Token token)
        {
            var x = Origin.X;
            var y = Origin.Y;
            var diameter = token.ParameterOrDefault(0, 0);
            var thickness = token.ParameterOrDefault(1, 0);
            var color = token.Parameters[3].Equals("W") ? Color.White : Color.Black;
            var circle = new Circle(x, y, diameter, thickness, color);
            return circle;
        }

        private void ResetFieldDefinition()
        {
            Origin = new Point(0, 0);
        }
    }
}