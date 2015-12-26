using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LabelsMain.Factory;

namespace LabelsMain.Scan
{
    public class IntermecScanner : IScanner
    {
        public IEnumerable<Token> Scan(string label)
        {
            label = Regex.Replace(label, @"\t|\n|\r", "");
            var tags = new[] { "<STX>", "<ETX>" };
            var rawCommands = label.Split(tags, StringSplitOptions.RemoveEmptyEntries);
            return rawCommands.Select(command => command.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                .Select(splitCommand => new Token(splitCommand[0], splitCommand.Skip(1).ToArray()));
        }
    }
}