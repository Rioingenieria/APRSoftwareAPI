using Models.Inventory.BodegasUsuariosNew;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.Inventory.BodegasUsuariosNew
{
    public interface IBodegaUsuarioNewRepository :  IReadRepository<BodegaUsuarioNew, int>,ICreateRepository<BodegaUsuarioNew>, IUpdateRepository<BodegaUsuarioNew>, ICreateEntityRepository<BodegaUsuarioNew>, IRemoveRepository<BodegaUsuarioNew>
    {
    }
}
