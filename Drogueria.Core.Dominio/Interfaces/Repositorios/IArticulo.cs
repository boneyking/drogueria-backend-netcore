using Drogueria.Core.Dominio.Entidades;
using Drogueria.Core.Dominio.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Drogueria.Core.Dominio.Interfaces.Repositorios
{
    public interface IArticulo
    {
        Task CrearArticulo(Articulo articulo);
        Task ActualizarArticulo(Articulo articulo);

        Task<IList<Articulo>> ObtenerTodosLosArticulos();
        Task<IList<Articulo>> ObtenerArticulosPaginados(ResultadosPaginados resultadosPaginados);

    }
}
