using System.Drawing;
using System.Text;
using LabelsMain.Models;
using LabelsMain.Models.Items;
using LabelsMain.Parse;

namespace LabelsMain.Printers
{
    public class ZebraPrinter : IPrinter
    {
        private readonly StringBuilder _builder = new StringBuilder();

        public virtual void Print(Box printable)
        {
            var color = printable.Color == Color.Black ? "B" : "W";
            _builder
                .Append($"^FO{printable.Point.X},{printable.Point.Y}")
                .Append($"^GB{printable.Width},{printable.Height},{printable.Thickness},{color},{printable.Rounding}")
                .Append("^FS")
                .AppendLine();
        }

        public virtual void Print(Circle printable)
        {
            var color = printable.Color == Color.Black ? "B" : "W";
            _builder
                .Append($"^FO{printable.Point.X},{printable.Point.Y}")
                .Append($"^GC{printable.Diameter},{printable.Thickness},{color}")
                .Append("^FS")
                .AppendLine();
        }

        public virtual void Print(Diagonal printable)
        {
            var color = printable.Color == Color.Black ? "B" : "W";
            _builder
                .Append($"^FO{printable.Point.X},{printable.Point.Y}")
                .Append($"^GB{printable.Width},{printable.Height},{printable.Thickness},{color},{printable.Orientation}")
                .Append("^FS")
                .AppendLine();
        }

        public virtual void Print(TextField printable)
        {
            var orientation = printable.Orientation == Orientation.Normal ? "N" : "ERROR";
            _builder
            .Append($"^FO{printable.Point.X},{printable.Point.Y}")
            .Append($"^A{printable.Font},{orientation},{printable.Height},{printable.Width}")
            .Append($"^FD{printable.Data}")
            .Append("^FS")
            .AppendLine();

        }

        public void BeforePrint(Label label)
        {
            _builder
                .Append("^XA")
                .AppendLine();
        }

        public void AfterPrint()
        {
            _builder.Append("^XZ");
        }

        public virtual void Print(Barcode barcode)
        {
            var orientation = barcode.Orientation == Orientation.Normal ? "N" : "ERROR";
            var interpretation = barcode.Interpretation ? "Y" : "N";
            var interpretationPos = barcode.Location == InterpretationLocation.Above ? "Y" : "N";
            var checkDigit = barcode.CheckDigit ? "Y" : "N";
            _builder
                .Append($"^BY{barcode.Width}")
                .Append($"^FO{barcode.Point.X},{barcode.Point.Y}")
                .Append($"^BC{orientation},{barcode.Height},{interpretation},{interpretationPos},{checkDigit}")
                .AppendLine();
        }

        public override string ToString()
        {
            return _builder.ToString();
        }
    }
}