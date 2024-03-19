using Autofac;
using SuperJob.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperJob.Repository
{
    public class RepositoryModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>();
        }
    }
}
