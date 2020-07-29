using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drogueria.Core.Dominio.Entidades
{
    public class Movimiento : BaseId
    {
        public Arsenal Arsenal { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public Lote Lote { get; set; }
        public double Cantidad { get; set; }
        [ForeignKey("Usuario")]
        public Guid ResponsableId { get; set; }
        public DateTime Fecha { get; set; }
    }
}
