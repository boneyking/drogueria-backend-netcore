using Drogueria.Core.Dominio.Entidades;
using Drogueria.Core.Infraestructura.Repositorios;
using Drogueria.Core.Servicio.Manejadores;
using System;
using System.Threading.Tasks;

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
            Console.WriteLine("Usuario {0}", DateTime.Now.ToLongTimeString());
            var usuario = Task.Run(() =>
            {
                return autenticarManejador.AutenticarUsuario("15789559-1", "123456").GetAwaiter().GetResult();
            });

            Console.WriteLine("Usuario {0} - {1}", usuario.Result, DateTime.Now.ToLongTimeString());




            //var proveedorManejador = new ProveedorManejador(new Repositorio<Proveedor>());
            //Console.WriteLine("Proveedores {0}", DateTime.Now.ToLongTimeString());
            //var proveedores = Task.Run(() => {
            //    return proveedorManejador.ObtenerTodosLosProveedores().GetAwaiter().GetResult();
            //});

            //Console.WriteLine(usuario.Result.Rut);
            //Console.WriteLine("Fin usuario {0}", DateTime.Now.ToLongTimeString());
            //foreach (var item in proveedores.Result)
            //{
            //    Console.WriteLine(item.Nombre);
            //}

            //Console.WriteLine("Fin Proveedores {0}", DateTime.Now.ToLongTimeString());

            //var resultadosPaginados = new ResultadosPaginados();
            //resultadosPaginados.CantidadResultados = 6;
            //resultadosPaginados.Pagina = 1;
            //resultadosPaginados.TextoBusqueda = "an";


            //var respuestaPaginada = proveedorManejador.ObtenerProveedoresPaginados(resultadosPaginados);
            //Console.WriteLine("Total items: {0} - Total resultados {1} - Pagina {2}", 
            //    respuestaPaginada.Total, respuestaPaginada.Items.Count, resultadosPaginados.Pagina);
            //foreach (var item in respuestaPaginada.Items)
            //{
            //    Console.WriteLine("Proveedor {0}", item.Nombre);
            //}

            //resultadosPaginados.Pagina = 2;
            //respuestaPaginada = proveedorManejador.ObtenerProveedoresPaginados(resultadosPaginados);
            //Console.WriteLine("Total items: {0} - Total resultados {1} - Pagina {2}",
            //    respuestaPaginada.Total, respuestaPaginada.Items.Count, resultadosPaginados.Pagina);
            //foreach (var item in respuestaPaginada.Items)
            //{
            //    Console.WriteLine("Proveedor {0}", item.Nombre);
            //}

            //resultadosPaginados.Pagina = 3;
            //respuestaPaginada = proveedorManejador.ObtenerProveedoresPaginados(resultadosPaginados);
            //Console.WriteLine("Total items: {0} - Total resultados {1} - Pagina {2}",
            //    respuestaPaginada.Total, respuestaPaginada.Items.Count, resultadosPaginados.Pagina);
            //foreach (var item in respuestaPaginada.Items)
            //{
            //    Console.WriteLine("Proveedor {0}", item.Nombre);
            //}


            //resultadosPaginados.Pagina = 4;
            //respuestaPaginada = proveedorManejador.ObtenerProveedoresPaginados(resultadosPaginados);
            //Console.WriteLine("Total items: {0} - Total resultados {1} - Pagina {2}",
            //    respuestaPaginada.Total, respuestaPaginada.Items.Count, resultadosPaginados.Pagina);
            //foreach (var item in respuestaPaginada.Items)
            //{
            //    Console.WriteLine("Proveedor {0}", item.Nombre);
            //}


            //resultadosPaginados.Pagina = 1;
            //respuestaPaginada = proveedorManejador.ObtenerProveedoresPaginados(resultadosPaginados);
            //Console.WriteLine("Total items: {0} - Total resultados {1} - Pagina {2}",
            //    respuestaPaginada.Total, respuestaPaginada.Items.Count, resultadosPaginados.Pagina);
            //foreach (var item in respuestaPaginada.Items)
            //{
            //    Console.WriteLine("Proveedor {0}", item.Nombre);
            //}

            Console.ReadLine();
        }
    }
}
