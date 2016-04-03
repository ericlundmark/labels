using LabelsMain.Models;

namespace LabelConverter.Models.Requests
{
    public class Label
    {
        public string Data { get; set; }
        public LabelType Type { get; set; }
    }
}