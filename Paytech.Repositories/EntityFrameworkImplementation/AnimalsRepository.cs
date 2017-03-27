using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paytech.Domain.Entities;
using Paytech.Domain.Repositories;

namespace Paytech.Repositories.EntityFrameworkImplementation
{
    class AnimalsRepository : IAnimalsRepository
    {
        public AnimalsRepository(DataContext context)
        {
            this.context = context;
        }

        DataContext context;

        public Animal GetAnimal(int id)
        {
            return context
                .Animals
                .Include("Owner")
                .FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return context
                .Animals
                .Include("Owner")
                .ToList();
        }
    }
}
