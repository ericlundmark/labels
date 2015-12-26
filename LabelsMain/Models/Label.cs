using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelsMain.Models
{
    class Label
    {
        public IList<LabelItem> Items { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
