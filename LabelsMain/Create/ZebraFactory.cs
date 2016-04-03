using System.Threading.Tasks;
using LabelsMain.Models;
using LabelsMain.Parse;
using LabelsMain.Scan;

namespace LabelsMain.Create
{
    public class ZebraFactory : ILabelFactory
    {
        public async Task<Label> CreateAsync(string label)
        {
            var scanner = new ZebraScanner();
            var tokens = scanner.Scan(label);
            var parser = new ZebraParser();
            var concreteLabel = parser.Parse(tokens);
            return await Task.FromResult(concreteLabel);
        }
    }
}