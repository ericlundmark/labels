using System.Collections.Generic;
using LabelsMain.Models;
using LabelsMain.Models.Tokens;

namespace LabelsMain.Parse
{
    public interface IParser
    {
        Label Parse(IEnumerable<Token> tokens);
    }
}