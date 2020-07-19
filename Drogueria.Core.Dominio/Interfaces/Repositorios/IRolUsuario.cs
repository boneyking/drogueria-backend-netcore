using Drogueria.Core.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Drogueria.Core.Dominio.Interfaces.Repositorios
{
    public interface IRolUsuario
    {
        Task CrearRolUsuario(RolUsuario rolUsuario);
        Task EliminarRolUsuario(RolUsuario rolUsuario);
        Task<IList<RolUsuario>> ObtenerRolesPorUsuarioId(Guid usuarioId);
    }
}
