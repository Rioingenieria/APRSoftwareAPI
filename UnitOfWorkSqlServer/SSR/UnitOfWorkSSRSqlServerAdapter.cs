using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface.SSR;

namespace UnitOfWorkSqlServer.SSR
{
   public class UnitOfWorkSSRSqlServerAdapter:IUnitOfWorkSSRAdapter
    {
        public SqlConnection _context { get; set; }
        public SqlTransaction _transaction { get; set; }

        public IUnitOfWorkSSRRepository Repository { get; set; }
        public UnitOfWorkSSRSqlServerAdapter()
        {
            try
            {
                _context = new SqlConnection(CreateConnectionString());
                _context.Open();
                _transaction = _context.BeginTransaction();
                Repository = new UnitOfWorkSSRSqlServerRepository(_context, _transaction);
            }
            catch (Exception ex)
            {

                Models.SalidaLogs.AgregarLog(ex);
            }

        }
        public void Dispose()
        {
            if (_context != null)
            {
                _transaction.Dispose();
            }

            if (_context != null)
            {
                _context.Close();
                _context.Dispose();
            }
            Repository = null;
        }
        public void SaveChange()
        {
            _transaction.Commit();
        }

        public string CreateConnectionString()
        {
            return ConnectionStringSql.CreateConnection();
        }
    }
}
