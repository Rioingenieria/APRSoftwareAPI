using Models.EmplazamientosNew;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.EmplazamientosNew
{
    public interface IEmplazamientoNewRepository: ICreateRepository<EmplazamientoNew>, IUpdateRepository<EmplazamientoNew>,
        IRemoveRepository<int>, ICreateEntityRepository<EmplazamientoNew>, IReadRepository<EmplazamientoNew, int>
    {
    }
}
