using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Wes.Estudos.BoasPraticas.WebApi.Jwt.Models;

namespace Wes.Estudos.BoasPraticas.WebApi.Jwt.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private List<Usuario> _usuarios = new List<Usuario>
        {
            new Usuario { FullName = "Wendel Estrada", UserName = "admin", Password = "1234", UserRole = "Admin" },
            new Usuario { FullName = "Test Usuario", UserName = "user", Password = "1234", UserRole = "User" }
        };

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Usuario login)
        {
            Usuario usuario = AutenticarUsuario(login);
            if (usuario != null)
            {
                var tokenString = GenerateJWTToken(usuario);
                return Ok(tokenString);
            }
            return Unauthorized();
        }

        private string GenerateJWTToken(Usuario informacoesDoUsuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, informacoesDoUsuario.UserName),
                new Claim("fullName", informacoesDoUsuario.FullName),
                new Claim("role",informacoesDoUsuario.UserRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Usuario AutenticarUsuario(Usuario loginCredentials)
        {
            Usuario Usuario = _usuarios.SingleOrDefault(x => x.UserName == loginCredentials.UserName && x.Password == loginCredentials.Password);
            return Usuario;
        }
    }
}
