using Models;
using Models.Common;
using Models.Enum;
using Models.PozosNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;

namespace Services.PozosNew
{
    public class PozoNewServices
    {
        private readonly IUnitOfWork _uniOfWork;
        public ValidationsFluent ValidationResult { get; }
        public PozoNewServices(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        /// <summary>
        /// Crea un Pozo
        /// </summary>
        /// <param name="_PozoNew">
        /// Objeto de tipo PozoNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Create(PozoNew _PozoNew)
        {
            try
            {
                PozoNewValidator PozoValidator = new PozoNewValidator();
                ValidationResult.Validation = PozoValidator.Validate(_PozoNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create()) { result = context.Repository.PozoNewRepository.Create(_PozoNew); context.SaveChange(); }
                    if (result > 0)
                    {
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Pozo registrado correctamente.";
                    }
                    return;
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
        /// <summary>
        /// Obtiene un PozoNew existente en la BBDD por el id
        /// </summary>
        /// <param name="_IdPozo">
        /// ID del PozoNew
        /// </param>
        /// <returns>Retorna un PozoNew</returns>
        public PozoNew GetById(int _IdPozo)
        {
            PozoNew Pozo = new PozoNew();
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    Pozo = context.Repository.PozoNewRepository.GetById(_IdPozo);
                }
                return Pozo;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los PozoNew existentes en la BBDD
        /// </summary>
        /// <returns>
        /// Devuelve un objeto lista de tipo PozoNew con todos sus Datos
        /// </returns>
        private List<PozoNew> GetAll()
        {
            try
            {
                List<PozoNew> PozoList = new List<PozoNew>();
                using (var context = _uniOfWork.Create())
                {
                    PozoList = context.Repository.PozoNewRepository.GetAll();
                }
                return PozoList;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los PozoNew no eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo PozoNew con todos sus Datos</returns>
        private List<PozoNew> GetAllNoEliminados()
        {
            try
            {
                List<PozoNew> PozoList = new List<PozoNew>();
                PozoList = GetAll();
                var Result = from PozoNew in PozoList
                             where PozoNew.isEliminado == false
                             select PozoNew;
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
        /// Obtiene una lista de todos los PozoNew eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo PozoNew con todos sus Datos</returns>
        private List<PozoNew> GetAllEliminados()
        {
            try
            {
                List<PozoNew> PozoList = new List<PozoNew>();
                PozoList = GetAll();
                var Result = from PozoNew in PozoList
                             where PozoNew.isEliminado == true
                             select PozoNew;
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
        /// Obtiene una lista de todos los PozoNew. Segun parametro indicado segun enumeracion.
        /// </summary>
        /// <param name="_operacion">Parametro seleccionado</param>
        /// <returns>Devuelve un objeto lista de PozoNew</returns>
        public List<PozoNew> GetAll(GetAll.GetAllEnum _operacion)
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
        /// Actualiza el PozoNew 
        /// </summary>
        /// <param name="_PozoNew">
        /// Objeto de tipo PozoNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Update(PozoNew _PozoNew)
        {

            try
            {
                PozoNewValidator PozoValidador = new PozoNewValidator();
                ValidationResult.Validation = PozoValidador.Validate(_PozoNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.PozoNewRepository.Update(_PozoNew);
                        context.SaveChange();
                    }
                    if (result > 0)
                    {
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Pozo actualizado correctamente.";
                    }

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
        /// Elimina un PozoNew
        /// </summary>
        /// <param name="_PozoNew">
        /// Objeto de tipo PozoNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Remove(PozoNew _PozoNew)
        {
            int result = 0;
            try
            {
                PozoNewValidator PozoValidator = new PozoNewValidator();
                ValidationResult.Validation = PozoValidator.Validate(_PozoNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.PozoNewRepository.Remove(_PozoNew.idPozo);
                        context.SaveChange();
                    }
                    if (result > 0) { ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok; }
                }
                else { ValidationResult.Status = Models.Enum.Status.StatusEnum.Validation; }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
        }
        /// <summary>
        /// Actualiza el campo is_eliminado de la base de datos.
        /// </summary>
        /// <param name="_IdPozo">ID del PozoNew a actualiza</param>
        /// <param name="_isEliminado">parametro a actualizar</param>
        public void UpdateIsEliminado(int _IdPozo, Boolean _isEliminado)
        {
            try
            {
                int result = 0;
                using (var context = _uniOfWork.Create())
                {
                    result = context.Repository.PozoNewRepository.UpdateSoftDelete(_IdPozo, _isEliminado);
                    context.SaveChange();
                }
                if (result > 0)
                { ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok; ValidationResult.Message = "Pozo eliminado correctamente."; }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
        }
    }
}
