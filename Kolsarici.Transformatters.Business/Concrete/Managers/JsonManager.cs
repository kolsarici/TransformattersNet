using Kolsarici.Transformatters.Business.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolsarici.Transformatters.Business.Concrete.Managers
{
    public class JsonManager : IJsonService
    {
        public string Beautify(string str)
        {
            try
            {
                dynamic parsedJson = JsonConvert.DeserializeObject(str);
                return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public object Desrialize(string str)
        {
            try
            {
                return JsonConvert.DeserializeObject(str);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
