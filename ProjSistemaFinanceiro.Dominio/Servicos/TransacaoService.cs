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
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacao _iTransacao;

        public TransacaoService(ITransacao iTransacao)
        {
            _iTransacao = iTransacao;
        }
        public async Task AdicionarTransacao(TransacaoEntity objeto)
        {
            objeto.DataCriacao = DateTime.Now;
            objeto.DataAlteracao = DateTime.Now;
            await _iTransacao.Adicionar(objeto);
        }

        public async Task AtualizarTransacao(TransacaoEntity objeto)
        {
            objeto.DataAlteracao = DateTime.Now;
            await _iTransacao.Atualizar(objeto);
        }

        public async Task DeletarTransacao(TransacaoEntity objeto)
        {
            await _iTransacao.Deletar(objeto);
        }

        public async Task<ResultadoPagina<TransacaoEntity>> ListarTransacoes(Guid? transacaoId = null)
        {
            return await _iTransacao.ListarTransacoes(transacaoId);
        }
    }
}
