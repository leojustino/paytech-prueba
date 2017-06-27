using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightInject;
using Paytech.Domain.Repositories;

namespace Paytech.Repositories
{
    public class RepositoryFactory
    {
        public RepositoryFactory(RepositoryType type)
        {
            (Container = new ServiceContainer())
                .Register(a => CONNECTION_STRING);

            switch (type)
            {
                case RepositoryType.Dapper:
                    Container.Register<IPeopleRepository, DapperImplementation.PeopleRepository>();
                    Container.Register<IAnimalsRepository, DapperImplementation.AnimalsRepository>();
                    break;

                case RepositoryType.InMemory:
                    Container.Register<IPeopleRepository, InMemoryImplementation.PeopleRepository>();
                    Container.Register<IAnimalsRepository, InMemoryImplementation.AnimalsRepository>();
                    break;

                case RepositoryType.ADO:
                    Container.Register<IPeopleRepository, AdoImplementation.PeopleRepository>();
                    Container.Register<IAnimalsRepository, AdoImplementation.AnimalsRepository>();
                    break;

                case RepositoryType.EntityFramework:
                    Container.Register<EntityFrameworkImplementation.DataContext>(new PerContainerLifetime());
                    Container.Register<IPeopleRepository, EntityFrameworkImplementation.PeopleRepository>();
                    Container.Register<IAnimalsRepository, EntityFrameworkImplementation.AnimalsRepository>();
                    break;

                default:
                    throw new ArgumentException("Invalid type.", "type");
            }
        }

        //internal const string CONNECTION_STRING = "Data Source=(local); Initial Catalog=test; Persist Security Info=True;trusted_connection=true";
        internal const string CONNECTION_STRING = "Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=c:\\test\\test.mdf;Database=test";

        public IServiceContainer Container { get; private set; }
    }
}

