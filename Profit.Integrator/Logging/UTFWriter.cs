using System.Text;
namespace Profit.Integrator.Logging
{
    internal class UTFWriter : StringWriter
    {
        public UTFWriter() : base(new StringBuilder(1024))
        {
        }

        public override Encoding Encoding => Encoding.UTF8;
    }
}


