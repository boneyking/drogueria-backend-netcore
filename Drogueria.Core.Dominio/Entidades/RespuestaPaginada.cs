using System;
using System.Collections.Generic;
using System.Text;

namespace Drogueria.Core.Dominio.Entidades
{
    public class RespuestaPaginada<T>
    {
        public IList<T> Items { get; set; }
        public int Total { get; set; }
    }
}
