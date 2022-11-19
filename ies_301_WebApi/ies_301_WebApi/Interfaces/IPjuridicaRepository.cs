﻿using ies_301_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ies_301_WebApi.Interfaces
{
    interface IPjuridicaRepository
    {
        /// <sumamary>
        /// Lista todas os Pjuridicas
        /// </sumamary>
        /// <returns>umaa lista de Pjuridicas</returns>
        List<Pjuridica> Listar();

        /// <sumamary>
        /// Busca uma Pjuridica através do ID
        /// </sumamary>
        /// <param name="id">ID do Pjuridica que será buscada</param>
        /// <returns>uma Pjuridica buscada</returns>
        Pjuridica BuscarPorId(int id);

        /// <sumamary>
        /// Cadastra uma nova Pjuridica
        /// </sumamary>
        /// <param name="novaPjuridica">Objeto novaPjuridica que será cadastrado</param>
        void Cadastrar(Pjuridica novaPjuridica);

        /// <sumamary>
        /// Deleta uma Pjuridica existente
        /// </sumamary>
        /// <param name="id">ID do Pjuridica que será deletado</param>
        void Deletar(int id);


        /// <sumamary>
        /// Atualiza uma Pjuridica existente
        /// </sumamary>
        /// <param name="id">ID do Pjuridica que será Atualizada</param>
        /// <param name="PjuridicaAtualizada">Objeto PjuridicaAtualizada com as novas informações</param>
        void Atualizar(int id, Pjuridica PjuridicaAtualizada);

        /// <summary>
        /// Lista apenas os dados do usuário
        /// </summary>
        /// <param name="idUsuario">id do usuário a ser buscado</param>
        /// <returns> Dados buscado</returns>
        List<Pjuridica> MeusDados(int idUsuario);

        /// <summary>
        /// Lista apenas os dados do usuário
        /// </summary>
        /// <param name="idUsuario">id do usuário a ser buscado</param>
        /// <returns> Dados buscado</returns>
        void AtualizarMeusDados(int idUsuario, Pjuridica PjuridicaAtualizada, Usuario UsuarioAtualizado);
    }
}
