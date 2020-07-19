using Drogueria.Core.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Drogueria.Core.Dominio.Interfaces.Repositorios
{
    public interface IUsuario
    {
        Task<Usuario> ObtenerPorId(Guid id);
        Task<Usuario> ObtenerPorRut(string rut);
        Task<bool> ExisteUsuarioPorRut(string rut);
        Task CrearUsuario(Usuario usuario);
        Task ActualizarUsuario(Usuario usuario);
        Task<IList<Usuario>> ObtenerUsuarios();
    }
}
