using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface.IUnitOfWorkInventario;

namespace UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer
{
    public class UnitOfWorkInventarioSqlServerAdapter : IUnitOfWorkInventarioAdapter
    {
        public SqlConnection _context { get; set; }
        public SqlTransaction _transaction { get; set; }

        public IUnitOfWorkInventarioRepository Repository { get; set; }
        public UnitOfWorkInventarioSqlServerAdapter()
        {
            try
            {
                _context = new SqlConnection(CreateConnectionString());
                _context.Open();
                _transaction = _context.BeginTransaction();
                Repository = new UnitOfWorkInventarioSqlServerRepository(_context, _transaction);
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
