using RepositoryInterface.DTEs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkInterface.DTEs
{
    public interface IUnitOfWorkDTERepository
    {
        IDTERepository DTERepository { get; }
    }
}
