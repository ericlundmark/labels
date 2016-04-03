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

        public T ParameterOrDefault<T>(int index, T defaultValue)
        {
            return Parameters.Length <= index || Parameters[index].Equals("") ? defaultValue : (T)System.Convert.ChangeType(Parameters[index], typeof(T));
        }
    }
}