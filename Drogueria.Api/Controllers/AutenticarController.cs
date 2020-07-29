using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Drogueria.Api.Requests;
using Drogueria.Core.Dominio.Entidades;
using Drogueria.Core.Dominio.Interfaces.Repositorios;
using Drogueria.Core.Infraestructura.Repositorios;
using Drogueria.Core.Infraestructura.Utilidades;
using Drogueria.Core.Servicio.Manejadores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        public AutenticarController(ILogger<AutenticarController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _autenticar = new AutenticarManejador(new Repositorio<Usuario>());
            _configuration = configuration;
        }

        [HttpPost]
        [Route("LoginUsuario")]
        public async Task<IActionResult> AutenticarUsuario([FromBody] LoginRequest login)
        {
            _logger.LogInformation("Logueando");
            try
            {
                var usuario = await _autenticar.AutenticarUsuario(login.Rut, login.Password);

                var token = Token.CrearToken(usuario, _configuration["JWT:Secret"]);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }

        }
    }
}
