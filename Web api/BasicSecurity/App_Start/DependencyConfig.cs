using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BasicSecurity.Data;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace BasicSecurity.App_Start
{
    public class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //register
            container.Register<IPersonRepository, PersonDbRepository>(Lifestyle.Scoped);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}