using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LabelsMain.Factory;

namespace LabelsMain.Scan
{
    public class ZebraScanner : IScanner
    {
        public IEnumerable<Token> Scan(string label)
        {
            label = Regex.Replace(label, @"\t|\n|\r", "");
            var rawCommands = label.Split('^').Where(c => !c.Equals(""));
            return rawCommands.Select(ExtractToken);
        }

        private Token ExtractToken(string rawCommand)
        {
            var command = rawCommand.Substring(0, 2);
            var rawParams = rawCommand.Remove(0, 2);
            var parameters = rawParams.Split(',');
            return new Token(command, parameters);
        }
    }
}