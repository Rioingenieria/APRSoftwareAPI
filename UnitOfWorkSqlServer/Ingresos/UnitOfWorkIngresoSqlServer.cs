using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface.Ingresos;

namespace UnitOfWorkSqlServer.Ingresos
{
    public class UnitOfWorkIngresoSqlServer : IUnitOfWorkIngreso
    {
        public IUnitOfWorkIngresoAdapter Create()
        {
            return new UnitOfWorkIngresoSqlServerAdapter();
        }
    }
}
