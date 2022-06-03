using RepositoryInterface.Inventory;
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
        IProductoBodegaNewRepository ProductoBodegaNewRepository { get; }
    }
}
