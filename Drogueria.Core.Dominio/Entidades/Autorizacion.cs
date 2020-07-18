using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drogueria.Core.Dominio.Entidades
{
    public class Autorizacion : BaseId
    {        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [ForeignKey("Usuario")]
        public Guid ResponsableId { get; set; }
        [Required]
        public Usuario Responsable { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
