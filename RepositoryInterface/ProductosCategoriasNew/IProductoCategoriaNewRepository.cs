using Models.ProductosCategoriasNew;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.ProductosCategoriaNew
{
    public interface IProductoCategoriaNewRepository: ICreateRepository<ProductoCategoriaNew>, IUpdateRepository<ProductoCategoriaNew>,
        IRemoveRepository<int>, ICreateEntityRepository<ProductoCategoriaNew>, IReadRepository<ProductoCategoriaNew, int>
    {
    }
}
