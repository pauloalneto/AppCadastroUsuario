using AppCadastroUsuario.Api.Application.Dtos;
using AppCadastroUsuario.Api.Application.Interfaces;
using AppCadastroUsuario.Api.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppCadastroUsuario.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplicationService _app;
        private readonly ILogger<UsuarioController> _logger;
        public UsuarioController(IUsuarioApplicationService app,
            ILogger<UsuarioController> logger)
        {
            _app = app;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] UsuarioFilter filters)
        {
            try
            {
                var result = await _app.GetWithFilter(filters);
                _logger.LogInformation("Consulta lista de usuários");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await _app.GetById(id);
                _logger.LogInformation("Consulta de usuário por ID");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                await _app.Insert(usuarioDto);
                _logger.LogInformation("Usuário inserido", usuarioDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                await _app.Update(usuarioDto);
                _logger.LogInformation("Usuário atualizado", usuarioDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _app.Delete(id);
                _logger.LogInformation("Usuário excluido", id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
