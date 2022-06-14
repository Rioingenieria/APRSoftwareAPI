using Models;
using Models.ClientesNew;
using Models.Common;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;

namespace Services.ClientesNew
{
    public class ClienteNewServices
    {
        private readonly IUnitOfWork _uniOfWork;
        public ValidationsFluent ValidationResult { get; }
        public ClienteNewServices(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        /// <summary>
        /// Crea un Cliente
        /// </summary>
        /// <param name="_ClienteNew">
        /// Objeto de tipo ClienteNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Create(ClienteNew _ClienteNew)
        {
            try
            {
                ClienteNewValidator validator = new ClienteNewValidator();
                ValidationResult.Validation = validator.Validate(_ClienteNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create()) { result = context.Repository.ClienteNewRepository.Create(_ClienteNew); context.SaveChange(); }
                    if (result > 0)
                    {
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Cliente registrado correctamente.";
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
        /// Obtiene un ClienteNew existente en la BBDD por el id
        /// </summary>
        /// <param name="_IdCliente">
        /// ID del ClienteNew
        /// </param>
        /// <returns>Retorna un ClienteNew</returns>
        public ClienteNew GetById(int _IdCliente)
        {
            ClienteNew Cliente = new ClienteNew();
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    Cliente = context.Repository.ClienteNewRepository.GetById(_IdCliente);
                }
                return Cliente;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene un ClienteNew existente en la BBDD por el rut
        /// </summary>
        /// <param name="_rut">rut del Cliente</param>
        /// <returns>Retorna un True si existe un cliente con ese rut en la BBDD</returns>
        public Boolean IsExitsRutCliente(string _rut) 
        {
            try
            {
                using (var context = _uniOfWork.Create())
                {
                     if( context.Repository.ClienteNewRepository.IsExitsRutCliente(_rut)) { return true; }
                }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return false;
            }
            return false;
        }
        /// <summary>
        /// Obtiene una lista de todos los ClienteNew existentes en la BBDD
        /// </summary>
        /// <returns>
        /// Devuelve un objeto lista de tipo ClienteNew con todos sus Datos
        /// </returns>
        private List<ClienteNew> GetAll()
        {
            try
            {
                List<ClienteNew> ClienteList = new List<ClienteNew>();
                using (var context = _uniOfWork.Create())
                {
                    ClienteList = context.Repository.ClienteNewRepository.GetAll();
                }
                return ClienteList;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los ClienteNew no eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo ClienteNew con todos sus Datos</returns>
        private List<ClienteNew> GetAllNoEliminados()
        {
            try
            {
                List<ClienteNew> ClienteList = new List<ClienteNew>();
                ClienteList = GetAll();
                var Result = from ClienteNew in ClienteList
                             where ClienteNew.isEliminado == false
                             select ClienteNew;
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
        /// Obtiene una lista de todos los ClienteNew eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo ClienteNew con todos sus Datos</returns>
        private List<ClienteNew> GetAllEliminados()
        {
            try
            {
                List<ClienteNew> ClienteList = new List<ClienteNew>();
                ClienteList = GetAll();
                var Result = from ClienteNew in ClienteList
                             where ClienteNew.isEliminado == true
                             select ClienteNew;
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
        /// Obtiene una lista de todos los ClienteNew. Segun parametro indicado segun enumeracion.
        /// </summary>
        /// <param name="_operacion">Parametro seleccionado</param>
        /// <returns>Devuelve un objeto lista de ClienteNew</returns>
        public List<ClienteNew> GetAll(GetAll.GetAllEnum _operacion)
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
        /// Actualiza el ClienteNew 
        /// </summary>
        /// <param name="_ClienteNew">
        /// Objeto de tipo ClienteNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Update(ClienteNew _ClienteNew)
        {

            try
            {
                ClienteNewValidator ClienteValidador = new ClienteNewValidator();
                ValidationResult.Validation = ClienteValidador.Validate(_ClienteNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.ClienteNewRepository.Update(_ClienteNew);
                        context.SaveChange();
                    }
                    if (result > 0)
                    {
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Cliente actualizado correctamente.";
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
        /// Elimina un ClienteNew
        /// </summary>
        /// <param name="_ClienteNew">
        /// Objeto de tipo ClienteNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Remove(ClienteNew _ClienteNew)
        {
            int result = 0;
            try
            {
                ClienteNewValidator validator = new ClienteNewValidator();
                ValidationResult.Validation = validator.Validate(_ClienteNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.ClienteNewRepository.Remove(_ClienteNew.idCliente);
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
        /// <param name="_IdCliente">ID del ClienteNew a actualiza</param>
        /// <param name="_isEliminado">parametro a actualizar</param>
        public void UpdateIsEliminado(int _IdCliente, Boolean _isEliminado)
        {
            try
            {
                int result = 0;
                using (var context = _uniOfWork.Create())
                {
                    result = context.Repository.ClienteNewRepository.UpdateSoftDelete(_IdCliente, _isEliminado);
                    context.SaveChange();
                }
                if (result > 0)
                { ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok; ValidationResult.Message = "Cliente eliminado correctamente."; }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
        }
    }
}
