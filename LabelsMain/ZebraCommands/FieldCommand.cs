using System.Collections.Generic;

namespace LabelsMain.ZebraCommands
{
    public class FieldCommand : IZebraCommand
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}