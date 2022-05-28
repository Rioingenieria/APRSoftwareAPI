using RepositoryInterface.Ingresos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface.Ingresos;

namespace UnitOfWorkSqlServer.Ingresos
{
    public class UnitOfWorkIngresoSqlServerRepository : IUnitOfWorkIngresoRepository
    {
        public IIngresoRepository IngresoRepository {get; set;}

        public UnitOfWorkIngresoSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            //Falta implementar IngresoRepository
            //IngresoRepository = new IngresoRepository(context, transaction);
        }
    }
}
