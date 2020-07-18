using System;

namespace Drogueria.Core.Dominio.Entidades
{
    public enum Rol
    {
        Administrador
    }
    public class RolUsuario : BaseId
    {
        public Guid UsuarioId { get; set; }
        public Rol Rol { get; set; }
    }
}
