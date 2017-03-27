using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paytech.Repositories
{
    public enum RepositoryType
    {
        Dapper,
        ADO,
        EntityFramework,
        InMemory,
    }
}
