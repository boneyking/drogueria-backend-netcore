using Drogueria.Core.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Drogueria.Core.Dominio.Interfaces.Repositorios
{
    public interface IAutorizacion
    {
        Task CrearAutorizacion(Autorizacion autorizacion);
        Task EliminarAutorizacion(Autorizacion autorizacion);
        Task<IList<Autorizacion>> ObtenerAutorizacionesPorResponsableId(Guid responsableId);
    }
}
