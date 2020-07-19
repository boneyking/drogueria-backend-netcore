using Drogueria.Core.Dominio.Entidades;
using Drogueria.Core.Dominio.Interfaces.Repositorios;
using Drogueria.Core.Infraestructura.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<RespuestaPaginada<Proveedor>> ObtenerProveedoresPaginados(ResultadosPaginados resultadosPaginados)
        {
            var saltados = resultadosPaginados.CantidadResultados * (resultadosPaginados.Pagina - 1);

            var resultados = await _proveedorRepositorio
                            .ObtenerPor(x => x.Nombre.Trim().ToUpper().Contains(resultadosPaginados.TextoBusqueda.ToUpper().Trim()))
                            .Result
                            .OrderBy(x => x.Nombre)
                            .Skip(saltados)
                            .Take(resultadosPaginados.CantidadResultados)
                            .ToListAsync();
            return new RespuestaPaginada<Proveedor>
            {
                Items = resultados,
                Total = await _proveedorRepositorio
                        .ObtenerPor(x => x.Nombre.Trim().ToUpper().Contains(resultadosPaginados.TextoBusqueda.ToUpper().Trim()))
                        .Result
                        .CountAsync()
            };
        }

        public async Task<IList<Proveedor>> ObtenerTodosLosProveedores()
        {
            return  await _proveedorRepositorio.ObtenerTodo().Result.ToListAsync();
        }
    }
}
