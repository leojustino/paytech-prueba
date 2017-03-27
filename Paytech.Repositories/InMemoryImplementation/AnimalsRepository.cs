using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paytech.Domain.Entities;
using Paytech.Domain.Repositories;

namespace Paytech.Repositories.InMemoryImplementation
{
    class PeopleRepository : IPeopleRepository
    {
        IEnumerable<Person> IPeopleRepository.GetPeople()
        {
            return InMemoryContext.People;
        }

        Person IPeopleRepository.GetPerson(int id)
        {
            return InMemoryContext.People.FirstOrDefault(a => a.Id == id);
        }
    }
}
