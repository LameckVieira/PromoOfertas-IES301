using System;
using System.Collections.Generic;

#nullable disable

namespace ies_301_WebApi.Domains
{
    public partial class Pfisica
    {
        public int IdPfisica { get; set; }
        public int? IdUsuario { get; set; }
        public string Nome { get; set; }
        public decimal Telefone { get; set; }
        public string Cpf { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
