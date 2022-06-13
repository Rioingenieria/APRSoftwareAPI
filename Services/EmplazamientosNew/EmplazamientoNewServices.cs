using Models;
using Models.Common;
using Models.EmplazamientosNew;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;

namespace Services.EmplazamientosNew
{
    public class EmplazamientoNewServices
    {
        private readonly IUnitOfWork _uniOfWork;
        public ValidationsFluent ValidationResult { get; }
        public EmplazamientoNewServices(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        /// <summary>
        /// Crea un Emplazamiento
        /// </summary>
        /// <param name="_EmplazamientoNew">
        /// Objeto de tipo EmplazamientoNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Create(EmplazamientoNew _EmplazamientoNew)
        {
            try
            {
                EmplazamientoNewValidator validator = new EmplazamientoNewValidator();
                ValidationResult.Validation = validator.Validate(_EmplazamientoNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create()) { result = context.Repository.EmplazamientoNewRepository.Create(_EmplazamientoNew); context.SaveChange(); }
                    if (result > 0)
                    {
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Emplazamiento registrado correctamente.";
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
        /// Obtiene un EmplazamientoNew existente en la BBDD por el id
        /// </summary>
        /// <param name="_IdEmplazamiento">
        /// ID del EmplazamientoNew
        /// </param>
        /// <returns>Retorna un EmplazamientoNew</returns>
        public EmplazamientoNew GetById(int _IdEmplazamiento)
        {
            EmplazamientoNew Emplazamiento = new EmplazamientoNew();
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    Emplazamiento = context.Repository.EmplazamientoNewRepository.GetById(_IdEmplazamiento);
                }
                return Emplazamiento;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los EmplazamientoNew existentes en la BBDD
        /// </summary>
        /// <returns>
        /// Devuelve un objeto lista de tipo EmplazamientoNew con todos sus Datos
        /// </returns>
        private List<EmplazamientoNew> GetAll()
        {
            try
            {
                List<EmplazamientoNew> EmplazamientoList = new List<EmplazamientoNew>();
                using (var context = _uniOfWork.Create())
                {
                    EmplazamientoList = context.Repository.EmplazamientoNewRepository.GetAll();
                }
                return EmplazamientoList;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los EmplazamientoNew no eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo EmplazamientoNew con todos sus Datos</returns>
        private List<EmplazamientoNew> GetAllNoEliminados()
        {
            try
            {
                List<EmplazamientoNew> EmplazamientoList = new List<EmplazamientoNew>();
                EmplazamientoList = GetAll();
                var Result = from EmplazamientoNew in EmplazamientoList
                             where EmplazamientoNew.isEliminado == false
                             select EmplazamientoNew;
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
        /// Obtiene una lista de todos los EmplazamientoNew eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo EmplazamientoNew con todos sus Datos</returns>
        private List<EmplazamientoNew> GetAllEliminados()
        {
            try
            {
                List<EmplazamientoNew> EmplazamientoList = new List<EmplazamientoNew>();
                EmplazamientoList = GetAll();
                var Result = from EmplazamientoNew in EmplazamientoList
                             where EmplazamientoNew.isEliminado == true
                             select EmplazamientoNew;
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
        /// Obtiene una lista de todos los EmplazamientoNew. Segun parametro indicado segun enumeracion.
        /// </summary>
        /// <param name="_operacion">Parametro seleccionado</param>
        /// <returns>Devuelve un objeto lista de EmplazamientoNew</returns>
        public List<EmplazamientoNew> GetAll(GetAll.GetAllEnum _operacion)
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
        /// Actualiza el EmplazamientoNew 
        /// </summary>
        /// <param name="_EmplazamientoNew">
        /// Objeto de tipo EmplazamientoNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Update(EmplazamientoNew _EmplazamientoNew)
        {

            try
            {
                EmplazamientoNewValidator EmplazamientoValidador = new EmplazamientoNewValidator();
                ValidationResult.Validation = EmplazamientoValidador.Validate(_EmplazamientoNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.EmplazamientoNewRepository.Update(_EmplazamientoNew);
                        context.SaveChange();
                    }
                    if (result > 0)
                    {
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Emplazamiento actualizado correctamente.";
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
        /// Elimina un EmplazamientoNew
        /// </summary>
        /// <param name="_EmplazamientoNew">
        /// Objeto de tipo EmplazamientoNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Remove(EmplazamientoNew _EmplazamientoNew)
        {
            int result = 0;
            try
            {
                EmplazamientoNewValidator validator = new EmplazamientoNewValidator();
                ValidationResult.Validation = validator.Validate(_EmplazamientoNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.EmplazamientoNewRepository.Remove(_EmplazamientoNew.idEmplazamiento);
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
        /// <param name="_IdEmplazamiento">ID del EmplazamientoNew a actualiza</param>
        /// <param name="_isEliminado">parametro a actualizar</param>
        public void UpdateIsEliminado(int _IdEmplazamiento, Boolean _isEliminado)
        {
            try
            {
                int result = 0;
                using (var context = _uniOfWork.Create())
                {
                    result = context.Repository.EmplazamientoNewRepository.UpdateSoftDelete(_IdEmplazamiento, _isEliminado);
                    context.SaveChange();
                }
                if (result > 0)
                { ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok; ValidationResult.Message = "Emplazamiento eliminado correctamente."; }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
        }
    }
}
