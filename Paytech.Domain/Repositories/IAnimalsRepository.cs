using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paytech.Domain.Entities;

namespace Paytech.Domain.Repositories
{
    public interface IAnimalsRepository
    {
        IEnumerable<Animal> GetAnimals();

        Animal GetAnimal(int id);
    }
}
