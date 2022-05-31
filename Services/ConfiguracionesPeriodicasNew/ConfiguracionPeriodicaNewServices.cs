using Models;
using Models.Common;
using Models.ConfiguracionesPeriodicosNew;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;

namespace Services.ConfiguracionesPeriodicasNew
{
    public class ConfiguracionPeriodicaNewServices
    {
        private readonly IUnitOfWork _uniOfWork;
        public ValidationsFluent ValidationResult { get; }
        public ConfiguracionPeriodicaNewServices(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        public void create(ConfiguracionPeriodicoNew _ConfiguracionPeriodicoNew)
        {
            try
            {
                ConfiguracionesPeriodicosNewValidator ConfigValidator = new ConfiguracionesPeriodicosNewValidator();
                ValidationResult.Validation = ConfigValidator.Validate(_ConfiguracionPeriodicoNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create()) { context.Repository.ConfiguracionPeriodicoNewRepository.Create(_ConfiguracionPeriodicoNew); context.SaveChange(); }
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                    ValidationResult.Message = "Configuración periodico registrada correctamente.";
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
        public ConfiguracionPeriodicoNew GetById(int _idConfig)
        {
            ConfiguracionPeriodicoNew config = new ConfiguracionPeriodicoNew();
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    config = context.Repository.ConfiguracionPeriodicoNewRepository.GetById(_idConfig);
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
        private List<ConfiguracionPeriodicoNew> GetAll()
        {
            try
            {
                List<ConfiguracionPeriodicoNew> config = new List<ConfiguracionPeriodicoNew>();
                using (var context = _uniOfWork.Create())
                {
                    config = context.Repository.ConfiguracionPeriodicoNewRepository.GetAll();
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
        private List<ConfiguracionPeriodicoNew> GetAllNoEliminados()
        {
            try
            {
                List<ConfiguracionPeriodicoNew> config = new List<ConfiguracionPeriodicoNew>();
                config = GetAll();
                var Result = from ConfiguracionPeriodicoNew in config
                             where ConfiguracionPeriodicoNew.is_eliminado == false
                             select ConfiguracionPeriodicoNew;
                return Result.ToList();
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        private List<ConfiguracionPeriodicoNew> GetAllEliminados()
        {
            try
            {
                List<ConfiguracionPeriodicoNew> config = new List<ConfiguracionPeriodicoNew>();
                config = GetAll();
                var Result = from ConfiguracionPeriodicoNew in config
                             where ConfiguracionPeriodicoNew.is_eliminado == true
                             select ConfiguracionPeriodicoNew;
                return Result.ToList();
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        public List<ConfiguracionPeriodicoNew> GetAll(GetAll.GetAllEnum _operacion)
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
        public void Update(ConfiguracionPeriodicoNew _config)
        {
            try
            {
                ConfiguracionesPeriodicosNewValidator ConfigValidador = new ConfiguracionesPeriodicosNewValidator();
                ValidationResult.Validation = ConfigValidador.Validate(_config);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        context.Repository.ConfiguracionPeriodicoNewRepository.Update(_config);
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
                using (var context = _uniOfWork.Create())
                {
                    context.Repository.ConfiguracionPeriodicoNewRepository.UpdateSoftDelete(_idconfig, _isEliminado);
                    context.SaveChange();
                }
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                ValidationResult.Message = "Configuración global eliminada correctamente.";

            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
        }
        public int Remove(ConfiguracionPeriodicoNew _config)
        {
            int result = 0;
            try
            {
                ConfiguracionesPeriodicosNewValidator validator = new ConfiguracionesPeriodicosNewValidator();
                ValidationResult.Validation = validator.Validate(_config);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.ConfiguracionPeriodicoNewRepository.Remove(_config.id_configuracion_periodico);
                        context.SaveChange();
                    }
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                    ValidationResult.Message = "Configuración periodico eliminada correctamente.";
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
