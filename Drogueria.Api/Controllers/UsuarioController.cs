using Drogueria.Core.Dominio.Entidades;
using Drogueria.Core.Dominio.Interfaces.Repositorios;
using Drogueria.Core.Infraestructura.Repositorios;
using Drogueria.Core.Servicio.Manejadores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Drogueria.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private IUsuario _usuario;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
            _usuario = new UsuarioManejador(new Repositorio<Usuario>());
        }

        [Authorize(Roles ="Administrador")]
        [HttpPatch]
        public async Task<IActionResult> ActualizarUsuario([FromBody] Usuario usuario)
        {
            _logger.LogInformation("ActualizarUsuario");
            try
            {
                await _usuario.ActualizarUsuario(usuario);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
