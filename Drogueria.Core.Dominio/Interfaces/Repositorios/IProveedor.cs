using Drogueria.Core.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drogueria.Core.Dominio.Interfaces.Repositorios
{
    public interface IProveedor
    {
        IList<Proveedor> ObtenerTodosLosProveedores();
        RespuestaPaginada<Proveedor> ObtenerProveedoresPaginados(ResultadosPaginados resultadosPaginados);
    }
}
