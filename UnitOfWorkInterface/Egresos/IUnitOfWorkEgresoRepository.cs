using RepositoryInterface.Egresos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkInterface.Egresos
{
    public interface IUnitOfWorkEgresoRepository
    {
        IEgresoRepository EgresoRepository { get; }
    }
}
