using Drogueria.Core.Dominio.Entidades;
using Drogueria.Core.Infraestructura.Repositorios;
using Drogueria.Core.Servicio.Manejadores;
using System;

namespace Drogueria.Core.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var usuarioManejador = new UsuarioManejador(new Repositorio<Usuario>());

            //Console.WriteLine("Existe usuario con Rut 15789559-1 {0}", usuarioManejador.ExisteUsuarioPorRut("15789559-1") ? "Si" : "No");

            //var usuario = usuarioManejador.ObtenerPorRut("15789559-1");

            //var usuarios = usuarioManejador.ObtenerUsuarios();

            var autenticarManejador = new AutenticarManejador(new Repositorio<Usuario>());
            try
            {
                var usuario = autenticarManejador.AutenticarUsuario("15789559-1", "123343456");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            Console.ReadLine();
        }
    }
}
