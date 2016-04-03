using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LabelsMain.Models;
using LabelsMain.Printers;

namespace LabelConverter.Formatters
{
    public class MonarchFormatter : MediaTypeFormatter
    {
        public MonarchFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/mchp"));
        }

        public override bool CanReadType(Type type)
        {
            throw new NotImplementedException();
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof (Label);
        }

        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
            TransportContext transportContext)
        {
            var label = value as Label;
            var printer = new MonarchPrinter();
            label.Print(printer);
            var printedLabel = printer.ToString();
            await writeStream.WriteAsync(Encoding.UTF8.GetBytes(printedLabel), 0, printedLabel.Length);
        }
    }
}