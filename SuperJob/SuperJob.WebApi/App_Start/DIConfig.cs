using Autofac;
using Autofac.Integration.WebApi;
using SuperJob.Repository;
using SuperJob.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace SuperJob.WebApi.App_Start
{
    public class DIConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new ServiceModules());
            builder.RegisterModule(new RepositoryModules());

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}