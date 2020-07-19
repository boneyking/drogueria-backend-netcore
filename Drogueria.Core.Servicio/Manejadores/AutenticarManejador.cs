using Drogueria.Core.Dominio.Entidades;
using Drogueria.Core.Dominio.Interfaces.Repositorios;
using Drogueria.Core.Infraestructura.Interfaces;
using Drogueria.Core.Infraestructura.Utilidades;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Drogueria.Core.Servicio.Manejadores
{
    public class AutenticarManejador : IAutenticar, IDisposable
    {
        IRepositorio<Usuario> _usuarioRepositorio;

        public AutenticarManejador(IRepositorio<Usuario> usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public async Task<Usuario> AutenticarUsuario(string rut, string password)
        {
            var usuario = await _usuarioRepositorio.ObtenerPor(x => x.Rut.Trim().ToUpper() == rut.Trim().ToUpper());
            if(usuario.FirstOrDefault() == null)
                throw new Exception("No existe un usuario con el Rut indicado.");

            var passwordDesencriptado = Encriptar.DesencriptarTexto(usuario.FirstOrDefault().Password);
            if (passwordDesencriptado != password)
                throw new Exception("Contraseña indicada no es válida.");

            return await Task.Run(() =>
            {
                var usuarioEncontrado = usuario.FirstOrDefault();
                usuarioEncontrado.OfuscarPassword();
                return usuarioEncontrado;
            });
        }

        public void Dispose()
        {
            return;
        }
    }
}
