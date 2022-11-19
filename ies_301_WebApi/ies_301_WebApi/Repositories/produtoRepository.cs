using Microsoft.EntityFrameworkCore;
using ies_301_WebApi.Contexts;
using ies_301_WebApi.Domains;
using ies_301_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ies_301_WebApi.Repositories
{
    public class produtoRepository : IProdutoRepository
    {

        //JaReserveiContext ctx = new JaReserveiContext();
        OfertasContext ctx = new OfertasContext();

        public void Atualizar(int id, Produto produtoAtualizado)
        {
            Produto produtoBuscado = ctx.Produtos.Find(id);

            if (produtoAtualizado.NomeProduto != null)
            {
                produtoAtualizado.NomeProduto = produtoAtualizado.NomeProduto;
            }

            if (produtoAtualizado != null)
            {
                produtoBuscado.Quantidade = produtoAtualizado.Quantidade;
            }

            if (produtoAtualizado.Descricao != null)
            {
                produtoBuscado.Descricao = produtoAtualizado.Descricao;
            }

            if (produtoAtualizado.LinkProduto != null)
            {
                produtoBuscado.LinkProduto = produtoAtualizado.LinkProduto;
            }

            if (produtoAtualizado.ImagemProduto != null)
            {
                produtoBuscado.ImagemProduto = produtoAtualizado.ImagemProduto;
            }

            if (produtoAtualizado != null)
            {
                produtoBuscado.Preco = produtoAtualizado.Preco;
            }

            if (produtoAtualizado.IdTipoProduto != null)
            {
                produtoBuscado.IdTipoProduto = produtoAtualizado.IdTipoProduto;
            }

            ctx.Produtos.Update(produtoBuscado);

            ctx.SaveChanges();

        }

        public Produto BuscarPorId(int id)  
        {
            return ctx.Produtos
                .Select(s => new Produto()
                {
                    IdProduto = s.IdProduto,
                    NomeProduto = s.NomeProduto,
                    Quantidade = s.Quantidade,
                    Preco = s.Preco,
                    LinkProduto = s.LinkProduto,
                    ImagemProduto = s.ImagemProduto,
                    IdTipoProduto = s.IdTipoProduto,

                    Descricao = s.Descricao,




                })
                .FirstOrDefault(s => s.IdProduto == id);
        }

        public void Cadastrar(Produto novoProduto)
        {
            ctx.Produtos.Add(novoProduto);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Produtos.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Produto> Listar()
        {
            return ctx.Produtos.ToList();
        }


        public List<Produto> ListarMeusProdutos(int IdUsuario)
        {
            return ctx.Produtos

             .Include(c => c.IdUsuarioNavigation)

             .Where(c => c.IdUsuarioNavigation.IdUsuario == IdUsuario)

             .ToList();
        }
    }
    }


