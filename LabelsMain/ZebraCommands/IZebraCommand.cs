using System.Data;

namespace LabelsMain.ZebraCommands
{
    public interface IZebraCommand
    {
        void Accept(IVisitor visitor);
    }
}