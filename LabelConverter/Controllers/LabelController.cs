using System.Threading.Tasks;
using System.Web.Http;
using LabelsMain.Factory;
using LabelsMain.Models;

namespace LabelConverter.Controllers
{
    public class LabelController : ApiController
    {
        public LabelController(LabelFactory factory)
        {
        }

        public Task<LabelViewModel> Create(CreateLabelRequest labelReq)
        {
            return null;
        }
    }
}