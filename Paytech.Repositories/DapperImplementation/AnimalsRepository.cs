using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paytech.Domain.Entities;
using Paytech.Domain.Repositories;

namespace Paytech.Repositories.DapperImplementation
{
    class AnimalsRepository : IAnimalsRepository
    {
        Animal IAnimalsRepository.GetAnimal(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Animal> IAnimalsRepository.GetAnimals()
        {
            throw new NotImplementedException();
        }
    }
}
