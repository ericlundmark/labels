using System.Collections.Generic;

namespace LabelsMain.Models
{
    public class Label
    {
        public IList<LabelItem> Items { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Label()
        {
            Items = new List<LabelItem>();
        }
    }
}