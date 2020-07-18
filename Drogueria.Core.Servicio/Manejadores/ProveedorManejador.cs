using Drogueria.Core.Dominio.Entidades;
using Drogueria.Core.Dominio.Interfaces.Repositorios;
using Drogueria.Core.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drogueria.Core.Servicio.Manejadores
{
    public class ProveedorManejador : IProveedor, IDisposable
    {
        IRepositorio<Proveedor> _proveedorRepositorio;

        public ProveedorManejador(IRepositorio<Proveedor> proveedorRepositorio)
        {
            _proveedorRepositorio = proveedorRepositorio;
        }

        public void Dispose()
        {
            return;
        }

        public RespuestaPaginada<Proveedor> ObtenerProveedoresPaginados(ResultadosPaginados resultadosPaginados)
        {
            var saltados = resultadosPaginados.CantidadResultados * (resultadosPaginados.Pagina - 1);

            var resultados = _proveedorRepositorio.ObtenerPor(x => x.Nombre.Trim().ToUpper().Contains(resultadosPaginados.TextoBusqueda.ToUpper().Trim()))
                .OrderBy(x => x.Nombre)
                .Skip(saltados)
                .Take(resultadosPaginados.CantidadResultados)
                .ToList();

            return new RespuestaPaginada<Proveedor>
            {
                Items = resultados,
                Total = _proveedorRepositorio.ObtenerPor(x => x.Nombre.Trim().ToUpper().Contains(resultadosPaginados.TextoBusqueda.ToUpper().Trim())).Count()
            };
        }

        public IList<Proveedor> ObtenerTodosLosProveedores()
        {
            return _proveedorRepositorio.ObtenerTodo().ToList();
        }
    }
}
