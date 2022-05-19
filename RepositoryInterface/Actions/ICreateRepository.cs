using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.Actions
{
    public interface ICreateRepository<T> where T : class
    {
        int Create(T t);
    }
}
