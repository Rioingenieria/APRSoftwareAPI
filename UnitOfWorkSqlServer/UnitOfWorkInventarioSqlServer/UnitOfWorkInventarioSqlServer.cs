using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface.IUnitOfWorkInventario;

namespace UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer
{
    public class UnitOfWorkInventarioSqlServer : IUnitOfWorkInventario
    {
        public IUnitOfWorkInventarioAdapter Create()
        {
            return new UnitOfWorkInventarioSqlServerAdapter();
        }
    }
}
