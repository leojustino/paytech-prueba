using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paytech.Domain.Entities;
using Paytech.Domain.Repositories;

namespace Paytech.Repositories.InMemoryImplementation
{
    class AnimalsRepository : IAnimalsRepository
    {
        Animal IAnimalsRepository.GetAnimal(int id)
        {
            return InMemoryContext.Animals.FirstOrDefault(a => a.Id == id);
        }

        IEnumerable<Animal> IAnimalsRepository.GetAnimals()
        {
            return InMemoryContext.Animals;
        }
    }
}
