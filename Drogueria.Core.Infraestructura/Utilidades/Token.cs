using Drogueria.Core.Dominio.Entidades;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Drogueria.Core.Infraestructura.Utilidades
{
    public static class Token
    {
        public static JwtSecurityToken CrearToken(Usuario usuario, string llaveSecreta)
        {
            var authClaims = new List<Claim>
                {
                    new Claim("UsuarioId", usuario.Id.ToString()),
                    new Claim("Roles", ObtenerRoles((List<RolUsuario>)usuario.Roles)),
                    new Claim("Autorizaciones", ObtenerAutorizaciones((List<Autorizacion>)usuario.Autorizaciones))
                };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(llaveSecreta));

            return new JwtSecurityToken(
                expires: DateTime.Now.AddHours(24),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
        }

        private static string ObtenerRoles(List<RolUsuario> listaRoles)
        {
            var roles = string.Empty;
            foreach (var rol in listaRoles)
            {
                roles += string.Format("{0},", Enum.GetName(typeof(Rol), rol.Rol));
            }
            return (roles != string.Empty) ? roles.Substring(0, roles.Length - 1) : string.Empty;
        }

        private static string ObtenerAutorizaciones(List<Autorizacion> listaAutorizaciones)
        {
            var autorizaciones = string.Empty;
            foreach (var autorizacion in listaAutorizaciones)
            {
                autorizaciones += string.Format("{0},", autorizacion.Nombre);
            }
            return (autorizaciones != string.Empty) ? autorizaciones.Substring(0, autorizaciones.Length - 1) : string.Empty;
        }
    }
}
