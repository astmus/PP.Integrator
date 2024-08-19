using System.Text;
namespace Profit.Integrator
{
    internal class UtfWriter : StringWriter
    {
        public UtfWriter() : base(new StringBuilder(1024))
        {
        }

        public override Encoding Encoding => Encoding.UTF8;
    }
}


