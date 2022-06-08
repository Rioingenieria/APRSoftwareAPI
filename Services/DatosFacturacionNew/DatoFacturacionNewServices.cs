using Models;
using Models.Common;
using Models.DatosFacturacionNew;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;
using static Models.Enum.Status;

namespace Services.DatoFacturacionNewNew
{
    public class DatoFacturacionNewServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ValidationsFluent ValidationResult;
        public DatoFacturacionNewServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        ///<summary>
        ///Crea un nuevo dato de facturación
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la creación fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_DatoFacturacionNew">
        ///Objeto de tipo DatosFacturación con todos sus atributos completos para ser insertado en la BBDD
        ///</param>
        public int Create(DatoFacturacionNew _DatoFacturacionNew)
        {
            int result = 0;
            try
            {
                DatoFacturacionNewValidator validator = new DatoFacturacionNewValidator();
                ValidationResult.Validation = validator.Validate(_DatoFacturacionNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _unitOfWork.Create())
                    {
                        result = context.Repository.DatoFacturacionNewRepository.Create(_DatoFacturacionNew);
                        context.SaveChange();
                    }
                    ValidationResult.Status = StatusEnum.Ok;
                    ValidationResult.Message = "Dato de facturación registrado correctamente.";
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
        ///Obtiene un dato de facturación por su Id
        ///</summary>
        ///<return>
        ///Devuelve un objeto de tipo DatoFacturacionNew con todos sus atributos completos, de los datos obtenidos desde la BBDD
        ///</return>
        ///<param name="_id">
        ///Id del dato de facturación a obtener
        ///</param>
        public DatoFacturacionNew GetById(int _id)
        {
            var _DatoFacturacionNew = new DatoFacturacionNew();
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    _DatoFacturacionNew = context.Repository.DatoFacturacionNewRepository.GetById(_id);
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return _DatoFacturacionNew;
        }
        ///<summary>
        ///Obtiene una lista de todos los datos de facturación existentes en la BBDD
        ///</summary>
        ///<return>
        ///Devuelve un objeto lista de tipo DatoFacturacionNew con todos sus atributos completos, de los datos obtenidos desde la BBDD
        ///</return>
        public List<DatoFacturacionNew> GetAll()
        {
            List<DatoFacturacionNew> _DatoFacturacionNew = new List<DatoFacturacionNew>();
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    _DatoFacturacionNew = context.Repository.DatoFacturacionNewRepository.GetAll();
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return _DatoFacturacionNew;
        }
        /// <summary>
        /// Obtiene una lista de todos los DatoFacturacionNew no eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo DatoFacturacionNew con todos sus Datos</returns>
        private List<DatoFacturacionNew> GetAllNoEliminados()
        {
            try
            {
                List<DatoFacturacionNew> datoFacturacionList = new List<DatoFacturacionNew>();
                datoFacturacionList = GetAll();
                var Result = from DatoFacturacionNew in datoFacturacionList
                             where DatoFacturacionNew.isEliminado == false
                             select DatoFacturacionNew;
                return Result.ToList();
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los DatoFacturacionNew eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo DatoFacturacionNew con todos sus Datos</returns>
        private List<DatoFacturacionNew> GetAllEliminados()
        {
            try
            {
                List<DatoFacturacionNew> datoFacturacionList = new List<DatoFacturacionNew>();
                datoFacturacionList = GetAll();
                var Result = from DatoFacturacionNew in datoFacturacionList
                             where DatoFacturacionNew.isEliminado == true
                             select DatoFacturacionNew;
                return Result.ToList();
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los ProductoCategoriaNew. Segun parametro indicado segun enumeracion.
        /// </summary>
        /// <param name="_operacion">Parametro seleccionado</param>
        /// <returns>Devuelve un objeto lista de ProductoCategoriaNew</returns>
        public List<DatoFacturacionNew> GetAll(GetAll.GetAllEnum _operacion)
        {
            try
            {
                switch (_operacion)
                {
                    case Models.Enum.GetAll.GetAllEnum.NoEliminados:
                        return GetAllNoEliminados();
                    case Models.Enum.GetAll.GetAllEnum.Eliminados:
                        return GetAllEliminados();
                    case Models.Enum.GetAll.GetAllEnum.Todos:
                        return GetAll();
                    default:
                        return null;
                }

            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        ///<summary>
        ///Elimina un dato de facturación por su Id
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la eliminación fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_DatoFacturacionNew">
        ///_DatoFacturacionNew es el objeto de tipo DatosFacturación con todos sus atributos para ser eliminado de la BBDD
        ///</param>
        public int Remove(DatoFacturacionNew _DatoFacturacionNew)
        {
            int result = 0;
            try
            {
                DatoFacturacionNewValidator validator = new DatoFacturacionNewValidator();
                ValidationResult.Validation = validator.Validate(_DatoFacturacionNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _unitOfWork.Create())
                    {
                        result = context.Repository.DatoFacturacionNewRepository.Remove(_DatoFacturacionNew);
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
        ///Actualiza un dato de facturación
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la actualización fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_DatoFacturacionNew">
        ///Objeto de tipo DatosFacturación con todos sus atributos completos para ser actualizado en la BBDD
        ///</param>
        public int Update(DatoFacturacionNew _DatoFacturacionNew)
        {
            int result = 0;
            try
            {
                DatoFacturacionNewValidator validator = new DatoFacturacionNewValidator();
                ValidationResult.Validation = validator.Validate(_DatoFacturacionNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _unitOfWork.Create())
                    {
                        result = context.Repository.DatoFacturacionNewRepository.Update(_DatoFacturacionNew);
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
        ///Realiza un borrado suave sobre un registro de DatoFacturacionNew
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la actualización fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_id">
        ///Id del DatoFacturacionNew para ser marcado como eliminado en la BBDD
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
                    result = context.Repository.DatoFacturacionNewRepository.UpdateSoftDelete(_id, _isEliminado);
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
        ///Verifica si existe una Razón Social para un DatoFacturacion en la BBDD
        ///</summary>
        ///<return>
        ///Devuelve verdadero si existe, o un falso si no existe.
        ///</return>
        ///<param name="_razonSocial">
        ///Razón Social del DatoFacturacion a ser verificada en la BBDD
        ///</param>
        public bool IsExistRazonSocial(string _razonSocial)
        {
            bool result = false;
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    result = context.Repository.DatoFacturacionNewRepository.IsExistRazonSocial(_razonSocial);
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
    }
}
