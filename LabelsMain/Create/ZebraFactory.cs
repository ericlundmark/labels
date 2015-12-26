using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabelsMain.Models;

namespace LabelsMain.Factory
{
    public class ZebraFactory : ILabelFactory
    {
        public Task<string> CreateAsync(IList<Token> tokens)
        {
            throw new NotImplementedException();
        }
    }
}
