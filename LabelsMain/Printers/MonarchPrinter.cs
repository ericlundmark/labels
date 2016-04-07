using System;
using System.Text;
using LabelsMain.Models;
using LabelsMain.Models.Items;
using LabelsMain.Parse;

namespace LabelsMain.Printers
{
    public class MonarchPrinter : IPrinter
    {
        private readonly StringBuilder _builder = new StringBuilder();
        private int _fieldCount = 1;
        public int Height => 1218;
        public int Width => 768;
        public void Print(Box printable)
        {
            _builder.Append($"Q,{Height - printable.Point.Y},{printable.Point.X},{Height - printable.Point.Y + printable.Height},{printable.Point.X + printable.Width},{printable.Thickness},\"\" |").AppendLine();
        }

        public void Print(Circle printable)
        {
            throw new NotImplementedException();
        }

        public void Print(Diagonal printable)
        {
            throw new NotImplementedException();
        }

        public void Print(TextField printable)
        {
            _builder.Append(
                $"C,{Height - printable.Point.Y},{printable.Point.X},3,1,1,1,B,L,0,0,\"{printable.Data}\",1 |")
                .AppendLine();
        }

        public void BeforePrint(Label label)
        {
            _builder.Append($"{{F,1,A,R,G,{Height},{Width},\"Label\" |").AppendLine();
        }

        public void AfterPrint()
        {
            _builder
                .Append("}")
                .AppendLine()
                .Append("{B,1,N,1 |}");
        }

        public void Print(Barcode barcode)
        {
            _builder.AppendLine($"B,{_fieldCount},# of char,fix/var,{Height - barcode.Point.Y},{barcode.Point.X},1,{barcode.Interpretation},{barcode.Height}, text, alignment, field rot, type, sep_height, segment | ");
            _fieldCount++;
        }

        public override string ToString()
        {
            return _builder.ToString();
        }
    }
}
