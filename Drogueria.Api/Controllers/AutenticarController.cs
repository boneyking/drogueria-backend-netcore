using System;
using Drogueria.Api.Requests;
using Drogueria.Core.Dominio.Entidades;
using Drogueria.Core.Dominio.Interfaces.Repositorios;
using Drogueria.Core.Infraestructura.Repositorios;
using Drogueria.Core.Servicio.Manejadores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Drogueria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AutenticarController : ControllerBase
    {
        private readonly ILogger<AutenticarController> _logger;
        private IAutenticar _autenticar;
        public AutenticarController(ILogger<AutenticarController> logger)
        {
            _logger = logger;
            _autenticar = new AutenticarManejador(new Repositorio<Usuario>());
        }

        [HttpGet]
        [Route("Hola")]
        public string Hola()
        {
            return "Hola";
        }

        [HttpPost]
        [Route("LoginUsuario")]
        public IActionResult AutenticarUsuario([FromBody]LoginRequest login)
        {
            _logger.LogInformation("Logueando");
            try
            {
                var usuario = _autenticar.AutenticarUsuario(login.Rut, login.Password);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 104;
                return BadRequest();
            }
            
        }
    }
}
