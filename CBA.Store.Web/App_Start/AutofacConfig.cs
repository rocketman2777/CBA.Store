using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using RestSharp;
using CBA.Store.Api.Client;
using CBA.Store.Api.Client.Interface;
using CBA.Store.Web.Mapping;

namespace CBA.Store.Web
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
        }

        private static void ConfigureApplicationDependencies(ContainerBuilder builder)
        {
            builder.Register<IRestClient>(c => { return new RestClient(ConfigurationManager.AppSettings["CBAStoreBaseUri"]); });
            builder.RegisterType<ProductClient>().As<IProductClient>();
            // we want the mapper to be a singleton, could also use traditional thread safe
            // single pattern but this is a bit simpler
            builder.Register<IMapper>(c => { return MapperFactory.CreateMapper(); }).SingleInstance();
            // Register your MVC controllers
            builder.RegisterControllers(typeof(AutofacConfig).Assembly);
        }
    }
}