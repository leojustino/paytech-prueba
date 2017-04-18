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

                var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                var tempAnimals = new[]
                {
                    new Animal { Id = 01, Birth = date.AddYears(-1), Type = AnimalType.Cat, OwnerId = 4, Name = "Raul" },
                    new Animal { Id = 02, Birth = date.AddYears(-2), Type = AnimalType.Dog, OwnerId = 3, Name = "Mello" },
                    new Animal { Id = 03, Birth = date.AddYears(-3), Type = AnimalType.Bird, OwnerId = 2, Name = "Olivares" },
                    new Animal { Id = 04, Birth = date.AddYears(-4), Type = AnimalType.Mice, OwnerId = 1, Name = "Miguel" },
                    new Animal { Id = 05, Birth = new DateTime(date.Year-6, 12, 31), Type = AnimalType.Cat, OwnerId = 5, Name = "Montagnini" },
                    new Animal { Id = 06, Birth = date.AddYears(-6), Type = AnimalType.Bird, OwnerId = 4, Name = "Camila" },
                    new Animal { Id = 07, Birth = date.AddYears(-7), Type = AnimalType.Mice, OwnerId = 2, Name = "Daniela" },
                    new Animal { Id = 08, Birth = date.AddYears(-8), Type = AnimalType.Cat, OwnerId = 3, Name = "Nice" },
                    new Animal { Id = 09, Birth = date.AddYears(-9), Type = AnimalType.Bird, OwnerId = 2, Name = "Luiz" },
                    new Animal { Id = 10, Birth = date.AddYears(-10), Type = AnimalType.Mice, OwnerId = 1, Name = "Ricardo" },
                    new Animal { Id = 11, Birth = date.AddYears(-11), Type = AnimalType.Cat, OwnerId = 5, Name = "Anyelo" },
                    new Animal { Id = 12, Birth = date.AddYears(-12), Type = AnimalType.Bird, OwnerId = 4, Name = "Angello" },
                    new Animal { Id = 13, Birth = date.AddYears(-13), Type = AnimalType.Mice, OwnerId = 2, Name = "Patricia" },
                    new Animal { Id = 14, Birth = date.AddYears(-14), Type = AnimalType.Cat, OwnerId = 3, Name = "Constanza" },
                    new Animal { Id = 15, Birth = date.AddYears(-15), Type = AnimalType.Bird, OwnerId = 4, Name = "Diego" },
                    new Animal { Id = 16, Birth = date.AddYears(-16), Type = AnimalType.Mice, OwnerId = 2, Name = "Eurico" },
                    new Animal { Id = 17, Birth = date.AddYears(-17), Type = AnimalType.Cat, OwnerId = 3, Name = "Paulo" }
                 };

                foreach (var animal in tempAnimals)
                    (animal.Owner = tempPeople.FirstOrDefault(p => p.Id == animal.OwnerId)).Animals.Add(animal);

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
