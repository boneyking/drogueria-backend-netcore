using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drogueria.Core.Dominio.Entidades
{
    public class Lote : BaseId
    {
        public string Identificador { get; set; }
        public DateTime FechaVencimiento { get; set; }
        [ForeignKey("Usuario")]
        public Guid ResponsableId { get; set; }
        public double ValorUnitario { get; set; }
        public long Cantidad { get; set; }

        public Lote()
        {
            Identificador = string.Empty;
            FechaVencimiento = DateTime.UtcNow;
            ResponsableId = Guid.NewGuid();
            ValorUnitario = 0;
            Cantidad = 0;
        }


    }
}
