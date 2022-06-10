using Models;
using Models.Common;
using Models.Enum;
using Models.MatricesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;

namespace Services.MatricesNew
{
    public class MatrizNewServices
    {
        private readonly IUnitOfWork _uniOfWork;
        public ValidationsFluent ValidationResult { get; }
        public MatrizNewServices(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        /// <summary>
        /// Crea un Matriz
        /// </summary>
        /// <param name="_MatrizNew">
        /// Objeto de tipo MatrizNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Create(MatrizNew _MatrizNew)
        {
            try
            {
                MatrizNewValidator ProductValidator = new MatrizNewValidator();
                ValidationResult.Validation = ProductValidator.Validate(_MatrizNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create()) { result = context.Repository.MatrizNewRepository.Create(_MatrizNew); context.SaveChange(); }
                    if (result > 0)
                    {
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Matriz registrado correctamente.";
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
        /// Obtiene un MatrizNew existente en la BBDD por el id
        /// </summary>
        /// <param name="_IdMatriz">
        /// ID del MatrizNew
        /// </param>
        /// <returns>Retorna un MatrizNew</returns>
        public MatrizNew GetById(int _IdMatriz)
        {
            MatrizNew Matriz = new MatrizNew();
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    Matriz = context.Repository.MatrizNewRepository.GetById(_IdMatriz);
                }
                return Matriz;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los MatrizNew existentes en la BBDD
        /// </summary>
        /// <returns>
        /// Devuelve un objeto lista de tipo MatrizNew con todos sus Datos
        /// </returns>
        private List<MatrizNew> GetAll()
        {
            try
            {
                List<MatrizNew> matrizList = new List<MatrizNew>();
                using (var context = _uniOfWork.Create())
                {
                    matrizList = context.Repository.MatrizNewRepository.GetAll();
                }
                return matrizList;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los MatrizNew no eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo MatrizNew con todos sus Datos</returns>
        private List<MatrizNew> GetAllNoEliminados()
        {
            try
            {
                List<MatrizNew> matrizList = new List<MatrizNew>();
                matrizList = GetAll();
                var Result = from MatrizNew in matrizList
                             where MatrizNew.isEliminado == false
                             select MatrizNew;
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
        /// Obtiene una lista de todos los MatrizNew eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo MatrizNew con todos sus Datos</returns>
        private List<MatrizNew> GetAllEliminados()
        {
            try
            {
                List<MatrizNew> matrizList = new List<MatrizNew>();
                matrizList = GetAll();
                var Result = from MatrizNew in matrizList
                             where MatrizNew.isEliminado == true
                             select MatrizNew;
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
        /// Obtiene una lista de todos los MatrizNew. Segun parametro indicado segun enumeracion.
        /// </summary>
        /// <param name="_operacion">Parametro seleccionado</param>
        /// <returns>Devuelve un objeto lista de MatrizNew</returns>
        public List<MatrizNew> GetAll(GetAll.GetAllEnum _operacion)
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
        /// Actualiza el MatrizNew 
        /// </summary>
        /// <param name="_MatrizNew">
        /// Objeto de tipo MatrizNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Update(MatrizNew _MatrizNew)
        {

            try
            {
                MatrizNewValidator matrizValidador = new MatrizNewValidator();
                ValidationResult.Validation = matrizValidador.Validate(_MatrizNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.MatrizNewRepository.Update(_MatrizNew);
                        context.SaveChange();
                    }
                    if (result > 0)
                    {
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Matriz actualizado correctamente.";
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
        /// Elimina un MatrizNew
        /// </summary>
        /// <param name="_MatrizNew">
        /// Objeto de tipo MatrizNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Remove(MatrizNew _MatrizNew)
        {
            int result = 0;
            try
            {
                MatrizNewValidator validator = new MatrizNewValidator();
                ValidationResult.Validation = validator.Validate(_MatrizNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.MatrizNewRepository.Remove(_MatrizNew.idMatriz);
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
        /// <param name="_IdMatriz">ID del MatrizNew a actualiza</param>
        /// <param name="_isEliminado">parametro a actualizar</param>
        public void UpdateIsEliminado(int _IdMatriz, Boolean _isEliminado)
        {
            try
            {
                int result = 0;
                using (var context = _uniOfWork.Create())
                {
                    result = context.Repository.MatrizNewRepository.UpdateSoftDelete(_IdMatriz, _isEliminado);
                    context.SaveChange();
                }
                if (result > 0)
                { ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok; ValidationResult.Message = "Matriz eliminado correctamente."; }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
        }
    }
}
