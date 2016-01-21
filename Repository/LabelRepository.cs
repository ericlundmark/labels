using System.Threading.Tasks;
using LabelsMain.Models;

namespace Repository
{
    public class LabelRepository : ILabelRepository
    {
        public Task<Label> GetAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Label> CreateAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}