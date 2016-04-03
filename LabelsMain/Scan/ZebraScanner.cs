using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LabelsMain.Models.Tokens;

namespace LabelsMain.Scan
{
    public class ZebraScanner : IScanner
    {
        public IEnumerable<Token> Scan(string label)
        {
            label = Regex.Replace(label, @"\t|\n|\r", "");
            var rawCommands = label.Split('^', '~').Where(c => !c.Equals(""));
            return rawCommands.Select(ExtractToken);
        }

        private Token ExtractToken(string rawCommand)
        {
            if (OneLetterCommand(rawCommand))
            {
                var command = rawCommand.Substring(0, 1);
                var rawParams = rawCommand.Remove(0, 1);
                var parameters = rawParams.Split(',');
                return new Token(command, parameters);
            }
            else
            {
                var command = rawCommand.Substring(0, 2);
                var rawParams = rawCommand.Remove(0, 2);
                if (rawParams.Equals(""))
                {
                    return new Token(command);
                }
                var parameters = rawParams.Split(',').ToArray();
                return new Token(command, parameters);
            }
            
        }

        private bool OneLetterCommand(string rawCommand)
        {
            return rawCommand[0].Equals('A');
        }
    }
}