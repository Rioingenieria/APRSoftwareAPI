using Models;
using Models.Common;
using Models.Enum;
using Models.Inventory.BodegasNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface.IUnitOfWorkInventario;
using static Models.Enum.Status;

namespace Services.Inventory.BodegasNew
{
    public class BodegaNewServices
    {
        private readonly IUnitOfWorkInventario _uniOfWork;
        public ValidationsFluent ValidationResult { get; }
        public BodegaNewServices(IUnitOfWorkInventario unitOfWork)
        {
            _uniOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        ///<summary>
        ///Crea un nuevo registro en la tabla bodegas
        ///</summary>
        ///<param name="_bodegasNew">
        ///Objeto de tipo BodegaNew con todos sus atributos completos para ser insertado en la BBDD
        ///</param>
        public int Create(BodegaNew _bodegasNew)
        {
            int result = 0;
            try
            {

                BodegasNewValidator bodegaValidador = new BodegasNewValidator();
                ValidationResult.Validation = bodegaValidador.Validate(_bodegasNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        if (context.Repository.BodegaNewRepository.IsExistNombreBodega(_bodegasNew.Nombre))
                        {
                            ValidationResult.Status = Models.Enum.Status.StatusEnum.Existence;
                            ValidationResult.Message = "Ya existe bodega con nombre " + _bodegasNew.Nombre + ".";
                            return result;
                        }
                        result = context.Repository.BodegaNewRepository.Create(_bodegasNew);
                        context.SaveChange();
                    }
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                    ValidationResult.Message = "BodegaNew registrada correctamente.";
                }
                else
                {
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Validation;
                    return result;
                }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return result;
            }
            return result;
        }
        ///<summary>
        ///Obtiene una bodega por su Id.
        ///</summary>
        ///<return>
        ///Devuelve un objeto de tipo BodegaNew con todos sus atributos correspondiente al registro de la BBDD
        ///</return>
        ///<param name="_IdBodegaNew">
        ///Id de la bodega a obtener.
        ///</param>
        public BodegaNew GetById(int _IdBodegaNew)
        {
            BodegaNew bodega = new BodegaNew();
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    bodega = context.Repository.BodegaNewRepository.GetById(_IdBodegaNew);
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
            return bodega;
        }
        ///<summary>
        ///Obtiene una lista de todas las bodegas de la BBDD
        ///</summary>
        ///<return>
        ///Devuelve un objeto lista de bodegas.
        ///</return>
        private List<BodegaNew> GetAll()
        {
            List<BodegaNew> listaBodegasNew = new List<BodegaNew>();
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    listaBodegasNew = context.Repository.BodegaNewRepository.GetAll();
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return listaBodegasNew;
        }
        ///<summary>
        ///Obtiene una lista de todas las bodegas no eliminadas de la BBDD 
        ///</summary>
        ///<return>
        ///Devuelve un objeto lista de bodegas.
        ///</return>
        private List<BodegaNew> GetAllNoEliminados()
        {
            List<BodegaNew> listaBodegasNews = new List<BodegaNew>();
            try
            {                
                listaBodegasNews = GetAll();
                var result = from bodega in listaBodegasNews
                             where bodega.IsEliminado == false
                             select bodega;
                return result.ToList();
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        ///<summary>
        ///Obtiene una lista de todas las bodegas eliminadas de la BBDD 
        ///</summary>
        ///<return>
        ///Devuelve un objeto lista de bodegas.
        ///</return>
        private List<BodegaNew> GetAllEliminados()
        {
            try
            {
                List<BodegaNew> listaBodegasNews = new List<BodegaNew>();
                listaBodegasNews = GetAll();
                var result = from bodega in listaBodegasNews
                             where bodega.IsEliminado == true
                             select bodega;
                return result.ToList();
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        ///<summary>
        ///Obtiene una lista de todas las bodegas. Segun parametro indicado segun enumeracion.
        ///</summary>
        ///<return>
        ///Devuelve un objeto lista de bodegas.
        ///</return>
        public List<BodegaNew> GetAll(GetAll.GetAllEnum _operacion)
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
        /// <summary>
        /// Actualiza un registro de bodega en la base de datos
        /// </summary>
        /// <param name="_bodegasNew"></param>
        public int Update(BodegaNew _bodegasNew)
        {
            int result = 0;
            try
            {
                BodegasNewValidator bodegaValidador = new BodegasNewValidator();
                ValidationResult.Validation = bodegaValidador.Validate(_bodegasNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.BodegaNewRepository.Update(_bodegasNew);
                        context.SaveChange();
                    }
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                    ValidationResult.Message = "Bodega actualizada correctamente.";
                }
                else
                {
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Validation;
                }
                return result;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return result;
            }
        }
        /// <summary>
        /// Actualiza estado IsEliminado de tabla bodegas
        /// </summary>
        /// <param name="_bodegasNew"></param>
        public int UpdateIsEliminado(int _idBodegaNew, Boolean _isEliminado)
        {
            int result = 0;
            try
            {

                using (var context = _uniOfWork.Create())
                {
                    result = context.Repository.BodegaNewRepository.UpdateSoftDelete(_idBodegaNew, _isEliminado);
                    context.SaveChange();
                }
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                ValidationResult.Message = "BodegaNew eliminada correctamente.";
                return result;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return result;
            }
        }
        ///<summary>
        ///Verifica si existe un nombre de bodega para un bodega en la BBDD
        ///</summary>
        ///<return>
        ///Devuelve verdadero si existe, o un falso si no existe.
        ///</return>
        ///<param name="_nombreBodegaNew">
        ///nombre del bodega a ser verificado en la BBDD
        ///</param>
        public bool IsExistNombreBodegaNew(string _nombreBodegaNew)
        {
            bool result = false;
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    result = context.Repository.BodegaNewRepository.IsExistNombreBodega(_nombreBodegaNew);
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
                return result;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
                return result;
            }            
        }
        ///<summary>
        ///Elimina un bodega por su Id
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la eliminación fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_bodegasNew">
        ///_bodegasNew es el objeto de tipo BodegaNew con todos sus atributos para ser eliminado de la BBDD
        ///</param>
        public int Remove(BodegaNew _bodegasNew)
        {
            int result = 0;
            try
            {
                BodegasNewValidator validator = new BodegasNewValidator();
                ValidationResult.Validation = validator.Validate(_bodegasNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.BodegaNewRepository.Remove(_bodegasNew);
                        context.SaveChange();
                    }
                    ValidationResult.Status = StatusEnum.Ok;
                }
                else
                {
                    ValidationResult.Status = StatusEnum.Validation;
                }
                return result;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
                return result;
            }
        }
    }
}
