using Kolsarici.Transformatters.Business.Abstract;
using Kolsarici.Transformatters.Business.Concrete.Managers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolsarici.Transformatters.Business.DependencyResolvers.Ninject
{

    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IJsonService>().To<JsonManager>().InSingletonScope();

            Bind<IXmlService>().To<XmlManager>();
        }
    }
}

