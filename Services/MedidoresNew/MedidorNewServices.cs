using Models;
using Models.Common;
using Models.MedidoresNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;
using static Models.Enum.Status;

namespace Services.MedidoresNew
{
    public class MedidorNewServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ValidationsFluent ValidationResult;
        public MedidorNewServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        ///<summary>
        ///Crea un nuevo medidor
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la creación fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_MedidorNew">
        ///Objeto de tipo MedidorNew con todos sus atributos completos para ser insertado en la BBDD
        ///</param>
        public int Create(MedidorNew _medidorNew)
        {
            int result = 0;
            try
            {
                MedidorNewValidator validator = new MedidorNewValidator();
                ValidationResult.Validation = validator.Validate(_medidorNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _unitOfWork.Create())
                    {
                        result = context.Repository.MedidorNewRepository.Create(_medidorNew);
                        context.SaveChange();
                    }
                    ValidationResult.Status = StatusEnum.Ok;
                    ValidationResult.Message = "MedidorNew registrado correctamente.";
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
        ///Obtiene un medidor por su Id
        ///</summary>
        ///<return>
        ///Devuelve un objeto de tipo MedidorNew con todos sus atributos completos, de los datos obtenidos desde la BBDD
        ///</return>
        ///<param name="_id">
        ///Id del medidor a obtener
        ///</param>
        public MedidorNew GetById(int _id)
        {
            var _medidorNew = new MedidorNew();
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    _medidorNew = context.Repository.MedidorNewRepository.GetById(_id);
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return _medidorNew;
        }
        ///<summary>
        ///Obtiene una lista de todos los medidores existentes en la BBDD
        ///</summary>
        ///<return>
        ///Devuelve un objeto lista de tipo MedidorNew con todos sus atributos completos, de los datos obtenidos desde la BBDD
        ///</return>
        public List<MedidorNew> GetAll()
        {
            List<MedidorNew> _medidorNew = new List<MedidorNew>();
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    _medidorNew = context.Repository.MedidorNewRepository.GetAll();
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return _medidorNew;
        }
        ///<summary>
        ///Elimina un medidor por su Id
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la eliminación fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_medidorNew">
        ///_medidorNew es el objeto de tipo MedidorNew con todos sus atributos para ser eliminado de la BBDD
        ///</param>
        public int Remove(MedidorNew _medidorNew)
        {
            int result = 0;
            try
            {
                MedidorNewValidator validator = new MedidorNewValidator();
                ValidationResult.Validation = validator.Validate(_medidorNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _unitOfWork.Create())
                    {
                        result = context.Repository.MedidorNewRepository.Remove(_medidorNew);
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
        ///Actualiza un medidor
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la actualización fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_MedidorNew">
        ///Objeto de tipo MedidorNew con todos sus atributos completos para ser actualizado en la BBDD
        ///</param>
        public int Update(MedidorNew _medidorNew)
        {
            int result = 0;
            try
            {
                MedidorNewValidator validator = new MedidorNewValidator();
                ValidationResult.Validation = validator.Validate(_medidorNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _unitOfWork.Create())
                    {
                        result = context.Repository.MedidorNewRepository.Update(_medidorNew);
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
        ///Realiza un borrado suave sobre un registro de MedidorNew
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la actualización fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_id">
        ///Id del MedidorNew para ser marcado como eliminado en la BBDD
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
                    result = context.Repository.MedidorNewRepository.UpdateSoftDelete(_id, _isEliminado);
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
        ///Verifica si existe un numero de medidor para un medidor en la BBDD
        ///</summary>
        ///<return>
        ///Devuelve verdadero si existe, o un falso si no existe.
        ///</return>
        ///<param name="_numeroMedidorNew">
        ///numero del medidor a ser verificado en la BBDD
        ///</param>
        public bool IsExistNumeroMedidorNew(string _numeroMedidorNew)
        {
            bool result = false;
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    result = context.Repository.MedidorNewRepository.IsExistNumeroMedidorNew(_numeroMedidorNew);
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
