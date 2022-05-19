using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.Actions
{
    public interface IUpdateRepository<T> where T : class
    {
        int Update(T t);
        int UpdateSoftDelete(int _id, Boolean _isEliminado);
    }
}
