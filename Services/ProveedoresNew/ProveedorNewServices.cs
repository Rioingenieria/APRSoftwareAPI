using Models;
using Models.Common;
using Models.Enum;
using Models.ProveedoresNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;

namespace Services.ProveedoresNew
{
    public class ProveedorNewServices
    {
        private readonly IUnitOfWork _uniOfWork;
        public ValidationsFluent ValidationResult { get; }
        public ProveedorNewServices(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        /// <summary>
        /// Crea un Proveedor
        /// </summary>
        /// <param name="_ProveedorNew">
        /// Objeto de tipo ProveedorNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Create(ProveedorNew _ProveedorNew)
        {
            try
            {
                ProveedorNewValidator ProductValidator = new ProveedorNewValidator();
                ValidationResult.Validation = ProductValidator.Validate(_ProveedorNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create()) { result = context.Repository.ProveedorNewRepository.Create(_ProveedorNew); context.SaveChange(); }
                    if (result > 0)
                    {
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Proveedor registrado correctamente.";
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
        /// Obtiene un ProveedorNew existente en la BBDD por el id
        /// </summary>
        /// <param name="_idProveedor">
        /// ID del ProveedorNew
        /// </param>
        /// <returns>Retorna un ProveedorNew</returns>
        public ProveedorNew GetById(int _idProveedor)
        {
            ProveedorNew Proveedor = new ProveedorNew();
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    Proveedor = context.Repository.ProveedorNewRepository.GetById(_idProveedor);
                }
                return Proveedor;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los ProveedorNew existentes en la BBDD
        /// </summary>
        /// <returns>
        /// Devuelve un objeto lista de tipo ProveedorNew con todos sus Datos
        /// </returns>
        private List<ProveedorNew> GetAll()
        {
            try
            {
                List<ProveedorNew> proveedorList = new List<ProveedorNew>();
                using (var context = _uniOfWork.Create())
                {
                    proveedorList = context.Repository.ProveedorNewRepository.GetAll();
                }
                return proveedorList;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los ProveedorNew no eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo ProveedorNew con todos sus Datos</returns>
        private List<ProveedorNew> GetAllNoEliminados()
        {
            try
            {
                List<ProveedorNew> proveedorList = new List<ProveedorNew>();
                proveedorList = GetAll();
                var Result = from ProveedorNew in proveedorList
                             where ProveedorNew.is_eliminado == false
                             select ProveedorNew;
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
        /// Obtiene una lista de todos los ProveedorNew eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo ProveedorNew con todos sus Datos</returns>
        private List<ProveedorNew> GetAllEliminados()
        {
            try
            {
                List<ProveedorNew> proveedorList = new List<ProveedorNew>();
                proveedorList = GetAll();
                var Result = from ProveedorNew in proveedorList
                             where ProveedorNew.is_eliminado == true
                             select ProveedorNew;
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
        /// Obtiene una lista de todos los ProveedorNew. Segun parametro indicado segun enumeracion.
        /// </summary>
        /// <param name="_operacion">Parametro seleccionado</param>
        /// <returns>Devuelve un objeto lista de ProveedorNew</returns>
        public List<ProveedorNew> GetAll(GetAll.GetAllEnum _operacion)
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
        /// Actualiza el ProveedorNew 
        /// </summary>
        /// <param name="_ProveedorNew">
        /// Objeto de tipo ProveedorNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Update(ProveedorNew _ProveedorNew)
        {

            try
            {
                ProveedorNewValidator productValidador = new ProveedorNewValidator();
                ValidationResult.Validation = productValidador.Validate(_ProveedorNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.ProveedorNewRepository.Update(_ProveedorNew);
                        context.SaveChange();
                    }
                    if (result > 0)
                    {
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Proveedor actualizado correctamente.";
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
        /// Elimina un ProveedorNew
        /// </summary>
        /// <param name="_ProveedorNew">
        /// Objeto de tipo ProveedorNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Remove(ProveedorNew _ProveedorNew)
        {
            int result = 0;
            try
            {
                ProveedorNewValidator validator = new ProveedorNewValidator();
                ValidationResult.Validation = validator.Validate(_ProveedorNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.ProveedorNewRepository.Remove(_ProveedorNew.id_proveedor);
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
        /// <param name="_idProveedor">ID del ProveedorNew a actualiza</param>
        /// <param name="_isEliminado">parametro a actualizar</param>
        public void UpdateIsEliminado(int _idProveedor, Boolean _isEliminado)
        {
            try
            {
                int result = 0;
                using (var context = _uniOfWork.Create())
                {
                    result = context.Repository.ProveedorNewRepository.UpdateSoftDelete(_idProveedor, _isEliminado);
                    context.SaveChange();
                }
                if (result > 0)
                { ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok; ValidationResult.Message = "Proveedor eliminado correctamente."; }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
        }            
    }
}
