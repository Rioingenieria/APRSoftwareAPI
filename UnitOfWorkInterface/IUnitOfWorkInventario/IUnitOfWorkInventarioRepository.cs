using RepositoryInterface.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkInterface.IUnitOfWorkInventario
{
    public interface IUnitOfWorkInventarioRepository
    {

        IBodegaRepository BodegaRepository { get; }
       
    }
}
