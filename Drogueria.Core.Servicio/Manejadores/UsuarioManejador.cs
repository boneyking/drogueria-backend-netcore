using Drogueria.Core.Dominio.Entidades;
using Drogueria.Core.Dominio.Interfaces.Repositorios;
using Drogueria.Core.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Drogueria.Core.Servicio.Manejadores
{
    public class UsuarioManejador : IUsuario, IDisposable
    {
        IRepositorio<Usuario> _usuarioRepositorio;

        public UsuarioManejador(IRepositorio<Usuario> usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            _usuarioRepositorio.Actualizar(usuario);
        }

        public void CrearUsuario(Usuario usuario)
        {
            _usuarioRepositorio.Crear(usuario);
        }

        public void Dispose()
        {
            return;
        }

        public bool ExisteUsuarioPorRut(string rut)
        {
            var usuario = _usuarioRepositorio.ObtenerPor(x => x.Rut.ToUpper().Trim() == rut.ToUpper().Trim()).FirstOrDefault();
            if (usuario != null)
                return true;
            return false;
        }

        public Usuario ObtenerPorId(Guid id)
        {
            var usuario = _usuarioRepositorio.ObtenerPor(x => x.Id == id).FirstOrDefault();
            usuario.Password = "******";
            return usuario;
        }

        public Usuario ObtenerPorRut(string rut)
        {
            var usuario = _usuarioRepositorio.ObtenerPor(x => x.Rut.ToUpper().Trim() == rut.ToUpper().Trim()).FirstOrDefault();
            usuario.Password = "******";
            return usuario;
        }

        public IList<Usuario> ObtenerUsuarios()
        {
            return _usuarioRepositorio.ObtenerTodo().ToList();
        }
    }
}
