using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paytech.Domain.Applications;
using Paytech.Repositories;

namespace Paytech.Application
{
    public class ApplicationFactory
    {
        public ApplicationFactory(RepositoryType repositoryType)
        {
            (repositoryFactory = new RepositoryFactory(repositoryType)).Container.Register<IApplication, ApplicationImplementation>();
        }

        RepositoryFactory repositoryFactory;

        public T GetInstance<T>()
        {
            return repositoryFactory
                .Container
                .GetInstance<T>();
        }
    }
}
