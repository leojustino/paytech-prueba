using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paytech.Domain.Entities;
using Paytech.Domain.Repositories;
using Paytech.Domain.Values;

namespace Paytech.Repositories.InMemoryImplementation
{
    class InMemoryContext 
    {
        static object @lock = new object();
        static Person[] people;
        static Animal[] animals;

        static void Initialize()
        {
            lock (@lock)
            {
                if (people != null)
                    return;

                var tempPeople = new[]
                {
                    new Person { Id = 1, Name = "Tiago", Animals = new List<Animal>() },
                    new Person { Id = 2, Name = "Rodrigo", Animals = new List<Animal>() },
                    new Person { Id = 3, Name = "Bastian", Animals = new List<Animal>() },
                    new Person { Id = 4, Name = "José", Animals = new List<Animal>() },
                    new Person { Id = 5, Name = "André", Animals = new List<Animal>() },
                    new Person { Id = 6, Name = "Eduardo", Animals = new List<Animal>() },
                    new Person { Id = 7, Name = "Bruno", Animals = new List<Animal>() },
                };

                var tempAnimals = new[]
                {
                    new Animal { Id = 01, Birth = new DateTime(2001, 01, 01), Type = AnimalType.Cat, OwnerId = 4, Name = "Raul" },
                    new Animal { Id = 02, Birth = new DateTime(2002, 02, 02), Type = AnimalType.Dog, OwnerId = 3, Name = "Mello" },
                    new Animal { Id = 03, Birth = new DateTime(2003, 03, 03), Type = AnimalType.Bird, OwnerId = 2, Name = "Olivares" },
                    new Animal { Id = 04, Birth = new DateTime(2004, 04, 04), Type = AnimalType.Mice, OwnerId = 1, Name = "Miguel" },
                    new Animal { Id = 05, Birth = new DateTime(2005, 05, 05), Type = AnimalType.Cat, OwnerId = 5, Name = "Montagnini" },
                    new Animal { Id = 06, Birth = new DateTime(2006, 06, 06), Type = AnimalType.Bird, OwnerId = 4, Name = "Camila" },
                    new Animal { Id = 07, Birth = new DateTime(2007, 07, 07), Type = AnimalType.Mice, OwnerId = 2, Name = "Daniela" },
                    new Animal { Id = 08, Birth = new DateTime(2008, 08, 08), Type = AnimalType.Cat, OwnerId = 3, Name = "Nice" },
                    new Animal { Id = 09, Birth = new DateTime(2009, 09, 09), Type = AnimalType.Bird, OwnerId = 2, Name = "Luiz" },
                    new Animal { Id = 10, Birth = new DateTime(2010, 10, 10), Type = AnimalType.Mice, OwnerId = 1, Name = "Ricardo" },
                    new Animal { Id = 11, Birth = new DateTime(2011, 11, 11), Type = AnimalType.Cat, OwnerId = 5, Name = "Anyelo" },
                    new Animal { Id = 12, Birth = new DateTime(2012, 12, 12), Type = AnimalType.Bird, OwnerId = 4, Name = "Angello" },
                    new Animal { Id = 13, Birth = new DateTime(2007, 07, 07), Type = AnimalType.Mice, OwnerId = 2, Name = "Patricia" },
                    new Animal { Id = 14, Birth = new DateTime(2008, 08, 08), Type = AnimalType.Cat, OwnerId = 3, Name = "Constanza" }, 
                    new Animal { Id = 15, Birth = new DateTime(2001, 01, 01), Type = AnimalType.Bird, OwnerId = 4, Name = "Diego" },
                    new Animal { Id = 16, Birth = new DateTime(2002, 02, 02), Type = AnimalType.Mice, OwnerId = 2, Name = "Eurico" },
                    new Animal { Id = 17, Birth = new DateTime(2003, 03, 03), Type = AnimalType.Cat, OwnerId = 3, Name = "Paulo" },
                 };

                foreach (var animal in tempAnimals)
                    (animal.Owner = tempPeople.FirstOrDefault(a => a.Id == animal.OwnerId)).Animals.Add(animal);

                people = tempPeople;
                animals = tempAnimals;
            }
        }

        internal static Person[] People
        {
            get
            {
                if (people == null)
                    Initialize();

                return people;
            }
        }
        internal static Animal[] Animals
        {
            get
            {
                if (animals == null)
                    Initialize();

                return animals;
            }
        }
    }
}
