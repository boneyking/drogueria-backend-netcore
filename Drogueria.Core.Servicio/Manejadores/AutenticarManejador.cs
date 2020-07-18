using Drogueria.Core.Dominio.Entidades;
using Drogueria.Core.Dominio.Interfaces.Repositorios;
using Drogueria.Core.Infraestructura.Interfaces;
using Drogueria.Core.Infraestructura.Utilidades;
using System;
using System.Linq;

namespace Drogueria.Core.Servicio.Manejadores
{
    public class AutenticarManejador : IAutenticar, IDisposable
    {
        IRepositorio<Usuario> _usuarioRepositorio;

        public AutenticarManejador(IRepositorio<Usuario> usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public Usuario AutenticarUsuario(string rut, string password)
        {
            var usuario = _usuarioRepositorio.ObtenerPor(x => x.Rut.Trim().ToUpper() == rut.Trim().ToUpper()).FirstOrDefault();
            if (usuario == null)
                throw new Exception("No existe un usuario con el Rut indicado.");

            var passwordDesencriptado = Encriptar.DesencriptarTexto(usuario.Password);
            if (passwordDesencriptado != password)
                throw new Exception("Contraseña indicada no es válida.");

            usuario.Password = "******";
            return usuario;
        }

        public void Dispose()
        {
            return;
        }
    }
}
