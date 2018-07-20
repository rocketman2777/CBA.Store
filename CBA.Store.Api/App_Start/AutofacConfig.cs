using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using CBA.Store.Api.Controllers;
using CBA.Store.Api.Mapping;
using CBA.Store.Data.Context;
using CBA.Store.Data.Repository;
using CBA.Store.Data.Interface;

namespace CBA.Store.Api
{
    /// <summary>
    /// Configure Autofac dependency injection and configure ASP MVC to use it for 
    /// creating controllers
    /// </summary>
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            ConfigureApplicationDependencies(builder);

            // Set the ASPMVC dependency resolver to be Autofac.
            var container = builder.Build();
            // Hook up Autofac to ASPMVC controllers
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // Hook up Autofac to Web API controllers
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }

        private static void ConfigureApplicationDependencies(ContainerBuilder builder)
        {
            // Register EF context
            builder.RegisterType<EntityContext>().As<EntityContext>().WithParameter("nameOrConnectionString", "StoreDatabase");
            // Register repositories classes
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            // we want the mapper to be a singleton, could also use traditional thread safe
            // single pattern but this is a bit simpler
            builder.Register<IMapper>(c => { return MapperFactory.CreateMapper(); }).SingleInstance();
            // Register your MVC controllers
            builder.RegisterControllers(typeof(AutofacConfig).Assembly);
            // Register your Web API controllers
            builder.RegisterApiControllers(typeof(AutofacConfig).Assembly);
        }
    }
}