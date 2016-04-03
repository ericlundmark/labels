using System.Collections.Generic;
using System.Threading.Tasks;
using LabelsMain.Convert;
using LabelsMain.Models;
using LabelsMain.Models.Tokens;

namespace LabelsMain.Create
{
    public class IntermecFactory : ILabelFactory
    {
        public Task<Label> CreateAsync(string label)
        {
            throw new System.NotImplementedException();
        }
    }
}