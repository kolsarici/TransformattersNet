using Kolsarici.Transformatters.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kolsarici.Transformatters.Business.Concrete.Managers
{
    public class XmlManager : IXmlService
    {
        public string Beautify(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                return doc.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
