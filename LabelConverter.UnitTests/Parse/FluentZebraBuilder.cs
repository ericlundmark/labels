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
            var parameters = new[] { width, height, thickness, color, rounding };
            parameters = parameters.Where(p => p != null).ToArray();
            _tokens.Add(new Token("GB", parameters));
            return this;
        }

        public List<Token> Build()
        {
            _tokens.Add(new Token("XZ"));
            return _tokens;
        }

        public FluentZebraBuilder Origin(int x, int y)
        {
            _tokens.Add(new Token("FO", new[] { x.ToString(), y.ToString() }));
            return this;
        }

        public FluentZebraBuilder Separate()
        {
            _tokens.Add(new Token("FS"));
            return this;
        }

        public FluentZebraBuilder Invert()
        {
            _tokens.Add(new Token("PO", new[] { "I" }));
            return this;
        }

        public FluentZebraBuilder Font()
        {
            _tokens.Add(new Token("A"));
            return this;
        }
    }
}