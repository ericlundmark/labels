using System.Data.Entity;
using System.Threading.Tasks;
using LabelConverter.Models;
using LabelsMain.Create;
using LabelsMain.Models;

namespace Repository
{
    public class LabelService : ILabelService
    {
        private readonly ApplicationDbContext _context;

        public LabelService()
        {
            _context = ApplicationDbContext.Create();
        }

        public async Task<Label> GetAsync(int id)
        {
            return await _context.Labels.FirstAsync(l => l.Id == id);
        }

        public async Task<Label> CreateAsync(string decodedString, LabelType type)
        {
            var factory = LabelFactory.Create(type);
            var label = await factory.CreateAsync(decodedString);
            _context.Labels.Add(label);
            await _context.SaveChangesAsync();
            return label;
        }
    }
}