using System.Threading.Tasks;
using LabelsMain.Models;
using Repository;
using Template = LabelConverter.Models.Requests.Template;

namespace LabelConverter.Controllers
{
    public class TemplateController
    {
        private readonly TemplateRepository _repository;

        public TemplateController(TemplateRepository repository)
        {
            _repository = repository;
        }

        public async Task<LabelViewModel> CreateAsync(Template template)
        {
            var t = await _repository.CreateAsync();
            return null;
        }

        public async Task<Models.Responses.Template> GetAsync(string id)
        {
            var t = await _repository.GetAsync(id);
            return null;
        }
    }
}