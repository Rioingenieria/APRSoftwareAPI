using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface.DTEs;

namespace UnitOfWorkSqlServer.DTEs
{
    public class UnitOfWorkDTESqlServer : IUnitOfWorkDTE
    {
        public IUnitOfWorkDTEAdapter Create()
        {
            return new UnitOfWorkDTESqlServerAdapter();
        }
    }
}
