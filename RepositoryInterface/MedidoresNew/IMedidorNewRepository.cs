using Models.MedidoresNew;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.MedidoresNew
{
    public interface IMedidorNewRepository : ICreateRepository<MedidorNew>, IReadRepository<MedidorNew, int>, IUpdateRepository<MedidorNew>, ICreateEntityRepository<MedidorNew>, IRemoveRepository<MedidorNew>
    {
        bool IsExistNumeroMedidorNew(string numeroMedidorNew);
    }
}
