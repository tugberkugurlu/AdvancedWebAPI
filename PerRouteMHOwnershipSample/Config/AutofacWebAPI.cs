using _09_PerRouteMHOwnershipSample.Models;
using _09_PerRouteMHOwnershipSample.Models.Core;
using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace _09_PerRouteMHOwnershipSample.Config {

    public class AutofacWebAPI {

        public static void Initialize(HttpConfiguration config) {

            Initialize(config,
                RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container) {

            config.DependencyResolver =
                new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder) {

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //EF DbContext
            builder.RegisterType<MyShopContext>()
                .As<DbContext>().InstancePerApiRequest();

            //Repositories
            builder.RegisterType<EntityRepository<Customer>>()
                .As<IEntityRepository<Customer>>()
                .InstancePerApiRequest();

            builder.RegisterType<EntityRepository<Order>>()
                .As<IEntityRepository<Order>>()
                .InstancePerApiRequest();

            return builder.Build();
        }
    }
}