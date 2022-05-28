using RepositoryInterface.DTEs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface.DTEs;

namespace UnitOfWorkSqlServer.DTEs
{
    public class UnitOfWorkDTESqlServerRepository : IUnitOfWorkDTERepository
    {
        public IDTERepository DTERepository { get; set; }
        public UnitOfWorkDTESqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            //falta implementar DTERepository
            //DTERepository = new DTERepository(context, transaction);
        }
    }
}
