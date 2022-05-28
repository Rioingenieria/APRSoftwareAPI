using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkInterface.Egresos
{
    public interface IUnitOfWorkEgresoAdapter : IDisposable
    {
        IUnitOfWorkEgresoRepository Repository { get; }
        void SaveChange();
        string CreateConnectionString();
    }
}
