using Microsoft.AspNetCore.Mvc;
using Models.Request;

namespace APIAPRSoftware.Controllers.Usuarios
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController:ControllerBase
    {
        
        public UsuarioController()
        {

        }
        [HttpPost]
        public IActionResult Autentificar([FromBody] AuthRequest authrequest)
        {
         return Ok(authrequest);
        }
    }
}
