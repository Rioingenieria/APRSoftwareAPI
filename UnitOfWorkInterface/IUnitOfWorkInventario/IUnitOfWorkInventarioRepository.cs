using RepositoryInterface.Inventory;
using RepositoryInterface.Inventory.BodegasNew;
using RepositoryInterface.Inventory.BodegasUsuariosNew;
using RepositoryInterface.Inventory.ProductosBodegasNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkInterface.IUnitOfWorkInventario
{
    public interface IUnitOfWorkInventarioRepository
    {
        IBodegaRepository BodegaRepository { get; }
        IBodegaNewRepository BodegaNewRepository { get; }
        IBodegaUsuarioNewRepository BodegaUsuarioNewRepository { get; }
        IProductoBodegaNewRepository ProductoBodegaNewRepository { get; }
    }
}
