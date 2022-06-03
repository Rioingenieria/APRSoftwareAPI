using Models.Inventory.ProductosBodegasNew;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.Inventory.ProductosBodegasNew
{
    public interface IProductoBodegaNewRepository : ICreateRepository<ProductoBodegaNew>, IReadRepository<ProductoBodegaNew, int>, IRemoveRepository<ProductoBodegaNew>, IUpdateRepository<ProductoBodegaNew>, ICreateEntityRepository<ProductoBodegaNew>
    {
        Boolean IsExistIdBodega(int _idBodega);
        Boolean IsExistIdProducto(int _idProducto);
    }
}
