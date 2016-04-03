using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabelsMain.Printers;

namespace LabelsMain.Models
{
    public class Label
    {
        public Label()
        {
            Items = new List<LabelItem>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public IList<LabelItem> Items { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Rotation { get; set; }

        public void Print(IPrinter printer)
        {
            printer.BeforePrint(this);
            foreach (var labelItem in Items)
            {
                labelItem.Print(printer);
            }
            printer.AfterPrint();
        }
    }
}