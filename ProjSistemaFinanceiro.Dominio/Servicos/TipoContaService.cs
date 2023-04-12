using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
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
    public class TipoContaService : ITipoContaService
    {
        private readonly ITipoConta _iTipoConta;

        public TipoContaService(ITipoConta iTipoConta)
        {
            _iTipoConta = iTipoConta;
        }
        public async Task AdicionarTipoConta(TipoContaEntity objeto)
        {
            objeto.DataCriacao = DateTime.Now;
            objeto.DataAlteracao = DateTime.Now;
            await _iTipoConta.Adicionar(objeto);
        }

        public async Task AtualizarTipoConta(TipoContaEntity objeto)
        {
            objeto.DataAlteracao = DateTime.Now;
            await _iTipoConta.Atualizar(objeto);
        }

        public async Task DeletarTipoConta(TipoContaEntity objeto)
        {
            await _iTipoConta.Deletar(objeto);
        }

        public async Task<ResultadoPagina<TipoContaEntity>> ListarTiposConta(Guid? tipoContaId = null)
        {
            return await _iTipoConta.ListarTiposConta(tipoContaId);
        }
    }
}
