using Models;
using Models.Common;
using Models.ConfiguracionesFacturaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;
using static Models.Enum.Status;

namespace Services.ConfiguracionesFacturaciones
{
    public class ConfiguracionFacturacionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ValidationsFluent ValidationResult { get; }
        public ConfiguracionFacturacionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        ///<summary>
        ///Crea un nuevo ConfiguracionFacturacion
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la creación fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_configuracionFacturacion">
        ///Objeto de tipo ConfiguracionFacturacion con todos sus atributos completos para ser insertado en la BBDD
        ///</param>
        public int Create(ConfiguracionFacturacion _configuracionFacturacion)
        {
            int result = 0;
            try
            {
                ConfiguracionFacturacionValidator validator = new ConfiguracionFacturacionValidator();
                ValidationResult.Validation = validator.Validate(_configuracionFacturacion);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _unitOfWork.Create())
                    {
                        result = context.Repository.ConfiguracionFacturacionRepository.Create(_configuracionFacturacion);
                        context.SaveChange();
                    }
                    ValidationResult.Status = StatusEnum.Ok;
                    ValidationResult.Message = "ConfiguracionFacturacion registrada correctamente.";
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
        ///Obtiene un ConfiguracionFacturacion por su Id
        ///</summary>
        ///<return>
        ///Devuelve un objeto de tipo ConfiguracionFacturacion con todos sus atributos completos, de los datos obtenidos desde la BBDD
        ///</return>
        ///<param name="_id">
        ///Id del ConfiguracionFacturacion a obtener
        ///</param>
        public ConfiguracionFacturacion GetById(int _id)
        {
            var _configuracionFacturacion = new ConfiguracionFacturacion();
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    _configuracionFacturacion = context.Repository.ConfiguracionFacturacionRepository.GetById(_id);
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return _configuracionFacturacion;
        }
        ///<summary>
        ///Obtiene una lista de todos los clientes_otros existentes en la BBDD
        ///</summary>
        ///<return>
        ///Devuelve un objeto lista de tipo ConfiguracionFacturacion con todos sus atributos completos, de los datos obtenidos desde la BBDD
        ///</return>
        public List<ConfiguracionFacturacion> GetAll()
        {
            List<ConfiguracionFacturacion> result = new List<ConfiguracionFacturacion>();
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    result = context.Repository.ConfiguracionFacturacionRepository.GetAll();
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
        ///Actualiza una ConfiguracionFacturacion
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la actualización fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_configuracionFacturacion">
        ///Objeto de tipo ConfiguracionFacturacion con todos sus atributos completos para ser actualizado en la BBDD
        ///</param>
        public int Update(ConfiguracionFacturacion _configuracionFacturacion)
        {
            int result = 0;
            try
            {
                ConfiguracionFacturacionValidator validator = new ConfiguracionFacturacionValidator();
                ValidationResult.Validation = validator.Validate(_configuracionFacturacion);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _unitOfWork.Create())
                    {
                        result = context.Repository.ConfiguracionFacturacionRepository.Update(_configuracionFacturacion);
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
        ///Realiza un borrado suave sobre un registro de ConfiguracionFacturacion
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la actualización fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_id">
        ///Id de la ConfiguracionFacturacion para ser marcada como eliminada en la BBDD
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
                    result = context.Repository.ConfiguracionFacturacionRepository.UpdateSoftDelete(_id, _isEliminado);
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
        ///Verifica si existe un NombreUsuario(username) para un ConfiguracionFacturacion en la BBDD
        ///</summary>
        ///<return>
        ///Devuelve verdadero si existe, o un falso si no existe.
        ///</return>
        ///<param name="_idUsuario">
        ///nombre (username) del ConfiguracionFacturacion a ser verificado en la BBDD
        ///</param>
        public bool IsExistIdUsuario(int _idUsuario)
        {
            bool result = false;
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    result = context.Repository.ConfiguracionFacturacionRepository.IsExistIdUsuario(_idUsuario);
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
        ///Elimina una ConfiguracionFacturacion por su Id
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la eliminación fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_configuracionFacturacion">
        ///_configuracionFacturacion es el objeto de tipo ConfiguracionFacturacion con todos sus atributos para ser eliminado de la BBDD
        ///</param>
        public int Remove(ConfiguracionFacturacion _configuracionFacturacion)
        {
            int result = 0;
            try
            {
                ConfiguracionFacturacionValidator validator = new ConfiguracionFacturacionValidator();
                ValidationResult.Validation = validator.Validate(_configuracionFacturacion);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _unitOfWork.Create())
                    {
                        result = context.Repository.ConfiguracionFacturacionRepository.Remove(_configuracionFacturacion);
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
    }
}
