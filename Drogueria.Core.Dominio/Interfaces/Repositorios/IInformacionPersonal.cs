using Drogueria.Core.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Drogueria.Core.Dominio.Interfaces.Repositorios
{
    public interface IInformacionPersonal
    {
        Task CrearInformacionPersonal(InformacionPersonal informacionPersonal);
        Task ActualizarInformacionPersonal(InformacionPersonal informacionPersonal);
    }
}
