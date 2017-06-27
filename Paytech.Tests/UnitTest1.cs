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

            Assert.AreEqual(animals.Length, testedAnimals.Length, "cantidad errada de animales");

            foreach (var animal in animals)
            {
                var testedAnimal = testedAnimals.FirstOrDefault(a => a.Id == animal.Id);

                Assert.IsNotNull(testedAnimal, "el animal no existe");
                Assert.IsTrue(animal.Equals(testedAnimal), "el animal no es igual");
                Assert.IsTrue(animal.Owner.Equals(testedAnimal.Owner), "el dueño no es valido");
            }
        }
        static void Test_GetAnimal(IApplication application)
        {
            foreach (var animal in inMemory.GetAnimals())
            {
                var testedAnimal = application.GetAnimal(animal.Id);

                Assert.IsNotNull(testedAnimal, "el animal no existe");
                Assert.IsTrue(animal.Equals(testedAnimal), "el animal no es igual");
                Assert.IsTrue(animal.Owner.Equals(testedAnimal.Owner), "el dueño no es valido");
            }
        }
        static void Test_GetPeople(IApplication application)
        {
            var people = inMemory.GetPeople().ToArray();
            var testedPeople = application.GetPeople().ToArray();

            Assert.AreEqual(people.Length, testedPeople.Length, "la cantidad de personas no esta correcta");

            foreach (var person in people)
            {
                var testedPerson = testedPeople.FirstOrDefault(a => a.Id == person.Id);

                Assert.IsNotNull(testedPerson, "la persona retornada no existe");
                Assert.IsTrue(person.Equals(testedPerson), "la persona neo es igual");
                Assert.AreEqual(person.Animals.Count(), testedPerson.Animals.Count(), "cantidad invalida de animales");
            }
        }
        static void Test_GetPerson(IApplication application)
        {
            foreach (var person in inMemory.GetPeople())
            {
                var testedPerson = application.GetPerson(person.Id);

                Assert.IsNotNull(testedPerson, "la persona retornada no existe");
                Assert.IsTrue(person.Equals(testedPerson), "la persona no es igual");
                Assert.AreEqual(person.Animals.Count(), testedPerson.Animals.Count(), "cantidad invalida de animales");
            }
        }

        /// <summary>
        ///  como entity framework estas competamente implementado todas las pruebas se han exitosas.
        /// </summary>
        [TestMethod]
        public void Test_EntityFramework_GetAnimals()
        {
            Test_GetAnimals(entityFramework);
        }
        [TestMethod]
        public void Test_EntityFramework_GetPeople()
        {
            Test_GetPeople(entityFramework);
        }
        [TestMethod]
        public void Test_EntityFramework_GetPerson()
        {
            Test_GetPerson(entityFramework);
        }
        [TestMethod]
        public void Test_EntityFramework_GetAnimal()
        {
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
        public void Test_Ado_GetAnimal()
        {
            Test_GetAnimal(ado);
        }
        [TestMethod]
        public void Test_Ado_GetAnimals()
        {
            Test_GetAnimals(ado);
        }
        [TestMethod]
        public void Test_Ado_GetPeople()
        {
            Test_GetPeople(ado);
        }
        [TestMethod]
        public void Test_Ado_GetPerson()
        {
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
        public void Test_Dapper_GetAnimal()
        {
            Test_GetAnimal(dapper);
        }
        [TestMethod]
        public void Test_Dapper_GetAnimals()
        {
            Test_GetAnimals(dapper);
        }
        [TestMethod]
        public void Test_Dapper_GetPeople()
        {
            Test_GetPeople(dapper);
        }
        [TestMethod]
        public void Test_Dapper_GetPerson()
        {
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

        


    }
}
