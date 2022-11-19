﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ies_301_WebApi.Domains
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public int? IdProduto { get; set; }
        public int? IdUsuario { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoTotal { get; set; }

        public virtual Produto IdProdutoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
