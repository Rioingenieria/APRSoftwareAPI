using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkInterface.SSR
{
 public interface IUnitOfWorkSSRAdapter : IDisposable
    {
        IUnitOfWorkSSRRepository Repository { get; }
        void SaveChange();
        string CreateConnectionString();
    }
}
