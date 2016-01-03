using System.Collections.Generic;
using System.Threading.Tasks;
using LabelsMain.Models.Tokens;

namespace LabelsMain.Create
{
    public interface ILabelFactory
    {
        Task<string> CreateAsync(IList<Token> tokens);
    }
}