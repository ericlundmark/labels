using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelsMain.ZebraCommands
{
    abstract class ZebraCommand : IZebraCommand
    {
        public IEnumerable<Action> Related { get; set; }
        public abstract void Accept(IVisitor visitor);
    }
}
