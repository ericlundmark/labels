using System.Collections.Generic;
using System.Threading.Tasks;
using LabelsMain.Models;

namespace LabelsMain.Factory
{
    public class IntermecFactory : ILabelFactory
    {
        public IntermecFactory()
        {
            
        }
        public Task<string> CreateAsync(IList<Token> tokens)
        {
            var converter = ConverterFactory.Create(LabelType.Intermec);
            foreach (var token in tokens)
            {
                
            }
            return null;
        }
    }
}