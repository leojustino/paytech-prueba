using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paytech.Domain.Entities;

namespace Paytech.Domain.Repositories
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> GetPeople();

        Person GetPerson(int id);
    }
}
