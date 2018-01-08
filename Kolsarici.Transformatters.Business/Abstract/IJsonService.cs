using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolsarici.Transformatters.Business.Abstract
{
    public interface IJsonService
    {
        string Beautify(string str);
        object Desrialize(string str);
    }
}
