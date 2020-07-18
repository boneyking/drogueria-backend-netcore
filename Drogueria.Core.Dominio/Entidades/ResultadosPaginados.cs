using System;
using System.Collections.Generic;
using System.Text;

namespace Drogueria.Core.Dominio.Entidades
{
    public class ResultadosPaginados
    {
        public string TextoBusqueda { get; set; }
        public int Pagina { get; set; }
        public int CantidadResultados { get; set; }

    }
}
