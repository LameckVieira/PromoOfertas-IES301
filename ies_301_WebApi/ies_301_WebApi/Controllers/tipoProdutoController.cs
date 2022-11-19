using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ies_301_WebApi.Domains;
using ies_301_WebApi.Interfaces;
using ies_301_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ies_301_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class tipoProdutoController : ControllerBase
    {

        private ITipoProdutoRepository _tipoProdutoRepository { get; set; }

        public tipoProdutoController()
        {
            _tipoProdutoRepository = new tipoProdutoRepository();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(TipoProduto novoTipoProduto)
        {
            try
            {
                _tipoProdutoRepository.Cadastrar(novoTipoProduto);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoProdutoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoProduto TipoProdutoAtualizado)
        {
            try
            {
                _tipoProdutoRepository.Atualizar(id, TipoProdutoAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _tipoProdutoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


    }
}
