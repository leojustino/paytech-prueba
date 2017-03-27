using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paytech.Domain.Applications;
using Paytech.Domain.Entities;
using Paytech.Domain.Repositories;

namespace Paytech.Application
{
    class ApplicationImplementation : IApplication
    {
        public ApplicationImplementation(IPeopleRepository people, IAnimalsRepository animals)
        {
            this.animals = animals;
            this.people = people;    
        }

        IPeopleRepository people;
        IAnimalsRepository animals;

        public Animal GetAnimal(int id)
        {
            return animals.GetAnimal(id);
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return animals.GetAnimals();
        }

        public IEnumerable<Person> GetPeople()
        {
            return people.GetPeople();
        }

        public Person GetPerson(int id)
        {
            return people.GetPerson(id);
        }
    }
}
