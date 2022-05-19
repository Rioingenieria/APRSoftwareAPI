using Models;
using Models.Common;
using Models.Enum;
using Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface.IUnitOfWorkInventario;
using static Models.Enum.Status;

namespace Services.Inventory
{
    public class BodegaServices
    {
        private readonly IUnitOfWorkInventario _uniOfWork;
        public ValidationsFluent ValidationResult { get; }
        public BodegaServices(IUnitOfWorkInventario unitOfWork)
        {
            _uniOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        ///<summary>
        ///Crea un nuevo registro en la tabla bodegas
        ///</summary>
        ///<param name="_bodega">
        ///Objeto de tipo Bodega con todos sus atributos completos para ser insertado en la BBDD
        ///</param>
        public void Create(Bodega _bodega)
        {
            try
            {
      
                BodegaValidador bodegaValidador = new BodegaValidador();
                ValidationResult.Validation = bodegaValidador.Validate(_bodega);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        if (context.Repository.BodegaRepository.IsExistNombreBodega(_bodega.Nombre))
                        {
                            ValidationResult.Status = Models.Enum.Status.StatusEnum.Existence;
                            ValidationResult.Message = "Ya existe bodega con nombre " + _bodega.Nombre + ".";
                            return;
                        }
                        context.Repository.BodegaRepository.Create(_bodega);
                        context.SaveChange();
                    }
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                    ValidationResult.Message = "Bodega registrada correctamente.";
                }
                else
                {
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Validation;
                    return;
                }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return;
            }
        }
        ///<summary>
        ///Obtiene una bodega por su Id.
        ///</summary>
        ///<return>
        ///Devuelve un objeto de tipo Bodega con todos sus atributos correspondiente al registro de la BBDD
        ///</return>
        ///<param name="_IdBodega">
        ///Id de la bodega a obtener.
        ///</param>
        public Bodega GetById(int _IdBodega)
        {
            Bodega bodega = new Bodega();
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    bodega =  context.Repository.BodegaRepository.GetById(_IdBodega);
                }
                return bodega;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        ///<summary>
        ///Obtiene una lista de todas las bodegas de la BBDD
        ///</summary>
        ///<return>
        ///Devuelve un objeto lista de bodegas.
        ///</return>
        private List<Bodega> GetAll()
        {
            try
            {
                List<Bodega> Bodegas = new List<Bodega>();
                using (var context = _uniOfWork.Create())
                {
                    Bodegas = context.Repository.BodegaRepository.GetAll();
                }
                return Bodegas;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        ///<summary>
        ///Obtiene una lista de todas las bodegas no eliminadas de la BBDD 
        ///</summary>
        ///<return>
        ///Devuelve un objeto lista de bodegas.
        ///</return>
        private List<Bodega> GetAllNoEliminados()
        {
            try
            {
                List<Bodega> Bodegas = new List<Bodega>();
                Bodegas = GetAll();
                var Result = from bodega in Bodegas
                             where bodega.IsEliminado == false
                             select bodega;
                return Result.ToList();
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
        private List<Bodega> GetAllEliminados()
        {
            try
            {
                List<Bodega> Bodegas = new List<Bodega>();
                Bodegas = GetAll();
                var Result = from bodega in Bodegas
                             where bodega.IsEliminado == true
                             select bodega;
                return Result.ToList();
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
        public List<Bodega> GetAll(GetAll.GetAllEnum _operacion)
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
        /// <param name="_bodega"></param>
        public void Update(Bodega _bodega)
        {
            try
            {
                BodegaValidador bodegaValidador = new BodegaValidador();
                ValidationResult.Validation = bodegaValidador.Validate(_bodega);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        context.Repository.BodegaRepository.Update(_bodega);
                        context.SaveChange();
                    }
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                    ValidationResult.Message = "Bodega actualizada correctamente.";
                }
                else
                {
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Validation;
                    return;
                }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
        }
        /// <summary>
        /// Actualiza estado IsEliminado de tabla bodegas
        /// </summary>
        /// <param name="_bodega"></param>
        public void UpdateIsEliminado(int _idBodega, Boolean _isEliminado)
        {
            try
            {

                using (var context = _uniOfWork.Create())
                {
                    context.Repository.BodegaRepository.UpdateSoftDelete(_idBodega, _isEliminado);
                    context.SaveChange();
                }
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                ValidationResult.Message = "Bodega eliminada correctamente.";

            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
        }
        ///<summary>
        ///Verifica si existe un nombre de bodega para un bodega en la BBDD
        ///</summary>
        ///<return>
        ///Devuelve verdadero si existe, o un falso si no existe.
        ///</return>
        ///<param name="_nombreBodega">
        ///nombre del bodega a ser verificado en la BBDD
        ///</param>
        public bool IsExistNombreBodega(string _nombreBodega)
        {
            bool result = false;
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    result = context.Repository.BodegaRepository.IsExistNombreBodega(_nombreBodega);
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
        ///Elimina un bodega por su Id
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la eliminación fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_bodega">
        ///_bodega es el objeto de tipo Bodega con todos sus atributos para ser eliminado de la BBDD
        ///</param>
        public int Remove(Bodega _bodega)
        {
            int result = 0;
            try
            {
                BodegaValidador validator = new BodegaValidador();
                ValidationResult.Validation = validator.Validate(_bodega);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.BodegaRepository.Remove(_bodega);
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
