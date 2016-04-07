using System;
using System.Collections.Generic;
using System.Text;
using LabelsMain.Models;
using LabelsMain.Models.Items;
using LabelsMain.Parse;

namespace LabelsMain.Printers
{
    public class MonarchPrinter : IPrinter
    {
        private readonly StringBuilder _builder = new StringBuilder();
        private List<LabelItem> _fields = new List<LabelItem>();
        public int Height => 1218;
        public int Width => 768;
        public void Print(Box printable)
        {
            _builder.AppendLine($"Q,{Height - printable.Point.Y},{printable.Point.X},{Height - printable.Point.Y + printable.Height},{printable.Point.X + printable.Width},{printable.Thickness},\"\" |");
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
            _builder.AppendLine(
                $"C,{Height - printable.Point.Y},{printable.Point.X},3,1,1,1,B,L,0,0,\"{printable.Data}\",1 |");
        }

        public void BeforePrint(Label label)
        {
            _builder.AppendLine($"{{F,1,A,R,G,{Height},{Width},\"Label\" |");
        }

        public void AfterPrint()
        {
            _builder
                .AppendLine("}")
                .AppendLine("{B,1,N,1 |");
            foreach (var field in _fields)
            {
                _builder.AppendLine($"B,{_fields.IndexOf(field) + 1} |");
            }
            _builder.AppendLine("}");
        }

        public void Print(Barcode barcode)
        {
            _builder.AppendLine($"B,{_fields.Count + 1},# of char,fix/var,{Height - barcode.Point.Y},{barcode.Point.X},1,{barcode.Interpretation},{barcode.Height}, text, alignment, field rot, type, sep_height, segment | ");
            _fields.Add(barcode);
        }

        public override string ToString()
        {
            return _builder.ToString();
        }
    }
}
