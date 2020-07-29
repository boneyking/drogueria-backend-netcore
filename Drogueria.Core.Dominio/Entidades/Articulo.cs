using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        public Articulo()
        {
            Arsenal = new Arsenal();
            CodigoBarra = string.Empty;
            Lotes = new List<Lote>();
            Activo = true;
            ResponsableId = Guid.NewGuid();
            FechaCreacion = DateTime.UtcNow;
            FechaModificacion = DateTime.UtcNow;
        }

        public long ObtenerStockActualArticulo()
        {
            return Lotes.Sum(x => x.Cantidad);
        }
    }
}
