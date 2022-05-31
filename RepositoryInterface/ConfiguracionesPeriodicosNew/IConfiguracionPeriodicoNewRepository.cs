using Models.ConfiguracionesPeriodicosNew;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.ConfiguracionesPeriodicosNew
{
    public interface IConfiguracionPeriodicoNewRepository : ICreateEntityRepository<ConfiguracionPeriodicoNew>, ICreateRepository<ConfiguracionPeriodicoNew>, IReadRepository<ConfiguracionPeriodicoNew, int>,
        IRemoveRepository<int>, IUpdateRepository<ConfiguracionPeriodicoNew>
    {
    }
}
