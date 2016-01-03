using System.Collections.Generic;
using LabelsMain.Models.Tokens;

namespace LabelsMain.Scan
{
    public interface IScanner
    {
        IEnumerable<Token> Scan(string label);
    }
}