using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drogueria.Core.Dominio.Entidades
{

    public enum ArsenalTipo
    {
        Medicamento,
        Insumo,
        AyudaTecnica
    }
    public class Arsenal : BaseId
    {
        [StringLength(255)]
        public string Descripcion { get; set; }
        public ArsenalTipo ArsenalTipo { get; set; }
        [ForeignKey("Usuario")]
        public Guid ResponsableId { get; set; }
        public Usuario Responsable { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

    }
}
