using Models.Inventory.BodegasNew;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.Inventory.BodegasNew
{
    public interface IBodegaNewRepository : ICreateRepository<BodegaNew>, IReadRepository<BodegaNew, int>, IRemoveRepository<BodegaNew>, IUpdateRepository<BodegaNew>, ICreateEntityRepository<BodegaNew>
    {
        Boolean IsExistNombreBodega(string _nombre);
    }
}
