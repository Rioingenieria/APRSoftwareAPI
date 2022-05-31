using Microsoft.AspNetCore.Mvc;
using Models.ConfiguracionesGlobales;
using Services.ConfiguracionesGlobales;
using UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer;

namespace APIAPRSoftware.Controllers.ConfiguracionesGlobales
{
    [Route("api/ConfiguracionGlobal")]
    public class ConfiguracionGlobalController
    {
        UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork;
        ConfiguracionGlobalServices configuracion;
        public ConfiguracionGlobalController()
        {
            unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            configuracion = new ConfiguracionGlobalServices(unitOfWork);
        }
        [HttpGet("~/api/ConfiguracionGlobal/getAll")]
        public ActionResult<List<ConfiguracionGlobal>> GetAll()
        {
            List<ConfiguracionGlobal> list = new List<ConfiguracionGlobal>();
            list = configuracion.GetAll(Models.Enum.GetAll.GetAllEnum.Todos);
            return list;
        }
        [HttpGet("~/api/ConfiguracionGlobal/getEliminados")]
        public ActionResult<List<ConfiguracionGlobal>> GetEliminados()
        {
            List<ConfiguracionGlobal> list = new List<ConfiguracionGlobal>();
            list = configuracion.GetAll(Models.Enum.GetAll.GetAllEnum.Eliminados);
            return list;
        }
        [HttpGet("~/api/ConfiguracionGlobal/getNoEliminados")]
        public ActionResult<List<ConfiguracionGlobal>> GetNoEliminados()
        {
            List<ConfiguracionGlobal> list = new List<ConfiguracionGlobal>();
            list = configuracion.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            return list;
        }
        [HttpGet("~/api/ConfiguracionGlobal/getById/{_idConfig:int}")]
        public ActionResult<ConfiguracionGlobal> GetById(int _idConfig)
        {
            var config = new ConfiguracionGlobal();
            if (string.IsNullOrEmpty(""))
            {
                return null;
            }
            config = configuracion.GetById(_idConfig);
            return config;
        }
        [HttpPost]
        public ActionResult Post([FromBody] ConfiguracionGlobal _config)
        {
            var config = new ConfiguracionGlobal();
            configuracion.create(_config);
            return null;
        }
        [HttpPut]
        public ActionResult Put([FromBody] ConfiguracionGlobal _config)
        {
            var config = new ConfiguracionGlobal();
            configuracion.Update(_config);
            return null;
        }
        [HttpDelete]
        public ActionResult Delete([FromBody] ConfiguracionGlobal _config)
        {
            var config = new ConfiguracionGlobal();
            configuracion.Update(_config);
            if (configuracion.ValidationResult.Status != Models.Enum.Status.StatusEnum.Ok)
            {
               
            }
            return null;
        }
    }
}
