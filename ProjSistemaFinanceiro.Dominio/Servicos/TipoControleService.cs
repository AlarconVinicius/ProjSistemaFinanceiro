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
    public class TipoControleService : ITipoControleService
    {
        private readonly ITipoControle _iTipoControle;

        public TipoControleService(ITipoControle iTipoControle)
        {
            _iTipoControle = iTipoControle;
        }
        public async Task AdicionarTipoControle(TipoControleEntity objeto)
        {
            objeto.DataCriacao = DateTime.Now;
            objeto.DataAlteracao = DateTime.Now;
            await _iTipoControle.Adicionar(objeto);
        }

        public async Task AtualizarTipoControle(TipoControleEntity objeto)
        {
            objeto.DataAlteracao = DateTime.Now;
            await _iTipoControle.Atualizar(objeto);
        }

        public async Task DeletarTipoControle(Guid id)
        {
            await _iTipoControle.Deletar(id);
        }

        public async Task<ResultadoPagina<TipoControleEntity>> ListarTiposControle(Guid? tipoControleId = null)
        {
            return await _iTipoControle.ListarTiposControle(tipoControleId);
        }
    }
}
