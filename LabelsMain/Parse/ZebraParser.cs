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


        public Point Home { get; set; }
        public FieldContext FieldContext { get; set; }

        public Label Parse(IEnumerable<Token> tokens)
        {
            var label = new Label();
            FieldContext = new FieldContext(new Font("A", Orientation.Normal, 5, 9));
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
                case "A":
                    SetFont(token);
                    break;
                case "B1":
                    break;
                case "BY":
                    SetBarcodeDefaults(token);
                    break;
                case "BC":
                    label.Items.Add(CreateBarCode(token));
                    break;
                case "FR":
                    break;
                case "FW":
                    var orientation = token.ParameterOrDefault(0, "");
                    if (orientation.Equals(""))
                    {
                        break;
                    }
                    FieldContext.Orientation = orientation;
                    break;
                case "FD":
                    var tf = CreateTextField(token);
                    label.Items.Add(tf);
                    FieldContext.ResetFont();
                    break;
                case "FO":
                    FieldContext.Origin = new Point(Home.X + token.ParameterOrDefault(0, 0), Home.Y + token.ParameterOrDefault(1, 0));
                    break;
                case "FX":
                    break;
                case "CF":
                    FieldContext.DefaultFont.Name = token.ParameterOrDefault(0, "A");
                    FieldContext.DefaultFont.Height = token.ParameterOrDefault(1, FieldContext.DefaultFont.Height);
                    FieldContext.DefaultFont.Width = token.ParameterOrDefault(2, FieldContext.DefaultFont.Width);
                    break;
                case "FS":
                    ResetFieldDefinition();
                    break;
                case "FT":
                    FieldContext.Origin = new Point(token.ParameterOrDefault(0, 0), token.ParameterOrDefault(1, 0));
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
                case "PO":
                    label.Rotation = token.ParameterOrDefault(0, "N").Equals("I") ? 180 : 0;
                    break;
                default:
                    _unSupported.Add(token);
                    break;
            }
        }

        private void SetBarcodeDefaults(Token token)
        {
            var width = token.ParameterOrDefault(0,2);
            var ratio = token.ParameterOrDefault(1,2.0);
            var height = token.ParameterOrDefault(2,10);
            FieldContext.BarcodeFieldDefault = new BarcodeFieldDefault(width,ratio,height);
        }

        private LabelItem CreateBarCode(Token token)
        {
            var x = FieldContext.Origin.X;
            var y = FieldContext.Origin.Y;
            var or = GetFontOrientation(token.ParameterOrDefault(0, FieldContext.Orientation));
            var height = token.ParameterOrDefault(1, FieldContext.BarcodeFieldDefault.Height);
            var interpretation = token.ParameterOrDefault(3, "Y").Equals("Y");
            var interpretationPos = token.ParameterOrDefault(4, "N").Equals("N") ? InterpretationLocation.Below : InterpretationLocation.Above;
            var checkDigit = token.ParameterOrDefault(5, "N").Equals("Y");
            return new Barcode(new Point(x,y), BarcodeType.Code128, or, height,FieldContext.BarcodeFieldDefault.Width, interpretation, interpretationPos, checkDigit);
        }

        private LabelItem CreateTextField(Token token)
        {
            var x = FieldContext.Origin.X;
            var y = FieldContext.Origin.Y;
            var font = FieldContext.Font;
            var name = font.Name;
            var orientation = font.Orientation;
            var width = font.Width;
            var height = font.Height;
            var data = token.ParameterOrDefault(0, "");
            return new TextField(new Point(x, y), name, orientation, width, height, data);
        }

        private void SetFont(Token token)
        {

            var font = token.ParameterOrDefault(0, "A");
            var width = token.ParameterOrDefault(1, 12);
            var height = token.ParameterOrDefault(2, 15);
            var orientation = GetFontOrientation(token.ParameterOrDefault(3, FieldContext.Orientation));
            FieldContext.Font = new Font(font, orientation, width, height);
        }

        private Orientation GetFontOrientation(string orientation)
        {
            switch (orientation)
            {
                case "N":
                    return Orientation.Normal;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private Diagonal CreateDiagonal(Token token)
        {
            var x = FieldContext.Origin.X;
            var y = FieldContext.Origin.Y;
            var width = token.ParameterOrDefault(0, 1);
            var height = token.ParameterOrDefault(1, 1);
            var thickness = token.ParameterOrDefault(2, 1);
            var color = token.ParameterOrDefault(3, "B").Equals("W") ? Color.White : Color.Black;
            var orientation = token.ParameterOrDefault(4, "R").Equals("L") ? "L" : "R";
            return new Diagonal(new Point(x, y), width, height, thickness, color, orientation);
        }

        private Box CreateBox(Token token)
        {
            var x = FieldContext.Origin.X;
            var y = FieldContext.Origin.Y;
            var width = token.ParameterOrDefault(0, 1);
            var height = token.ParameterOrDefault(1, 1);
            var thickness = token.ParameterOrDefault(2, 1);
            var color = token.ParameterOrDefault(3, "B").Equals("W") ? Color.White : Color.Black;
            var rounding = token.ParameterOrDefault(4, 0);
            return new Box(new Point(x, y), width, height, thickness, color, rounding);
        }

        private Circle CreateCircle(Token token)
        {
            var x = FieldContext.Origin.X;
            var y = FieldContext.Origin.Y;
            var diameter = token.ParameterOrDefault(0, 0);
            var thickness = token.ParameterOrDefault(1, 0);
            var color = token.Parameters[3].Equals("W") ? Color.White : Color.Black;
            var circle = new Circle(new Point(x, y), diameter, thickness, color);
            return circle;
        }

        private void ResetFieldDefinition()
        {
            FieldContext.Reset();
        }
    }
}