using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabelsMain.Printers;

namespace LabelsMain.Models
{
    public abstract class LabelItem : IPrintable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public abstract void Print(IPrinter printer);
    }
}