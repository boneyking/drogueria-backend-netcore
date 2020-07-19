using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Drogueria.Core.Infraestructura.Interfaces
{
    public interface IRepositorio<T> : IDisposable
    {
        Task Crear(T entidad);
        Task Borrar(T entidad);
        Task Actualizar(T entidad);
        Task<IQueryable<T>> ObtenerTodo();
        Task<IQueryable<T>> ObtenerPor(Expression<Func<T, bool>> predicado);
    }
}
