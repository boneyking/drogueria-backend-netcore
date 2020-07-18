using Drogueria.Core.Dominio.Entidades;

namespace Drogueria.Core.Dominio.Interfaces.Repositorios
{
    public interface IAutenticar
    {
        Usuario AutenticarUsuario(string rut, string password);
    }
}
