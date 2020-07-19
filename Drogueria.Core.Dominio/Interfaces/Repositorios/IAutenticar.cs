using Drogueria.Core.Dominio.Entidades;
using System.Threading.Tasks;

namespace Drogueria.Core.Dominio.Interfaces.Repositorios
{
    public interface IAutenticar
    {
        Task<Usuario> AutenticarUsuario(string rut, string password);
    }
}
