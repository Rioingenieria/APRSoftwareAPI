using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkInterface.Ingresos
{
    public interface IUnitOfWorkIngreso
    {
        IUnitOfWorkIngresoAdapter Create();
    }
}
