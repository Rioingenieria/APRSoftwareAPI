using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface.Egresos;

namespace UnitOfWorkSqlServer.Egresos
{
    public class UnitOfWorkEgresoSqlServer : IUnitOfWorkEgreso
    {
        public IUnitOfWorkEgresoAdapter Create()
        {
            return new UnitOfWorkEgresoSqlServerAdapter();
        }
    }
}
