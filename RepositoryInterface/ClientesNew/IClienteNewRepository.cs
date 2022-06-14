using Models.ClientesNew;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.ClientesNew
{
    public interface IClienteNewRepository : ICreateRepository<ClienteNew>, IUpdateRepository<ClienteNew>,
        IRemoveRepository<int>, ICreateEntityRepository<ClienteNew>, IReadRepository<ClienteNew, int>
    {
        Boolean IsExitsRutCliente(string _rut);
    }
}
