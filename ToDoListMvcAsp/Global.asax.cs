using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ToDoListMvcAsp.Modules;

namespace ToDoListMvcAsp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterAutofac();
        }

        private void RegisterAutofac()
        {
            // Create the Autofac container builder
            var builder = new ContainerBuilder();

            // Register all controllers in the current assembly
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register your custom module which handles service registrations
            builder.RegisterModule(new ServiceModule());

            // Build the container
            var container = builder.Build();

            // Set the MVC Dependency Resolver to Autofac
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
