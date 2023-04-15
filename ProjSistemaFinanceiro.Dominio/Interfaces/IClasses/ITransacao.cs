﻿using ProjSistemaFinanceiro.Dominio.Interfaces.IGenerica;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Entidade.Filtros;
using ProjSistemaFinanceiro.Entidade.ResultadoPaginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Dominio.Interfaces.IClasses
{
    public interface ITransacao : IGenerica<TransacaoEntity>
    {
        Task AdicionarTransacoes(List<TransacaoEntity> listaObjeto);
        Task AtualizarTransacao(TransacaoEntity objeto);
        Task<ResultadoPagina<TransacaoEntity>> ListarTransacoes(TransacaoFiltro? filtro = null);
    }
}
