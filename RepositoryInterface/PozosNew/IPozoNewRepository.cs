using Models.PozosNew;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.PozosNew
{
    public interface IPozoNewRepository: ICreateRepository<PozoNew>, IUpdateRepository<PozoNew>,
        IRemoveRepository<int>, ICreateEntityRepository<PozoNew>, IReadRepository<PozoNew, int>
    {
    }
}
