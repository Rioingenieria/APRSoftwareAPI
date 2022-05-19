using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.Actions
{
    public interface IRemoveRepository<T>
    {
        int Remove(T id);
    }
}
