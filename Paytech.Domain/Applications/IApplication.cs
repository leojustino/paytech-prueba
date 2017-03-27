using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paytech.Domain.Entities;

namespace Paytech.Domain.Applications
{
    public interface IApplication
    {
        IEnumerable<Animal> GetAnimals();

        IEnumerable<Person> GetPeople();

        Animal GetAnimal(int id);

        Person GetPerson(int id);
    }
}
