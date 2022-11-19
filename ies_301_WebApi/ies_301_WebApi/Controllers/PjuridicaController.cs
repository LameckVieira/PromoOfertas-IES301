﻿using Microsoft.AspNetCore.Authorization;
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
    public class PjuridicaController : ControllerBase
    {

        private IPjuridicaRepository _pjuridicaRepository { get; set; }

        public PjuridicaController()
        {
            _pjuridicaRepository = new PjuridicaRepository();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios e um status code 200 - ok </returns>
        [Authorize (Roles = "2")]
        [HttpGet]
        public IActionResult Get()
        {
            //retorna a resposta da  requisição fazendo uma chamada para o método
            return Ok(_pjuridicaRepository.Listar());
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="NovoUsuario">objeto NovoUsuario que será cadastrado</param>
        /// <returns>um statud code 201- Created</returns>
        [HttpPost]
        public IActionResult Post(Pjuridica NovoUsuario)

        {
            //faza a chamada para o método 
            _pjuridicaRepository.Cadastrar(NovoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um pjuridica existente
        /// </summary>
        /// <param name="id">ID do pjuridica que será atualizado</param>
        /// <param name="PjuridicaAtualizada">Objeto pjuridicaAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pjuridica PjuridicaAtualizada)
        {
            // Faz a chamada para o método
            _pjuridicaRepository.Atualizar(id, PjuridicaAtualizada);

            // Retorna um status code
            return StatusCode(204);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //faz a chamada para o método
            _pjuridicaRepository.Deletar(id);

            //retorna um status code
            return StatusCode(204);

        }

        [Authorize]
        [HttpGet("meusDados/{id}")]
        public IActionResult MeusDados(int id)
        {
            try
            {


                return Ok(_pjuridicaRepository.MeusDados(id));
            }
            catch (Exception erro)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    erro
                });
            }
        }
    }
}
