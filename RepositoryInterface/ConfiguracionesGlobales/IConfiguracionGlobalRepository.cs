using Models.ConfiguracionesGlobales;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.ConfiguracionesGlobales
{
    public interface IConfiguracionGlobalRepository:ICreateEntityRepository<ConfiguracionGlobal>,ICreateRepository<ConfiguracionGlobal>,IReadRepository<ConfiguracionGlobal,int>,
        IRemoveRepository<int>,IUpdateRepository<ConfiguracionGlobal>
    {
    }
}
