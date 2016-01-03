using LabelsMain.Models.Tokens;

namespace LabelsMain.Convert
{
    public interface IConverter
    {
        string Convert(Token token);
    }
}