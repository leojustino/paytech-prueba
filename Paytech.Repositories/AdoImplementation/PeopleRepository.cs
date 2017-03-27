using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paytech.Domain.Entities;
using Paytech.Domain.Repositories;
using Paytech.Domain.Values;

namespace Paytech.Repositories.AdoImplementation
{
    class PeopleRepository : IPeopleRepository
    {
        public PeopleRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        string connectionString;     

        public IEnumerable<Person> GetPeople()
        {
            throw new NotImplementedException();
        }

        public Person GetPerson(int id)
        {
            throw new NotImplementedException();
        }
    }
}
