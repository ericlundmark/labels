using System;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LabelConverter.Models.Requests;
using LabelsMain.Printers;
using Repository;

namespace LabelConverter.Controllers
{
    [RoutePrefix("api/labels")]
    public class LabelController : ApiController
    {
        private readonly LabelService _labelService;

        public LabelController()
        {
            _labelService = new LabelService();
        }

        [Route]
        [ResponseType(typeof(string))]
        [HttpPost]
        public async Task<IHttpActionResult> CreateAsync(Label label)
        {
            if (label == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = Convert.FromBase64String(label.Data);
            var decodedString = Encoding.UTF8.GetString(data);
            var l = await _labelService.CreateAsync(decodedString, label.Type);
            return CreatedAtRoute("GetLabel", new { labelId = l.Id }, l);
        }

        [Route("{labelId:int}", Name = "GetLabel")]
        [ResponseType(typeof(string))]
        [HttpGet]
        public async Task<IHttpActionResult> GetAsync(int labelId)
        {
            var label = await _labelService.GetAsync(labelId);
            return Ok(label);
        }
    }
}