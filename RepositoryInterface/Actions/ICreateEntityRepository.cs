using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.Actions
{
    public interface ICreateEntityRepository<T> where T : class
    {
        T CreateEntity(SqlDataReader dr);
    }
}
