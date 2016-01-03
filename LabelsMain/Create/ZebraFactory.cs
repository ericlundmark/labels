using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LabelsMain.Factory;
using LabelsMain.Models.Tokens;

namespace LabelsMain.Create
{
    public class ZebraFactory : ILabelFactory
    {
        public Task<string> CreateAsync(IList<Token> tokens)
        {
            throw new NotImplementedException();
        }
    }
}