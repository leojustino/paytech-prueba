using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paytech.Domain.Entities;
using Paytech.Domain.Repositories;

namespace Paytech.Repositories.DapperImplementation
{
    class PeopleRepository : IPeopleRepository
    {
        public PeopleRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        string connectionString;     
        
        IEnumerable<Person> IPeopleRepository.GetPeople()
        {
            throw new NotImplementedException();
        }

        Person IPeopleRepository.GetPerson(int id)
        {
            throw new NotImplementedException();
        }
    }
}
