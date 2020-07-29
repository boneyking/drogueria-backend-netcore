using Drogueria.Core.Dominio.Entidades;
using System.Threading.Tasks;

namespace Drogueria.Core.Dominio.Interfaces.Repositorios
{
    public interface IInformacionPersonal
    {
        Task CrearInformacionPersonal(InformacionPersonal informacionPersonal);
        Task ActualizarInformacionPersonal(InformacionPersonal informacionPersonal);
    }
}
