using System;
using LabelsMain.Models.Tokens;

namespace LabelsMain.Convert
{
    internal class ZebraConverter : IConverter
    {
        public string Convert(Token token)
        {
            //switch (token.)
            //{
            //    case TokenType.Line:
            //        return ConvertLine(token);
            //    case TokenType.Barcode:
            //        return ConvertBarcode(token);
            //    case TokenType.Text:
            //        return ConvertText(token);
            //    default:
            //        throw new ArgumentOutOfRangeException();
            //}
            return null;
        }

        private string ConvertText(Token token)
        {
            throw new NotImplementedException();
        }

        private string ConvertBarcode(Token token)
        {
            throw new NotImplementedException();
        }

        private string ConvertLine(Token token)
        {
            throw new NotImplementedException();
        }
    }
}