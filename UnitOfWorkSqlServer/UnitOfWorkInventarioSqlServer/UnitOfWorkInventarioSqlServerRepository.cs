using RepositoryInterface.Inventory;
using RepositorySqlServer.Inventory;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface.IUnitOfWorkInventario;

namespace UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer
{
    public class UnitOfWorkInventarioSqlServerRepository : IUnitOfWorkInventarioRepository
    {
        public IBodegaRepository BodegaRepository { get; set; }

        public UnitOfWorkInventarioSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {

            BodegaRepository = new BodegaRepository(context, transaction);

        }
    }
}
