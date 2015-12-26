using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelsMain.Models
{
    public class CreateLabelRequest
    {
        public string LabelData { get; set; }
        public LabelType Type { get; set; }
    }
}
