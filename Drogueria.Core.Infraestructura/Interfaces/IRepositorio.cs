using System;
using System.Linq;
using System.Linq.Expressions;

namespace Drogueria.Core.Infraestructura.Interfaces
{
    public interface IRepositorio<T> : IDisposable
    {
        void Crear(T entidad);
        void Borrar(T entidad);
        void Actualizar(T entidad);
        IQueryable<T> ObtenerTodo();
        IQueryable<T> ObtenerPor(Expression<Func<T, bool>> predicado);
    }
}
