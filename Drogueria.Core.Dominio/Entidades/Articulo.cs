using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drogueria.Core.Dominio.Entidades
{
    public class Articulo : BaseId
    {
        public Arsenal Arsenal { get; set; }
        public string CodigoBarra { get; set; }
        public ICollection<Lote> Lotes { get; set; }
        public bool Activo { get; set; }
        [ForeignKey("Usuario")]
        public Guid ResponsableId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
