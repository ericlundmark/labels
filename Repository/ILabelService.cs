using System.Threading.Tasks;
using LabelsMain.Models;

namespace Repository
{
    public interface ILabelService
    {
        Task<Label> GetAsync(int id);
        Task<Label> CreateAsync(string decodedString, LabelType type);
    }
}