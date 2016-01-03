namespace LabelsMain.Models.Tokens
{
    public class Token
    {
        public string Command { get; set; }
        public string[] Parameters { get; set; }

        public Token(string command, string[] parameters = null)
        {
            Command = command;
            Parameters = parameters ?? new string[0];
        }

        public int ParameterAsInt(int index)
        {
            return int.Parse(Parameters[index]);
        }

        public T ParameterOrDefault<T>(int index, T defaultValue)
        {
            return Parameters.Length <= index ? defaultValue : (T)System.Convert.ChangeType(Parameters[index], typeof(T));
        }
    }
}