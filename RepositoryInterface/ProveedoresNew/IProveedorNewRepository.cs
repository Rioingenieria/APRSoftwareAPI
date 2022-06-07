using Models.ProveedoresNew;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.ProveedoresNew
{
    public interface IProveedorNewRepository: ICreateRepository<ProveedorNew>, IUpdateRepository<ProveedorNew>,
        IRemoveRepository<int>, ICreateEntityRepository<ProveedorNew>, IReadRepository<ProveedorNew, int>
    {
    }
}
