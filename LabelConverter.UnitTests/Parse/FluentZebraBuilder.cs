using System.Collections.Generic;
using System.Linq;
using LabelsMain.Models.Tokens;

namespace LabelConverter.UnitTests.Parse
{
    public class FluentZebraBuilder
    {
        private readonly List<Token> _tokens;

        public FluentZebraBuilder()
        {
            _tokens = new List<Token>();
            _tokens.Add(new Token("XA"));
        }

        public FluentZebraBuilder Rectangle(string width = null, string height = null, string thickness = null,
            string color = null, string rounding = null)
        {
            var parameters = new[] {width, height, thickness, color, rounding};
            parameters = parameters.Where(p => p != null).ToArray();
            _tokens.Add(new Token("GB", parameters));
            return this;
        }

        public List<Token> Build()
        {
            _tokens.Add(new Token("XZ"));
            return _tokens;
        }
    }
}