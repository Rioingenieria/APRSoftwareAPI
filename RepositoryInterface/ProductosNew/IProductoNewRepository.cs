using Models.ProductosNew;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.ProductosNew
{
    public interface IProductoNewRepository: ICreateRepository<ProductoNew>, IUpdateRepository<ProductoNew>, 
        IRemoveRepository<int>,ICreateEntityRepository<ProductoNew>,IReadRepository<ProductoNew,int>
    {
        Boolean IsExistCodigo(string codigo);
        List<ProductoNew> GetByCodigo(int codigo);
    }
}
