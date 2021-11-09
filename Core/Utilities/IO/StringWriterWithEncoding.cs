using System.IO;
using System.Text;

namespace Core.Utilities.IO
{
    public sealed class StringWriterWithEncoding : StringWriter
    {
        private readonly Encoding encoding;
        public StringWriterWithEncoding(Encoding encoding) => this.encoding = encoding;
        public StringWriterWithEncoding(Encoding encoding, StringBuilder sb) : base(sb) => this.encoding = encoding;
        public override Encoding Encoding => encoding;
    }
}
