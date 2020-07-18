using Drogueria.Core.Infraestructura.Contextos;
using Drogueria.Core.Infraestructura.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

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
        public async void Actualizar(T entidad)
        {
            _contexto.Set<T>().Update(entidad);
            await _contexto.SaveChangesAsync();
        }

        public async void Crear(T entidad)
        {
            _contexto.Set<T>().Add(entidad);
            await _contexto.SaveChangesAsync();
        }

        public async void Borrar(T entidad)
        {
            _contexto.Set<T>().Remove(entidad);
            await _contexto.SaveChangesAsync();
        }

        public void Dispose()
        {
            return;
        }

        public IQueryable<T> ObtenerPor(Expression<Func<T, bool>> predicado)
        {
            return _contexto.Set<T>().Where(predicado);
        }

        public IQueryable<T> ObtenerTodo()
        {
            return _contexto.Set<T>();
        }
    }
}
