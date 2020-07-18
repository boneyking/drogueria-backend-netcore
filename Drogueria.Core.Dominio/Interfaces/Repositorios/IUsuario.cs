using Drogueria.Core.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Drogueria.Core.Dominio.Interfaces.Repositorios
{
    public interface IUsuario
    {
        Usuario ObtenerPorId(Guid id);
        Usuario ObtenerPorRut(string rut);
        bool ExisteUsuarioPorRut(string rut);
        void CrearUsuario(Usuario usuario);
        void ActualizarUsuario(Usuario usuario);
        IList<Usuario> ObtenerUsuarios();
    }
}
