using System.Threading.Tasks;
using LabelsMain.Models;

namespace Repository
{
    public interface ILabelRepository
    {
        Task<Label> GetAsync(string id);
        Task<Label> CreateAsync();
    }
}