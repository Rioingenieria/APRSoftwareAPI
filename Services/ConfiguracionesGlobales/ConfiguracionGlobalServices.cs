using Models;
using Models.Common;
using Models.ConfiguracionesGlobales;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;

namespace Services.ConfiguracionesGlobales
{
    public class ConfiguracionGlobalServices
    {
        private readonly IUnitOfWork _uniOfWork;
        public ValidationsFluent ValidationResult { get; }
        public ConfiguracionGlobalServices(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        public int create(ConfiguracionGlobal _configuracionGlobal)
        {
            try
            {
                ConfiguracionGlobalValidator  ConfigValidator= new ConfiguracionGlobalValidator();
                ValidationResult.Validation = ConfigValidator.Validate(_configuracionGlobal);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create()){ result=context.Repository.ConfiguracionGlobalRepository.Create(_configuracionGlobal);context.SaveChange();}
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                    ValidationResult.Message = "Configuración periodico registrada correctamente.";
                    return result;
                }
                else
                {
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Validation;
                    return 0;
                }
            }
            catch (Exception ex )
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return 0;
            }
          
        }
        public ConfiguracionGlobal GetById(int _idConfig)
        {
            ConfiguracionGlobal config = new ConfiguracionGlobal();
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    config = context.Repository.ConfiguracionGlobalRepository.GetById(_idConfig);
                }
                return config;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        private List<ConfiguracionGlobal> GetAll()
        {
            try
            {
                List<ConfiguracionGlobal> config = new List<ConfiguracionGlobal>();
                using (var context = _uniOfWork.Create())
                {
                    config = context.Repository.ConfiguracionGlobalRepository.GetAll();
                }
                return config;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        private List<ConfiguracionGlobal> GetAllNoEliminados()
        {
            try
            {
                List<ConfiguracionGlobal> config = new List<ConfiguracionGlobal>();
                config = GetAll();
                var Result = from ConfiguracionGlobal in config
                             where ConfiguracionGlobal.is_eliminado == false
                             select ConfiguracionGlobal;
                return Result.ToList();
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        private List<ConfiguracionGlobal> GetAllEliminados()
        {
            try
            {
                List<ConfiguracionGlobal> config = new List<ConfiguracionGlobal>();
                config = GetAll();
                var Result = from ConfiguracionGlobal in config
                             where ConfiguracionGlobal.is_eliminado == true
                             select ConfiguracionGlobal;
                return Result.ToList();
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        public List<ConfiguracionGlobal> GetAll(GetAll.GetAllEnum _operacion)
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
        public void Update(ConfiguracionGlobal _config)
        {
            try
            {
                ConfiguracionGlobalValidator ConfigValidador = new ConfiguracionGlobalValidator();
                ValidationResult.Validation = ConfigValidador.Validate(_config);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        context.Repository.ConfiguracionGlobalRepository.Update(_config);
                        context.SaveChange();
                    }
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                    ValidationResult.Message = "Configuración periodico actualizada correctamente.";
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
        public void UpdateIsEliminado(int _idconfig, Boolean _isEliminado)
        {
            try
            {
                int result=0;
                using (var context = _uniOfWork.Create())
                {
                    result=context.Repository.ConfiguracionGlobalRepository.UpdateSoftDelete(_idconfig, _isEliminado);
                    context.SaveChange();
                }
                if (result > 0)
                { ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok; ValidationResult.Message = "Configuración global eliminada correctamente."; }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
        }
        public int Remove(ConfiguracionGlobal _config)
        {
            int result = 0;
            try
            {
                ConfiguracionGlobalValidator validator = new ConfiguracionGlobalValidator();
                ValidationResult.Validation = validator.Validate(_config);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.ConfiguracionGlobalRepository.Remove(_config.id_configuracion);
                        context.SaveChange();
                    }
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                }
                else
                {
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Validation;
                }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
            return result;
        }
    }
}
