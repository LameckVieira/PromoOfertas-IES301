using ies_301_WebApi.Contexts;
using ies_301_WebApi.Domains;
using ies_301_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ies_301_WebApi.Repositories
{
    public class tipoProdutoRepository : ITipoProdutoRepository
    {

        //JaReserveiContext ctx = new JaReserveiContext();
        OfertasContext ctx = new OfertasContext();

        public void Atualizar(int id, TipoProduto TipoProdutoAtualizado)
        {
            TipoProduto tipoprodutoBuscado = ctx.TipoProdutos.Find(id);

            if (TipoProdutoAtualizado != null)
            {
                TipoProdutoAtualizado.NomeTipoProduto = TipoProdutoAtualizado.NomeTipoProduto;
            }

            ctx.TipoProdutos.Update(tipoprodutoBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(TipoProduto novoTipoProduto)
        {

            ctx.TipoProdutos.Add(novoTipoProduto);
            ctx.SaveChanges();

        }

        public void Deletar(int id)
        {
            TipoProduto TipoProdutoBuscado = ctx.TipoProdutos.Find(id);

            //remove a classe buscada
            ctx.TipoProdutos.Remove(TipoProdutoBuscado);

            //salvas as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<TipoProduto> Listar()
        {
            return ctx.TipoProdutos.ToList();
        }
    }
}
