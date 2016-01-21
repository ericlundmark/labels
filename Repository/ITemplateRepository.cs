using System.Threading.Tasks;
using LabelsMain.Models;

namespace Repository
{
    public interface ITemplateRepository
    {
        Task<Template> GetAsync(string id);
        Task<Template> CreateAsync();
    }
}