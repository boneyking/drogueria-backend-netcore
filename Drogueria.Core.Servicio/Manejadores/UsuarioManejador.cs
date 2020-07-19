using Drogueria.Core.Dominio.Entidades;
using Drogueria.Core.Dominio.Interfaces.Repositorios;
using Drogueria.Core.Infraestructura.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drogueria.Core.Servicio.Manejadores
{
    public class UsuarioManejador : IUsuario, IDisposable
    {
        IRepositorio<Usuario> _usuarioRepositorio;

        public UsuarioManejador(IRepositorio<Usuario> usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task ActualizarUsuario(Usuario usuario)
        {
            await _usuarioRepositorio.Actualizar(usuario);
        }

        public async Task CrearUsuario(Usuario usuario)
        {
            await _usuarioRepositorio.Crear(usuario);
        }

        public void Dispose()
        {
            return;
        }

        public async Task<bool> ExisteUsuarioPorRut(string rut)
        {
            var usuario = await _usuarioRepositorio
                        .ObtenerPor(x => x.Rut.ToUpper().Trim() == rut.ToUpper().Trim())
                        .Result
                        .FirstOrDefaultAsync();
            if (usuario != null)
                return true;
            return false;
        }

        public async Task<Usuario> ObtenerPorId(Guid id)
        {
            var usuario = await _usuarioRepositorio.ObtenerPor(x => x.Id == id).Result.FirstOrDefaultAsync();
            if (usuario != null)
                usuario.OfuscarPassword();
            return usuario;
        }

        public async Task<Usuario> ObtenerPorRut(string rut)
        {
            var usuario = await _usuarioRepositorio.ObtenerPor(x => x.Rut.ToUpper().Trim() == rut.ToUpper().Trim()).Result.FirstOrDefaultAsync();
            if (usuario != null)
                usuario.OfuscarPassword();
            return usuario;
        }

        public async Task<IList<Usuario>> ObtenerUsuarios()
        {
            return await _usuarioRepositorio.ObtenerTodo().Result.ToListAsync();
        }
    }
}
