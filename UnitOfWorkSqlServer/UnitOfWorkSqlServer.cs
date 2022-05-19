using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;

namespace UnitOfWorkSqlServer
{
    public class UnitOfWorkSqlServer : IUnitOfWork
    {
        public IUnitOfWorkAdapter Create()
        {
            return new UnitOfWorkSqlServerAdapter();
        }
    }
}
