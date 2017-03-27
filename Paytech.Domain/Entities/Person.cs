using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paytech.Domain.Entities
{
    public class Person : IEquatable<Person>
    {
        public Person()
        {
            Animals = new List<Animal>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<Animal> Animals { get; set; }

        public bool Equals(Person other)
        {
            return other != null && Id == other.Id && Name == other.Name;
        }
    }
}
