using RepositoryInterface.Inventory;
using RepositoryInterface.Inventory.BodegasNew;
using RepositoryInterface.Inventory.BodegasUsuariosNew;
using RepositoryInterface.Inventory.ProductosBodegasNew;
using RepositorySqlServer.Inventory;
using RepositorySqlServer.Inventory.BodegasNew;
using RepositorySqlServer.Inventory.BodegasUsuariosNew;
using RepositorySqlServer.Inventory.ProductosBodegasNew;
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
        public IBodegaNewRepository BodegaNewRepository { get; set; }
        public IBodegaUsuarioNewRepository BodegaUsuarioNewRepository { get; set; }
        public IProductoBodegaNewRepository ProductoBodegaNewRepository { get; }

        public UnitOfWorkInventarioSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {

            BodegaRepository = new BodegaRepository(context, transaction);
            BodegaNewRepository = new BodegaNewRepository(context, transaction);
            BodegaUsuarioNewRepository = new BodegaUsuarioNewRepository(context, transaction);  
            ProductoBodegaNewRepository = new ProductoBodegaNewRepository(context, transaction);
        }
    }
}
