using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabelsMain.Models;

namespace Repository
{
    public class TemplateRepository : ITemplateRepository
    {
        public Task<Template> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Template> CreateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
