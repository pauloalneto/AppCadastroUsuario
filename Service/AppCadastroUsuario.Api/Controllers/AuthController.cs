using AppCadastroUsuario.Api.Application.Dtos;
using AppCadastroUsuario.Api.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppCadastroUsuario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthApplicationService _app;


        public AuthController(IAuthApplicationService app)
        {
            _app = app;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] CredencialUsuarioDto CredencialUsuarioDto)
        {
            try
            {
                var auth = await _app.Autenticar(CredencialUsuarioDto);

                if(auth == null) return Unauthorized();

                return Ok(auth);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
