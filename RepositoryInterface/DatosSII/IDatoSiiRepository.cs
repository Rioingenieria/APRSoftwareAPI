using Models.DatosSII;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.DatosSII
{
    public interface IDatoSiiRepository: ICreateRepository<DatoSii>, IUpdateRepository<DatoSii>,
        IRemoveRepository<int>, ICreateEntityRepository<DatoSii>, IReadRepository<DatoSii, int>
    {
    }
}
