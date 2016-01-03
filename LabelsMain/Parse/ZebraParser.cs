using System.Collections.Generic;
using System.Drawing;
using LabelsMain.Factory;
using LabelsMain.Models;
using LabelsMain.Models.Items;
using LabelsMain.Models.Tokens;

namespace LabelsMain.Parse
{
    public class ZebraParser : IParser
    {
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
            return label;
        }

        private void Execute(Token token, Label label)
        {
            switch (token.Command)
            {
                case "FD":
                    var tf = CreateTextField(token);
                    label.Items.Add(tf);
                    return;
                case "FO":
                    Origin = new Point(Home.X + token.ParameterAsInt(0), Home.Y + token.ParameterAsInt(1));
                    return;
                case "FS":
                    ResetFieldDefinition();
                    return;
                case "FT":
                    Origin = new Point(token.ParameterAsInt(0), token.ParameterAsInt(1));
                    return;
                case "GB":
                    var box = CreateBox(token);
                    label.Items.Add(box);
                    return;
                case "GC":
                    var circle = CreateCircle(token);
                    label.Items.Add(circle);
                    return;
                case "GD":
                    var diagonal = CreateDiagonal(token);
                    label.Items.Add(diagonal);
                    return;
                case "LH":
                    var x = token.ParameterAsInt(0);
                    var y = token.ParameterAsInt(1);
                    Home = new Point(x, y);
                    return;
                case "PW":
                    label.Width = token.ParameterAsInt(0);
                    return;
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
            var diameter = token.ParameterAsInt(0);
            var thickness = token.ParameterAsInt(1);
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