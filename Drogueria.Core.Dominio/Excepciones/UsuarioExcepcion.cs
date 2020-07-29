using System;

namespace Drogueria.Core.Dominio.Excepciones
{
    public class UsuarioExcepcion : Exception
    {
        public UsuarioExcepcion() { }

        public UsuarioExcepcion(string mensaje) : base(mensaje) { }

        public UsuarioExcepcion(string mensaje, Exception inner) : base(mensaje, inner) { }
    }
}
