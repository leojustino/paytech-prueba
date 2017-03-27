using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paytech.Domain.Entities;
using Paytech.Domain.Repositories;
using Paytech.Domain.Values;

namespace Paytech.Repositories.AdoImplementation
{
    class AnimalsRepository : IAnimalsRepository
    {
        public AnimalsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        string connectionString;

        public Animal GetAnimal(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("select id,name,type,birth,ownerid from animals where id = @1", connection))
            {
                command.Parameters.AddWithValue("@1", id);
                connection.Open();
                var animal = (Animal)null;

                using (var reader = command.ExecuteReader())
                    animal = !reader.Read() ? null : new Animal
                    {
                        Id = reader.GetFieldValue<int>(0),
                        Name = reader.GetFieldValue<string>(1),
                        OwnerId = reader.GetFieldValue<int>(4),
                        Type = reader.GetFieldValue<AnimalType>(2),
                        Birth = reader.GetFieldValue<DateTime>(3),
                    };

                command.CommandText = "select id,name from people where id = @1";
                command.Parameters[0].Value = animal.OwnerId;

                using (var reader = command.ExecuteReader())
                    animal.Owner = !reader.Read() ? null : new Person
                    {
                        Id = reader.GetFieldValue<int>(0),
                        Name = reader.GetFieldValue<string>(1),
                    };

                return animal;
            }
        }

        public IEnumerable<Animal> GetAnimals()
        {
            throw new NotImplementedException();
        }
    }
}
