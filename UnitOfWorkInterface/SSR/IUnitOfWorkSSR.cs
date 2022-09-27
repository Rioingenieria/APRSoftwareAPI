using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkInterface.SSR
{
   public interface IUnitOfWorkSSR
    {
        IUnitOfWorkSSRAdapter Create();
    }
}
