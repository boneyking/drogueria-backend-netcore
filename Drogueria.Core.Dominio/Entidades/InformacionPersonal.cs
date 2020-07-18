using System.ComponentModel.DataAnnotations;

namespace Drogueria.Core.Dominio.Entidades
{
    public class InformacionPersonal : BaseId
    {
        [StringLength(100)]
        public string Nombres { get; set; }
        [StringLength(100)]
        public string Apellidos { get; set; }
        [StringLength(100)]
        public string CorreoElectronico { get; set; }
        [StringLength(100)]
        public string Cargo { get; set; }
    }
}
