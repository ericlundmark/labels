using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabelsMain.Factory
{
    public interface ILabelFactory
    {
        Task<string> CreateAsync(IList<Token> tokens);
    }
}