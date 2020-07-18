using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drogueria.Core.Dominio.Entidades
{
    public class Proveedor : BaseId
    {
        public string Nombre { get; set; }
        public string Rut { get; set; }
        [ForeignKey("Usuario")]
        public Guid ResponsableId { get; set; }
        public Usuario Responsable { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
