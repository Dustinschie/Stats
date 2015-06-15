using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Reflection;
using Stats.Models;
using Stats.DataAccess;

namespace Stats
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterType<ModelFactory>().As<IModelFactory>();
            builder.RegisterType<StatsService>().As<IStatsService>();
            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;


        }
    }
}
