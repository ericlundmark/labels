using System.Collections.Generic;
using LabelsMain.Factory;
using LabelsMain.Models;

namespace LabelsMain.Parse
{
    internal interface IParser
    {
        Label Parse(IEnumerable<Token> tokens);
    }
}