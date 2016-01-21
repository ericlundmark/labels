using System;
using System.Collections.Generic;
using System.Linq;
using LabelsMain.Models.Tokens;

namespace LabelsMain.Scan
{
    public class TecScanner : IScanner
    {
        public IEnumerable<Token> Scan(string label)
        {
            var raw = label.Split(new[] {"[ESC]"}, StringSplitOptions.RemoveEmptyEntries);
            return new List<Token>();
        }
    }
}