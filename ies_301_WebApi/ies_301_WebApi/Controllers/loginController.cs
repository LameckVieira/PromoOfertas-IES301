using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ies_301_WebApi.Domains;
using ies_301_WebApi.Interfaces;
using ies_301_WebApi.Repositories;
using ies_301_WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ies_301_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Objeto _UsuarioRepository que irá receber todos os métodos definidos na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _UsuarioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        
        [HttpPost]
        public IActionResult Login(Usuario login)
        {
            //Busca o usuário pelo e-mail e senha
            Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

            //Caso não encontre nenhum usuário com o e-mail e senha informados
            if (usuarioBuscado == null)
            {
                //retorna NotFound com uma mensagem personalizada
                return NotFound("E-mail ou senha inválidos!");
            }

            //Caso encontre um token será criado

            //Dados fornceidos no token (Payload)
            var claims = new[]
            {
                                              //Tipo da claim + seu valor
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim("role", usuarioBuscado.IdTipoUsuario.ToString()),
                new Claim("name", usuarioBuscado.NomeUsuario),
                //new Claim(JwtRegisteredClaimNames.GivenName, usuarioBuscado.NomeUsuario)



            };

            //Chave de acesso do token          Valor codificado
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Kelm-chave-autenticacao"));

            //Credenciais do token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Gera o token 
            var token = new JwtSecurityToken(

                issuer: "ies_301_WebApi",                 // emissor do token
                audience: "ies_301_WebApi",               // destinatário do token
                claims: claims,                             // dados de definidos "claims (linha 53)"
                expires: DateTime.Now.AddMinutes(45),       // tempo de expiração (05:38)
                signingCredentials: creds                   // credenciais do token 
            );

            //Retorna um satus code 200 (Token foi criado)
            return Ok(new
            {

                token = new JwtSecurityTokenHandler().WriteToken(token)

            });

        }

    }
}
