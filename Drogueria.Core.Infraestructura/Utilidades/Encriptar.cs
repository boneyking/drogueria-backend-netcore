using System;
using System.Text;

namespace Drogueria.Core.Infraestructura.Utilidades
{
    public static class Encriptar
    {
        private static string LlaveSecreta = @"1aqe2@/(&%#()('999283564jkjkclq:;[]{}´´";
        private static string LlaveSecretaToken = @"soyunallavecitaindefensa";

        public static string EncriptarTexto(string texto)
        {
            texto += LlaveSecreta;
            var textoEnBytes = Encoding.UTF8.GetBytes(texto);
            return Convert.ToBase64String(textoEnBytes);            
        }

        public static string DesencriptarTexto(string texto)
        {
            var base64EncodeBytes = Convert.FromBase64String(texto);
            var resultado = Encoding.UTF8.GetString(base64EncodeBytes);
            resultado = resultado.Substring(0, resultado.Length - LlaveSecreta.Length);
            return resultado;
        }

    }
}
