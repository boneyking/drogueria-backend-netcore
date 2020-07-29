using Drogueria.Core.Dominio.Entidades;
using Drogueria.Core.Dominio.Respuestas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Drogueria.Core.Dominio.Interfaces.Repositorios
{
    public interface IArsenal
    {
        Task CrearArsenal(Arsenal arsenal);
        Task ModificarArsenal(Arsenal arsenal);
        Task<IList<Arsenal>> ObtenerTodosLosArsenales();
        Task<RespuestaPaginada<Arsenal>> ObtenerArsenalesPaginados(ResultadosPaginados resultadosPaginados);
    }
}
