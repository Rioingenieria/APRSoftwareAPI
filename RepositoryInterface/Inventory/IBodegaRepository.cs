using Models.Inventory;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.Inventory
{
    public interface IBodegaRepository : ICreateRepository<Bodega>, IReadRepository<Bodega, int>, IRemoveRepository<Bodega>, IUpdateRepository<Bodega>, ICreateEntityRepository<Bodega>
    {
        Boolean IsExistNombreBodega(string _nombre);
    }
}
