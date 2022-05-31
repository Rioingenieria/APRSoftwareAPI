using Microsoft.AspNetCore.Mvc;
using Models.ConfiguracionesPeriodicosNew;
using Services.ConfiguracionesPeriodicasNew;

namespace APIAPRSoftware.Controllers.ConfiguracionesPeriodicasNew
{
    [Route("api/ConfiguracionPeriodicos")]
    public class ConfiguracionPeriodicoNewController
    {
        UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork;
        ConfiguracionPeriodicaNewServices configuracion;

        public ConfiguracionPeriodicoNewController()
        {
            unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            configuracion = new ConfiguracionPeriodicaNewServices(unitOfWork);
        }

        [HttpGet("~/api/ConfiguracionPeriodicos/getAll")]
        public ActionResult<List<ConfiguracionPeriodicoNew>> GetAll()
        {
            List<ConfiguracionPeriodicoNew> list = new List<ConfiguracionPeriodicoNew>();
            list = configuracion.GetAll(Models.Enum.GetAll.GetAllEnum.Todos);
            return list;
        }
        [HttpGet("~/api/ConfiguracionPeriodicos/getEliminados")]
        public ActionResult<List<ConfiguracionPeriodicoNew>> GetEliminados()
        {
            List<ConfiguracionPeriodicoNew> list = new List<ConfiguracionPeriodicoNew>();
            list = configuracion.GetAll(Models.Enum.GetAll.GetAllEnum.Eliminados);
            return list;
        }
        [HttpGet("~/api/ConfiguracionPeriodicos/getNoEliminados")]
        public ActionResult<List<ConfiguracionPeriodicoNew>> GetNoEliminados()
        {
            List<ConfiguracionPeriodicoNew> list = new List<ConfiguracionPeriodicoNew>();
            list = configuracion.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            return list;
        }
        [HttpGet("~/api/ConfiguracionPeriodicos/getById/{_idConfig:int}")]
        public ActionResult<ConfiguracionPeriodicoNew> GetById(int _idConfig)
        {
            var config = new ConfiguracionPeriodicoNew();
            if (string.IsNullOrEmpty(Convert.ToString(_idConfig)))
            {
                return null;
            }
            config = configuracion.GetById(_idConfig);
            return config;
        }
        [HttpPost("PostConfiguracionPeriodico")]
        public ActionResult Post([FromBody] ConfiguracionPeriodicoNew _config)
        {
            var config = new ConfiguracionPeriodicoNew();
            configuracion.create(_config);
            return null;
        }
        [HttpPut("UpdateConfiguracionPerodico")]
        public ActionResult Put(int _id,[FromBody] ConfiguracionPeriodicoNew _config)
        {
            var config = new ConfiguracionPeriodicoNew();
            configuracion.Update(_config);
            return null;
        }
        [HttpDelete("DeleteConfiguracionPeriodico")]
        public ActionResult Delete([FromBody] ConfiguracionPeriodicoNew _config)
        {
            var config = new ConfiguracionPeriodicoNew();
            configuracion.Update(_config);
            if (configuracion.ValidationResult.Status != Models.Enum.Status.StatusEnum.Ok)
            {
                return null;
            }
            return null;
        }
    }
}
