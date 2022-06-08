using Models.DatosFacturacionNew;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.DatosFacturacionNew
{
    public interface IDatoFacturacionNewRepository:ICreateEntityRepository<DatoFacturacionNew>,
        ICreateRepository<DatoFacturacionNew>, IReadRepository<DatoFacturacionNew, int>, 
        IRemoveRepository<DatoFacturacionNew>, IUpdateRepository<DatoFacturacionNew>
    {
        Boolean IsExistRazonSocial(string _razonSocial);
    }
  
}
