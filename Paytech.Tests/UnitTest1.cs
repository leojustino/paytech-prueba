using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paytech.Application;
using Paytech.Domain.Applications;
using Paytech.Domain.Entities;
using Paytech.Repositories;

namespace Paytech.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [ClassInitialize]
        public static void ClassInitialization(TestContext c)
        {
            ado = new ApplicationFactory(RepositoryType.ADO).GetInstance<IApplication>();
            dapper = new ApplicationFactory(RepositoryType.Dapper).GetInstance<IApplication>();
            entityFramework = new ApplicationFactory(RepositoryType.EntityFramework).GetInstance<IApplication>();
            inMemory = new ApplicationFactory(RepositoryType.InMemory).GetInstance<IApplication>();
        }

        static IApplication ado;
        static IApplication dapper;
        static IApplication entityFramework;
        static IApplication inMemory;

        #region repository rests

        static void Test_GetAnimals(IApplication application)
        {
            var animals = inMemory.GetAnimals().ToArray();
            var testedAnimals = application.GetAnimals().ToArray();

            Assert.AreEqual(animals.Length, testedAnimals.Length);

            foreach (var animal in animals)
            {
                var testedAnimal = testedAnimals.FirstOrDefault(a => a.Id == animal.Id);

                Assert.IsNotNull(testedAnimal);
                Assert.IsTrue(animal.Equals(testedAnimal));
                Assert.IsTrue(animal.Owner.Equals(testedAnimal.Owner));
            }
        }
        static void Test_GetAnimal(IApplication application)
        {
            foreach (var animal in inMemory.GetAnimals())
            {
                var testedAnimal = application.GetAnimal(animal.Id);

                Assert.IsNotNull(testedAnimal);
                Assert.IsTrue(animal.Equals(testedAnimal));
                Assert.IsTrue(animal.Owner.Equals(testedAnimal.Owner));
            }
        }
        static void Test_GetPeople(IApplication application)
        {
            var people = inMemory.GetPeople().ToArray();
            var testedPeople = application.GetPeople().ToArray();

            Assert.AreEqual(people.Length, testedPeople.Length);

            foreach (var person in people)
            {
                var testedPerson = testedPeople.FirstOrDefault(a => a.Id == person.Id);

                Assert.IsNotNull(testedPerson);
                Assert.IsTrue(person.Equals(testedPerson));
                Assert.AreEqual(person.Animals.Count(), testedPerson.Animals.Count());
            }
        }
        static void Test_GetPerson(IApplication application)
        {
            foreach (var person in inMemory.GetPeople())
            {
                var testedPerson = application.GetPerson(person.Id);

                Assert.IsNotNull(testedPerson);
                Assert.IsTrue(person.Equals(testedPerson));
                Assert.AreEqual(person.Animals.Count(), testedPerson.Animals.Count());
            }
        }

        /// <summary>
        ///  como entity framework estas competamente implementado todas las pruebas se han exitosas.
        /// </summary>
        [TestMethod]
        public void Test_EntityFramework()
        {
            Test_GetAnimals(entityFramework);
            Test_GetPeople(entityFramework);
            Test_GetPerson(entityFramework);
            Test_GetAnimal(entityFramework);
        }

        /// <summary>
        /// apenas el metodo IAnimalsRepository.GetAnimalEstas implementado como forma de ejemplo. 
        /// implementar los métodos
        ///     IAnimalsRepository.GetAnimals;
        ///     IPeopleRepository.GetPerson;
        ///     IPeopleRepository.GetPeople;
        /// </summary>
        [TestMethod]
        public void Test_Ado()
        {
            Test_GetAnimal(ado);
            Test_GetAnimals(ado);
            Test_GetPeople(ado);
            Test_GetPerson(ado);
        }

        /// <summary>
        /// implementar los métodos:
        ///     IAnimalsRepository.GetAnimal;
        ///     IAnimalsRepository.GetAnimals;
        ///     IPeopleRepository.GetPerson;
        ///     IPeopleRepository.GetPeople;
        /// </summary>
        [TestMethod]
        public void Test_Dapper()
        {
            Test_GetAnimal(dapper);
            Test_GetAnimals(dapper);
            Test_GetPeople(dapper);
            Test_GetPerson(dapper);
        }

        #endregion

        #region animal test

        /// <summary>
        /// implementar la propriedad Animal.Age
        /// </summary>
        [TestMethod]
        public void Test_Age_Property()
        {
            foreach (var animal in inMemory.GetAnimals())
                Assert.AreEqual(animal.Id, animal.Age);
        }

        #endregion

        #region api communication tests

        /// <summary>
        /// estas implementado y sirve como base
        /// </summary>
        [TestMethod]
        public void Test_Api_Método_Test()
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/values/test"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

                var response = client.SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    Assert.AreEqual("Api Ok", content.Replace("\"", ""));
                }
                else
                    Assert.Fail();
            }
        }

        /// <summary>
        /// arreglar el test para que pase, supostamente la api debe retornar un json con los animales
        /// </summary>
        [TestMethod]
        public void Test_Api_Método_Animals()
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/values/animals"))
            {
                var animals = new Animal[0];

                //a implementar


                if (animals.Length > 0)
                    foreach (var animal in animals)
                        Assert.IsTrue(animal.Equals(inMemory.GetAnimal(animal.Id)));
                else
                    Assert.Fail();
            }
        }

        #endregion

        #region threading tests

        /// <summary>
        /// opcional: coordinar los hilos (provider, consumerA y consumerB) para que el hilo provider 
        /// consiga prover datos a través de la variable number, donde daca vez que el hilo provider llene 
        /// la variable los dos otros hilos puedan consumir (leer) la variable.
        /// </summary>       
        [TestMethod]
        public void Test_Coordenate_Threads()
        {
            var number = 0;
            var numbersFromA = new int[0];
            var numbersFromB = new int[0];
            var provider = new Thread(a =>
            {
                var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

                foreach (var actual in numbers)
                    number = actual;
            });
            var consumerA = new Thread(a =>
            {
                var numbers = new List<int>();

                while (number < 11)
                    if ((number % 2) == 0)
                        numbers.Add(number);

                numbersFromA = numbers.ToArray();
            });
            var consumerB = new Thread(a =>
            {
                var numbers = new List<int>();

                while (number < 11)
                    if ((number % 2) != 0)
                        numbers.Add(number);

                numbersFromB = numbers.ToArray();
            });

            provider.Start();
            consumerA.Start();
            consumerB.Start();

            provider.Join();
            consumerA.Join();
            consumerB.Join();

            Assert.AreEqual(5, numbersFromA.Length);
            Assert.AreEqual(2, numbersFromA[0]);
            Assert.AreEqual(4, numbersFromA[1]);
            Assert.AreEqual(6, numbersFromA[2]);
            Assert.AreEqual(8, numbersFromA[3]);
            Assert.AreEqual(10, numbersFromA[4]);

            Assert.AreEqual(5, numbersFromB.Length);
            Assert.AreEqual(1, numbersFromB[0]);
            Assert.AreEqual(3, numbersFromB[1]);
            Assert.AreEqual(5, numbersFromB[2]);
            Assert.AreEqual(7, numbersFromB[3]);
            Assert.AreEqual(9, numbersFromB[4]);
        }

        #endregion


    }
}
