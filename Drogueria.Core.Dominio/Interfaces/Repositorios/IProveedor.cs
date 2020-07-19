using Drogueria.Core.Dominio.Entidades;
using Drogueria.Core.Dominio.Respuestas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Drogueria.Core.Dominio.Interfaces.Repositorios
{
    public interface IProveedor
    {
        Task<IList<Proveedor>> ObtenerTodosLosProveedores();
        Task<RespuestaPaginada<Proveedor>> ObtenerProveedoresPaginados(ResultadosPaginados resultadosPaginados);

        Task CrearProveedor(Proveedor proveedor);

        Task ActualizarProveedor(Proveedor proveedor);
    }
}
