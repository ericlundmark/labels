using LabelsMain.Models;

namespace LabelConverter.Models.Requests
{
    public class Template
    {
        public string LabelData { get; set; }
        public LabelType Type { get; set; }
    }
}