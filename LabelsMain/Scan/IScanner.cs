using System.Collections.Generic;
using LabelsMain.Factory;

namespace LabelsMain.Scan
{
    public interface IScanner
    {
        IEnumerable<Token> Scan(string label);
    }
}