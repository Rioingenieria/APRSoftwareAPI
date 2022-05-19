using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkInterface.IUnitOfWorkInventario
{
    public interface IUnitOfWorkInventarioAdapter : IDisposable
    {
        IUnitOfWorkInventarioRepository Repository { get; }
        void SaveChange();
        string CreateConnectionString();
    }
}
