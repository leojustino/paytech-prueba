using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Paytech.Application;
using Paytech.Domain.Applications;
using Paytech.Domain.Entities;
using Paytech.Repositories;

namespace Paytech.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        static ValuesController()
        {
            animals = new ApplicationFactory(RepositoryType.InMemory).GetInstance<IApplication>().GetAnimals().ToArray();

            foreach (var item in animals)
                item.Owner.Animals = new Animal[0];
        }

        static Animal[] animals;

        [HttpGet]
        public string Test()
        {
            return "Api Ok";
        }

        [HttpGet]
        public IEnumerable<Animal> Animals()
        {            
            return animals;
        }
    }
}
