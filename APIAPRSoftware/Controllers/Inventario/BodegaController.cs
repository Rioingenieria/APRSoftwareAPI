using Microsoft.AspNetCore.Mvc;
using UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer;
using Services.Inventory;
using Models.Inventory;

namespace APIAPRSoftware.Controllers.Inventario
{
    [Route("api/bodegas")]
    public class BodegaController
    {
        UnitOfWorkInventarioSqlServer UoW;
        BodegaServices bodegaServices;
        public BodegaController()
        {
        UoW = new UnitOfWorkInventarioSqlServer();
            bodegaServices = new BodegaServices(UoW);
        }
        [HttpGet]
        public ActionResult<List<Bodega>> Get()
        {
            List<Bodega> bodegaList = new List<Bodega>();
            bodegaList = bodegaServices.GetAll(Models.Enum.GetAll.GetAllEnum.Todos);
            return bodegaList;
        }
        [HttpGet("{_idBodega:int}")]
        public  ActionResult<Bodega> Get(int _idBodega)
        {

            var bodega= bodegaServices.GetById(_idBodega);
            return bodega;
        }
        [HttpPost]
        public ActionResult Post([FromBody]Bodega bodega)
        {

            return null;
        } 
       [HttpDelete]
       public ActionResult Delete()
        {
            return null;
        }
    }
}
