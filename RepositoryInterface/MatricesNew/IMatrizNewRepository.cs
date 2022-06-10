using Models.MatricesNew;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.MatricesNew
{
    public interface IMatrizNewRepository: ICreateRepository<MatrizNew>, IUpdateRepository<MatrizNew>,
        IRemoveRepository<int>, ICreateEntityRepository<MatrizNew>, IReadRepository<MatrizNew, int>
    {
    }
}
