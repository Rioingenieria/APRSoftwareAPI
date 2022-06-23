using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;
using UnitOfWorkInterface.SSR;

namespace UnitOfWorkSqlServer.SSR
{
    public class UnitOfWorkSSRSqlServer : IUnitOfWorkSSR
    {
        public IUnitOfWorkSSRAdapter Create()
        {
         return new UnitOfWorkSSRSqlServerAdapter();
        }
    }
}
