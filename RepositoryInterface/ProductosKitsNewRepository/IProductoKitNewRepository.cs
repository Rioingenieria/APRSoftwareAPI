using Models.ProductosKitsNew;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.ProductosKitsNewRepository
{
    public interface IProductoKitNewRepository: ICreateEntityRepository<ProductoKitNew>,
        ICreateRepository<ProductoKitNew>, IReadRepository<ProductoKitNew, int>,
        IRemoveRepository<int>, IUpdateRepository<ProductoKitNew>
    {

    }
}
