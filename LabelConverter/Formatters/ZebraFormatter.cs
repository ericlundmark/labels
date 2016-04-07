using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LabelsMain.Models;
using LabelsMain.Printers;

namespace LabelConverter.Formatters
{
    public class ZebraFormatter : MediaTypeFormatter
    {
        public ZebraFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/zpl"));
        }
        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(Label);
        }

        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
            TransportContext transportContext)
        {
            var label = value as Label;
            var printer = new ZebraPrinter();
            label.Print(printer);
            var printedLabel = printer.ToString();
            await writeStream.WriteAsync(Encoding.UTF8.GetBytes(printedLabel), 0, printedLabel.Length);
        }
    }
}