using Drogueria.Core.Infraestructura.Contextos;
using Drogueria.Core.Infraestructura.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Drogueria.Core.Infraestructura.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        DrogueriaContext _contexto;

        public Repositorio()
        {
            _contexto = new DrogueriaContext();
        }

        public Repositorio(DrogueriaContext contexto)
        {
            _contexto = contexto;
        }
        public async Task Actualizar(T entidad)
        {
            _contexto.Set<T>().Update(entidad);
            await _contexto.SaveChangesAsync();
        }

        public async Task Crear(T entidad)
        {
            _contexto.Set<T>().Add(entidad);
            await _contexto.SaveChangesAsync();
        }

        public async Task Borrar(T entidad)
        {
            _contexto.Set<T>().Remove(entidad);
            await _contexto.SaveChangesAsync();
        }

        public void Dispose()
        {
            return;
        }

        public async Task<IQueryable<T>> ObtenerPor(Expression<Func<T, bool>> predicado)
        {
            return await Task.Run(() =>
            {
                return _contexto.Set<T>().Where(predicado);
            });
        }

        public async Task<IQueryable<T>> ObtenerTodo()
        {
            return await Task.Run(() =>
            {
                return _contexto.Set<T>();
            });
        }
    }
}
