﻿using ProjSistemaFinanceiro.Dominio.Interfaces.IGenerica;
using ProjSistemaFinanceiro.Entidade.Entidades;
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
        Task<ResultadoPagina<TransacaoEntity>> ListarTransacoes(Guid? transacaoId = null);
    }
}
