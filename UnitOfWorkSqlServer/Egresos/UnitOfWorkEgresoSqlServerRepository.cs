using RepositoryInterface.Egresos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface.Egresos;

namespace UnitOfWorkSqlServer.Egresos
{
    public class UnitOfWorkEgresoSqlServerRepository : IUnitOfWorkEgresoRepository
    {
        public IEgresoRepository EgresoRepository { get; set; }
        public UnitOfWorkEgresoSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            //falta implementar EgresoRepostory
            //EgresoRepository = new EgresoRepository(context, transaction);
        }
    }
}
