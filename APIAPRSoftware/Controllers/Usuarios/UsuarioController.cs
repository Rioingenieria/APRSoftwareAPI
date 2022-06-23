using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Services.Usuarios;
using UnitOfWorkSqlServer.SSR;
namespace APIAPRSoftware.Controllers.Usuarios
{
    [Route("api/usuario")]
    [ApiController]
    [Authorize]
    public class UsuarioController:ControllerBase
    {
        UnitOfWorkSSRSqlServer UoW;
        UsuarioServices UsuarioServices;
        public UsuarioController()
        {
            UoW=new UnitOfWorkSSRSqlServer();
            UsuarioServices = new UsuarioServices(UoW);
        }
        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] UsuarioRequest _authRequest)
        {
           var usuarioResponse = UsuarioServices.Auth(_authRequest);
            if (UsuarioServices.ValidationResult.Status == Models.Enum.Status.StatusEnum.Ok)
            {
                return Ok(usuarioResponse);
            }
            else
            {
                return BadRequest(UsuarioServices.ValidationResult);
            }   
        }
    }
}
