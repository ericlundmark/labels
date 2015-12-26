namespace LabelsMain.ZebraCommands
{
    public interface IVisitor
    {
        void Visit(IZebraCommand command);
    }
}