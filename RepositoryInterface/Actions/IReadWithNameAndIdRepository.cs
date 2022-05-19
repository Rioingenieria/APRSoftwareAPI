using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.Actions
{
    public interface IReadWithNameAndIdRepository<T, Y> where T : class
    {
        T GetByNameAndId(T name, Y id);
    }
}
