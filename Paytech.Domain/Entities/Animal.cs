using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paytech.Domain.Values;

namespace Paytech.Domain.Entities
{
    public class Animal : IEquatable<Animal>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AnimalType Type { get; set; }

        public DateTime Birth { get; set; }

        public int OwnerId { get; set; }      


        public virtual Person Owner { get; set; }

        public int Age
        {
            get
            {
                return -1;
            }
        }

        public bool Equals(Animal other)
        {
            return other != null && Id == other.Id && Name == other.Name && Birth == other.Birth && OwnerId == other.OwnerId;
        }
    }
}
