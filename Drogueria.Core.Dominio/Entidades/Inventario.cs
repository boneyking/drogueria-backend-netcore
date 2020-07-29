using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drogueria.Core.Dominio.Entidades
{
    public class Inventario : BaseId
    {
        [ForeignKey("Arsenal")]
        public Guid ArsenalId { get; set; }
        public double StockActual { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        [ForeignKey("Usuario")]
        public Guid ResponsableId { get; set; }
        public DateTime UltimaModificacion { get; set; }
    }
}
