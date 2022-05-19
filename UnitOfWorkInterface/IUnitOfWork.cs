using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkInterface
{
    public interface IUnitOfWork
    {
        IUnitOfWorkAdapter Create();
    }
}
