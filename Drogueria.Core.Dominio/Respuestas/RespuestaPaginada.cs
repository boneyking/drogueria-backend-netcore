using System.Collections.Generic;

namespace Drogueria.Core.Dominio.Respuestas
{
    public class RespuestaPaginada<T>
    {
        public IList<T> Items { get; set; }
        public int Total { get; set; }
    }
}
