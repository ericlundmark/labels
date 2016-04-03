using LabelsMain.Models;
using LabelsMain.Models.Items;
using LabelsMain.Parse;

namespace LabelsMain.Printers
{
    public interface IPrinter
    {
        void Print(Box printable);
        void Print(Circle printable);
        void Print(Diagonal printable);
        void Print(TextField printable);
        void BeforePrint(Label label);
        void AfterPrint();
        void Print(Barcode barcode);
    }
}