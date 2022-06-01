using Models.ConfiguracionesFacturaciones;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.ConfiguracionesFacturaciones
{
    public interface IConfiguracionFacturacionRepository : ICreateRepository<ConfiguracionFacturacion>, IReadRepository<ConfiguracionFacturacion, int>, IRemoveRepository<ConfiguracionFacturacion>, IUpdateRepository<ConfiguracionFacturacion>, ICreateEntityRepository<ConfiguracionFacturacion>
    {
        Boolean IsExistIdUsuario(int _idUsuario);
    }
}
