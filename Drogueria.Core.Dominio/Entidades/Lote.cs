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
        public double CantidadEntrada { get; set; }
        public double CantidadSalida { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double Stock => CantidadEntrada - CantidadSalida;
    }
}
