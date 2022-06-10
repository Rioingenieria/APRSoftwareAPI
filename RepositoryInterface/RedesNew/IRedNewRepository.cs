using Models.RedesNew;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.RedesNew
{
    public interface IRedNewRepository: ICreateRepository<RedNew>, IUpdateRepository<RedNew>,
        IRemoveRepository<int>, ICreateEntityRepository<RedNew>, IReadRepository<RedNew, int>
    {
    }
}
