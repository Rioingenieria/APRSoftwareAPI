using APIAPRSoftware.ModelsDTO.Respuestas;
using Microsoft.AspNetCore.Mvc;
using Models.ClientesNew;
using Services.ClientesNew;
using System.Reflection;
using UnitOfWorkSqlServer.SSR;

namespace APIAPRSoftware.Controllers.Clientes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        UnitOfWorkSSRSqlServer UoW;
        ClienteNewServices ClienteServices;

        public ClienteController()
        {
            UoW = new UnitOfWorkSSRSqlServer();
            ClienteServices = new ClienteNewServices(UoW);
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                var ListadoClientes = ClienteServices.GetAll(Models.Enum.GetAll.GetAllEnum.Todos);
                Respuesta respuesta = new Respuesta()
                {
                    Exito = 1,
                    Mensaje = "Ok",
                    Data =ListadoClientes
                };
           

                return Ok(respuesta);
            }
            catch (Exception ex)
            {

                Respuesta respuesta = new Respuesta()
                {
                    Exito = 1,
                    Mensaje = "Error al realizar la operacion."
                };
                return BadRequest(respuesta);
            }

        }
    }
}
