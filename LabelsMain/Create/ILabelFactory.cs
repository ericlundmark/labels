using System.Threading.Tasks;
using LabelsMain.Models;

namespace LabelsMain.Create
{
    public interface ILabelFactory
    {
        Task<Label> CreateAsync(string label);
    }
}