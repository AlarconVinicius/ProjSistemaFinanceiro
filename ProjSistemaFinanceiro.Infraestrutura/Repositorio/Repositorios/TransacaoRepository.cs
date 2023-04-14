﻿using Microsoft.EntityFrameworkCore;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using ProjSistemaFinanceiro.Infraestrutura.Configuracao;
using ProjSistemaFinanceiro.Infraestrutura.Repositorio.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Infraestrutura.Repositorio.Repositorios
{
    public class TransacaoRepository : GenericoRepository<TransacaoEntity>, ITransacao
    {
        public TransacaoRepository(ContextoBase context) : base(context) {}


        public async Task<ResultadoPagina<TransacaoEntity>> ListarTransacoes(Guid? tipoControleId = null, Guid? tipoContaId = null, Guid ? transacaoId = null)
        {
            string tipoControleIdStr = tipoControleId?.ToString();
            string tipoContaIdStr = tipoContaId?.ToString();
            string transacaoIdStr = transacaoId?.ToString();

            var query = base._context.Transacoes
                .Include(t => t.TipoControle)
                .Include(t => t.Categoria)
                .Include(t => t.MetodoPagamento)
                .Include(t => t.NomeCartao)
                .Include(t => t.Banco)
                .Include(t => t.TipoConta)
                .AsQueryable();
            if (!string.IsNullOrEmpty(tipoControleIdStr))
            {
                query = query.Where(t => t.TipoControleId == tipoControleId);
            }
            if (!string.IsNullOrEmpty(tipoContaIdStr))
            {
                query = query.Where(t => t.TipoContaId == tipoContaId);
            }
            if (!string.IsNullOrEmpty(transacaoIdStr))
            {
                query = query.Where(t => t.Id == transacaoId);
            }
            var result = await query.OrderByDescending(t => t.DataPagamento).ToListAsync();
            return new ResultadoPagina<TransacaoEntity>
            {
                Resultado = result
            };

        }
    }
}
