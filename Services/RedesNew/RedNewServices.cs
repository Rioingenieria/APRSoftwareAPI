using Models;
using Models.Common;
using Models.Enum;
using Models.RedesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;

namespace Services.RedesNew
{
    public class RedNewServices
    {
        private readonly IUnitOfWork _uniOfWork;
        public ValidationsFluent ValidationResult { get; }
        public RedNewServices(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        /// <summary>
        /// Crea un Red
        /// </summary>
        /// <param name="_RedNew">
        /// Objeto de tipo RedNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Create(RedNew _RedNew)
        {
            try
            {
                RedNewValidator validator = new RedNewValidator();
                ValidationResult.Validation = validator.Validate(_RedNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create()) { result = context.Repository.RedNewRepository.Create(_RedNew); context.SaveChange(); }
                    if (result > 0)
                    {
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Red registrado correctamente.";
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
        /// Obtiene un RedNew existente en la BBDD por el id
        /// </summary>
        /// <param name="_IdRed">
        /// ID del RedNew
        /// </param>
        /// <returns>Retorna un RedNew</returns>
        public RedNew GetById(int _IdRed)
        {
            RedNew Red = new RedNew();
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    Red = context.Repository.RedNewRepository.GetById(_IdRed);
                }
                return Red;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los RedNew existentes en la BBDD
        /// </summary>
        /// <returns>
        /// Devuelve un objeto lista de tipo RedNew con todos sus Datos
        /// </returns>
        private List<RedNew> GetAll()
        {
            try
            {
                List<RedNew> RedList = new List<RedNew>();
                using (var context = _uniOfWork.Create())
                {
                    RedList = context.Repository.RedNewRepository.GetAll();
                }
                return RedList;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los RedNew no eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo RedNew con todos sus Datos</returns>
        private List<RedNew> GetAllNoEliminados()
        {
            try
            {
                List<RedNew> RedList = new List<RedNew>();
                RedList = GetAll();
                var Result = from RedNew in RedList
                             where RedNew.isEliminado == false
                             select RedNew;
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
        /// Obtiene una lista de todos los RedNew eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo RedNew con todos sus Datos</returns>
        private List<RedNew> GetAllEliminados()
        {
            try
            {
                List<RedNew> RedList = new List<RedNew>();
                RedList = GetAll();
                var Result = from RedNew in RedList
                             where RedNew.isEliminado == true
                             select RedNew;
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
        /// Obtiene una lista de todos los RedNew. Segun parametro indicado segun enumeracion.
        /// </summary>
        /// <param name="_operacion">Parametro seleccionado</param>
        /// <returns>Devuelve un objeto lista de RedNew</returns>
        public List<RedNew> GetAll(GetAll.GetAllEnum _operacion)
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
        /// Actualiza el RedNew 
        /// </summary>
        /// <param name="_RedNew">
        /// Objeto de tipo RedNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Update(RedNew _RedNew)
        {

            try
            {
                RedNewValidator RedValidador = new RedNewValidator();
                ValidationResult.Validation = RedValidador.Validate(_RedNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.RedNewRepository.Update(_RedNew);
                        context.SaveChange();
                    }
                    if (result > 0)
                    {
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Red actualizado correctamente.";
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
        /// Elimina un RedNew
        /// </summary>
        /// <param name="_RedNew">
        /// Objeto de tipo RedNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Remove(RedNew _RedNew)
        {
            int result = 0;
            try
            {
                RedNewValidator validator = new RedNewValidator();
                ValidationResult.Validation = validator.Validate(_RedNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.RedNewRepository.Remove(_RedNew.idRed);
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
        /// <param name="_IdRed">ID del RedNew a actualiza</param>
        /// <param name="_isEliminado">parametro a actualizar</param>
        public void UpdateIsEliminado(int _IdRed, Boolean _isEliminado)
        {
            try
            {
                int result = 0;
                using (var context = _uniOfWork.Create())
                {
                    result = context.Repository.RedNewRepository.UpdateSoftDelete(_IdRed, _isEliminado);
                    context.SaveChange();
                }
                if (result > 0)
                { ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok; ValidationResult.Message = "Red eliminado correctamente."; }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
        }
    }
}
