using Models;
using Models.Common;
using Models.DatosSII;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;

namespace Services.DatosSII
{
    public class DatoSiiServices
    {
            private readonly IUnitOfWork _uniOfWork;
            public ValidationsFluent ValidationResult { get; }
            public DatoSiiServices(IUnitOfWork unitOfWork)
            {
                _uniOfWork = unitOfWork;
                ValidationResult = new ValidationsFluent();
            }
            /// <summary>
            /// Crea un DatoSii
            /// </summary>
            /// <param name="_DatoSii">
            /// Objeto de tipo DatoSii con todos sus atributos completos para ser insertado en la BBDD
            /// </param>
            public void Create(DatoSii _DatoSii)
            {
                try
                {
                    DatoSiiValidator validator = new DatoSiiValidator();
                    ValidationResult.Validation = validator.Validate(_DatoSii);
                    if (ValidationResult.Validation.IsValid)
                    {
                        int result;
                        using (var context = _uniOfWork.Create()) { result = context.Repository.DatoSiiRepository.Create(_DatoSii); context.SaveChange(); }
                        if (result > 0)
                        {
                            ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                            ValidationResult.Message = "Datos Sii registrado correctamente.";
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
            /// Obtiene un DatoSii existente en la BBDD por el id
            /// </summary>
            /// <param name="_IdDatoSii">
            /// ID del DatoSii
            /// </param>
            /// <returns>Retorna un DatoSii</returns>
            public DatoSii GetById(int _IdDatoSii)
            {
                DatoSii DatoSii = new DatoSii();
                try
                {
                    using (var context = _uniOfWork.Create())
                    {
                        DatoSii = context.Repository.DatoSiiRepository.GetById(_IdDatoSii);
                    }
                    return DatoSii;
                }
                catch (Exception ex)
                {
                    SalidaLogs.AgregarLog(ex);
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                    return null;
                }
            }
            /// <summary>
            /// Obtiene una lista de todos los DatoSii existentes en la BBDD
            /// </summary>
            /// <returns>
            /// Devuelve un objeto lista de tipo DatoSii con todos sus Datos
            /// </returns>
            private List<DatoSii> GetAll()
            {
                try
                {
                    List<DatoSii> DatoSiiList = new List<DatoSii>();
                    using (var context = _uniOfWork.Create())
                    {
                        DatoSiiList = context.Repository.DatoSiiRepository.GetAll();
                    }
                    return DatoSiiList;
                }
                catch (Exception ex)
                {
                    SalidaLogs.AgregarLog(ex);
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                    return null;
                }
            }
            /// <summary>
            /// Obtiene una lista de todos los DatoSii no eliminados existentes en la BBDD
            /// </summary>
            /// <returns>Devuelve un objeto lista de tipo DatoSii con todos sus Datos</returns>
            private List<DatoSii> GetAllNoEliminados()
            {
                try
                {
                    List<DatoSii> DatoSiiList = new List<DatoSii>();
                    DatoSiiList = GetAll();
                    var Result = from DatoSii in DatoSiiList
                                 where DatoSii.isEliminado == false
                                 select DatoSii;
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
            /// Obtiene una lista de todos los DatoSii eliminados existentes en la BBDD
            /// </summary>
            /// <returns>Devuelve un objeto lista de tipo DatoSii con todos sus Datos</returns>
            private List<DatoSii> GetAllEliminados()
            {
                try
                {
                    List<DatoSii> DatoSiiList = new List<DatoSii>();
                    DatoSiiList = GetAll();
                    var Result = from DatoSii in DatoSiiList
                                 where DatoSii.isEliminado == true
                                 select DatoSii;
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
            /// Obtiene una lista de todos los DatoSii. Segun parametro indicado segun enumeracion.
            /// </summary>
            /// <param name="_operacion">Parametro seleccionado</param>
            /// <returns>Devuelve un objeto lista de DatoSii</returns>
            public List<DatoSii> GetAll(GetAll.GetAllEnum _operacion)
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
            /// Actualiza el DatoSii 
            /// </summary>
            /// <param name="_DatoSii">
            /// Objeto de tipo DatoSii con todos sus atributos completos para ser insertado en la BBDD
            /// </param>
            public void Update(DatoSii _DatoSii)
            {

                try
                {
                    DatoSiiValidator DatoSiiValidador = new DatoSiiValidator();
                    ValidationResult.Validation = DatoSiiValidador.Validate(_DatoSii);
                    if (ValidationResult.Validation.IsValid)
                    {
                        int result;
                        using (var context = _uniOfWork.Create())
                        {
                            result = context.Repository.DatoSiiRepository.Update(_DatoSii);
                            context.SaveChange();
                        }
                        if (result > 0)
                        {
                            ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                            ValidationResult.Message = "Datos Sii actualizado correctamente.";
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
            /// Elimina un DatoSii
            /// </summary>
            /// <param name="_DatoSii">
            /// Objeto de tipo DatoSii con todos sus atributos completos para ser insertado en la BBDD
            /// </param>
            public void Remove(DatoSii _DatoSii)
            {
                int result = 0;
                try
                {
                    DatoSiiValidator validator = new DatoSiiValidator();
                    ValidationResult.Validation = validator.Validate(_DatoSii);
                    if (ValidationResult.Validation.IsValid)
                    {
                        using (var context = _uniOfWork.Create())
                        {
                            result = context.Repository.DatoSiiRepository.Remove(_DatoSii.idEmpresa);
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
            /// <param name="_IdDatoSii">ID del DatoSii a actualiza</param>
            /// <param name="_isEliminado">parametro a actualizar</param>
            public void UpdateIsEliminado(int _IdDatoSii, Boolean _isEliminado)
            {
                try
                {
                    int result = 0;
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.DatoSiiRepository.UpdateSoftDelete(_IdDatoSii, _isEliminado);
                        context.SaveChange();
                    }
                    if (result > 0)
                    { ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok; ValidationResult.Message = "Datos Sii eliminado correctamente."; }
                }
                catch (Exception ex)
                {
                    SalidaLogs.AgregarLog(ex);
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                }
            }
        }
}
