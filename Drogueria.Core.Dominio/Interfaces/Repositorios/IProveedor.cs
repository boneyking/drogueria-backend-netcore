using Drogueria.Core.Dominio.Entidades;
using Drogueria.Core.Dominio.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Drogueria.Core.Dominio.Interfaces.Repositorios
{
    public interface IProveedor
    {
        Task<IList<Proveedor>> ObtenerTodosLosProveedores();
        Task<RespuestaPaginada<Proveedor>> ObtenerProveedoresPaginados(ResultadosPaginados resultadosPaginados);
    }
}
