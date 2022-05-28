using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface.Ingresos;

namespace UnitOfWorkSqlServer.Ingresos
{
    public class UnitOfWorkIngresoSqlServerAdapter : IUnitOfWorkIngresoAdapter
    {
        public SqlConnection _context { get; set; }
        public SqlTransaction _transaction { get; set; }
        public IUnitOfWorkIngresoRepository Repository { get; set; }
        public UnitOfWorkIngresoSqlServerAdapter()
        {
            try
            {
                _context = new SqlConnection(CreateConnectionString());
                _context.Open();
                _transaction = _context.BeginTransaction();
                Repository = new UnitOfWorkIngresoSqlServerRepository(_context, _transaction);
            }
            catch (Exception ex)
            {

                Models.SalidaLogs.AgregarLog(ex);
            }
        }
        public string CreateConnectionString()
        {
            return ConnectionStringSql.CreateConnection();
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
    }
}
