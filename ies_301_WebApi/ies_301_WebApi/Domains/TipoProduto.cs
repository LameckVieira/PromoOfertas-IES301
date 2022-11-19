using System;
using System.Collections.Generic;

#nullable disable

namespace ies_301_WebApi.Domains
{
    public partial class TipoProduto
    {
        public TipoProduto()
        {
            Produtos = new HashSet<Produto>();
        }

        public int IdTipoProduto { get; set; }
        public string NomeTipoProduto { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
