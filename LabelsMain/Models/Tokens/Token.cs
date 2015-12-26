using System.Xml;

namespace LabelsMain.Factory
{
    public class Token
    {
        public string Command { get; set; }
        public string[] Parameters { get; set; }

        public Token(string command, string[] parameters)
        {
            Command = command;
            Parameters = parameters;
        }

        public int ParameterAsInt(int index)
        {
            return int.Parse(Parameters[index]);
        }
    }
}