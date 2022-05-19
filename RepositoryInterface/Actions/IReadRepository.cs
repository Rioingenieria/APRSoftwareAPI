using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.Actions
{
    public interface IReadRepository<T, Y> where T : class
    {
        List<T> GetAll();
        T GetById(Y id);
    }
}
