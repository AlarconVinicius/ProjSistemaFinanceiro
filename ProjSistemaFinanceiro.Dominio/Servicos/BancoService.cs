﻿using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Dominio.Servicos
{
    public class BancoService : IBancoService
    {
        private readonly IBanco _iBanco;
        public BancoService(IBanco iBanco)
        {
            _iBanco = iBanco;
        }

        public async Task AdicionarBanco(BancoEntity objeto)
        {
            objeto.DataCriacao = DateTime.Now;
            objeto.DataAlteracao = DateTime.Now;
            await _iBanco.Adicionar(objeto);
        }

        public async Task AtualizarBanco(BancoEntity objeto)
        {
            objeto.DataAlteracao = DateTime.Now;
            await _iBanco.Atualizar(objeto);
        }

        public async Task DeletarBanco(BancoEntity objeto)
        {
            await _iBanco.Deletar(objeto);
        }

        public async Task<ResultadoPagina<BancoEntity>> ListarBancos(Guid? bancoId = null)
        {
            return await _iBanco.ListarBancos(bancoId);
        }
    }
}