using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Drogueria.Core.Dominio.Entidades
{
    public class Usuario : BaseId
    {
        [Required]
        [StringLength(50)]
        public string Rut { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        public ICollection<RolUsuario> Roles { get; set; }
        public ICollection<Autorizacion> Autorizaciones { get; set; }
        public InformacionPersonal? InformacionPersonal { get; set; }

        public Usuario()
        {
            Rut = string.Empty;
            Password = string.Empty;
            Roles = new List<RolUsuario>();
            Autorizaciones = new List<Autorizacion>();
            InformacionPersonal = new InformacionPersonal();

        }


        public void OfuscarPassword()
        {
            Password = "******";
        }
    }
}
