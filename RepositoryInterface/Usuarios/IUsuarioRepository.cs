using Models.Common;
using Models.Request;
using Models.Response;
using Models.Usuarios;
using RepositoryInterface.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface.Usuarios
{
    public interface IUsuarioRepository : ICreateRepository<Usuario>, IReadRepository<Usuario, int>, IUpdateRepository<Usuario>, ICreateEntityRepository<Usuario>, IRemoveRepository<Usuario>
    {

        List<Usuario> GetAllIdNombreApellido();
        Boolean IsExistNombreUsuario(string _nombre);
        UsuarioResponse AuthUsuarioAPI(UsuarioRequest _authRequest);
        string GetToken(UsuarioRequest _authRequest);
    }
}
