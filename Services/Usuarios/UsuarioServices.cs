using Models;
using Models.Common;
using Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;
using static Models.Enum.Status;

namespace Services.Usuarios
{
    public class UsuarioServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ValidationsFluent ValidationResult { get; }
        public UsuarioServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        ///<summary>
        ///Obtiene una lista de todos los usuarios existentes en la BBDD
        ///</summary>
        ///<return>
        ///Devuelve un objeto lista de tipo Usuario con todos los nombres y apellidos concatenados del total de usuarios
        ///</return>
        public List<Usuario>? GetAllIdNombreApellido()
        {
            try
            {
                List<Usuario> Usuarios = new List<Usuario>();
                using (var context = _unitOfWork.Create())
                {
                    context.Repository.UsuarioRepository.GetAllIdNombreApellido().ForEach(u => Usuarios.Add(u));
                }
                return Usuarios;
            }
            catch (System.Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        ///<summary>
        ///Crea un nuevo Usuario
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la creación fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_usuario">
        ///Objeto de tipo Usuario con todos sus atributos completos para ser insertado en la BBDD
        ///</param>
        public int Create(Usuario _usuario)
        {
            int result = 0;
            try
            {
                UsuarioValidator validator = new UsuarioValidator();
                ValidationResult.Validation = validator.Validate(_usuario);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _unitOfWork.Create())
                    {
                        result = context.Repository.UsuarioRepository.Create(_usuario);
                        context.SaveChange();
                    }
                    ValidationResult.Status = StatusEnum.Ok;
                    ValidationResult.Message = "Usuario registrado correctamente.";
                }
                else
                {
                    ValidationResult.Status = StatusEnum.Validation;
                }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return result;
        }
        ///<summary>
        ///Obtiene un Usuario por su Id
        ///</summary>
        ///<return>
        ///Devuelve un objeto de tipo Usuario con todos sus atributos completos, de los datos obtenidos desde la BBDD
        ///</return>
        ///<param name="_id">
        ///Id del Usuario a obtener
        ///</param>
        public Usuario GetById(int _id)
        {
            var _usuario = new Usuario();
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    _usuario = context.Repository.UsuarioRepository.GetById(_id);
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return _usuario;
        }
        ///<summary>
        ///Obtiene una lista de todos los clientes_otros existentes en la BBDD
        ///</summary>
        ///<return>
        ///Devuelve un objeto lista de tipo Usuario con todos sus atributos completos, de los datos obtenidos desde la BBDD
        ///</return>
        public List<Usuario> GetAll()
        {
            List<Usuario> result = new List<Usuario>();
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    result = context.Repository.UsuarioRepository.GetAll();
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return result;
        }
        ///<summary>
        ///Actualiza una Usuario
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la actualización fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_usuario">
        ///Objeto de tipo Usuario con todos sus atributos completos para ser actualizado en la BBDD
        ///</param>
        public int Update(Usuario _usuario)
        {
            int result = 0;
            try
            {
                UsuarioValidator validator = new UsuarioValidator();
                ValidationResult.Validation = validator.Validate(_usuario);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _unitOfWork.Create())
                    {
                        result = context.Repository.UsuarioRepository.Update(_usuario);
                        context.SaveChange();
                    }
                    ValidationResult.Status = StatusEnum.Ok;
                }
                else
                {
                    ValidationResult.Status = StatusEnum.Validation;
                }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return result;
        }
        ///<summary>
        ///Realiza un borrado suave sobre un registro de Usuario
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la actualización fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_id">
        ///Id de la Usuario para ser marcada como eliminada en la BBDD
        ///</param>
        ///<param name="_isEliminado">
        ///Valor del campo is_eliminado para ser actualizado en la BBDD
        ///</param>
        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            int result = 0;
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    result = context.Repository.UsuarioRepository.UpdateSoftDelete(_id, _isEliminado);
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return result;
        }
        ///<summary>
        ///Verifica si existe un NombreUsuario(username) para un Usuario en la BBDD
        ///</summary>
        ///<return>
        ///Devuelve verdadero si existe, o un falso si no existe.
        ///</return>
        ///<param name="_nombre">
        ///nombre (username) del Usuario a ser verificado en la BBDD
        ///</param>
        public bool IsExistNombreUsuario(string _nombre)
        {
            bool result = false;
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    result = context.Repository.UsuarioRepository.IsExistNombreUsuario(_nombre);
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return result;
        }
        ///<summary>
        ///Elimina una Usuario por su Id
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la eliminación fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_usuario">
        ///_usuario es el objeto de tipo Usuario con todos sus atributos para ser eliminado de la BBDD
        ///</param>
        public int Remove(Usuario _usuario)
        {
            int result = 0;
            try
            {
                UsuarioValidator validator = new UsuarioValidator();
                ValidationResult.Validation = validator.Validate(_usuario);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _unitOfWork.Create())
                    {
                        result = context.Repository.UsuarioRepository.Remove(_usuario);
                        context.SaveChange();
                    }
                    ValidationResult.Status = StatusEnum.Ok;
                }
                else
                {
                    ValidationResult.Status = StatusEnum.Validation;
                }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return result;
        }
        ///<summary>
        ///Autoriza usuario ingreso API
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la eliminación fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_usuario">
        ///_usuario es el objeto de tipo Usuario con todos sus atributos para ser eliminado de la BBDD
        ///</param>
        ///
        public int Auth(Usuario _usuario)
        {
            int result = 0;
            try
            {
               
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return result;
        }
    }
}
