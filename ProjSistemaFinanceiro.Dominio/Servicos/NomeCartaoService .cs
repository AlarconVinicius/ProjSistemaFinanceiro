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
    public class NomeCartaoService : INomeCartaoService
    {
        private readonly INomeCartao _iNomeCartao;

        public NomeCartaoService(INomeCartao iNomeCartao)
        {
            _iNomeCartao = iNomeCartao;
        }
        public async Task AdicionarNomeCartao(NomeCartaoEntity objeto)
        {
            objeto.DataCriacao = DateTime.Now;
            objeto.DataAlteracao = DateTime.Now;
            await _iNomeCartao.Adicionar(objeto);
        }

        public async Task AtualizarNomeCartao(NomeCartaoEntity objeto)
        {
            objeto.DataAlteracao = DateTime.Now;
            await _iNomeCartao.Atualizar(objeto);
        }

        public async Task DeletarNomeCartao(Guid id)
        {
            await _iNomeCartao.Deletar(id);
        }

        public async Task<ResultadoPagina<NomeCartaoEntity>> ListarNomeCartoes(Guid? nomeCartaoId = null)
        {
            return await _iNomeCartao.ListarNomeCartoes(nomeCartaoId);
        }
    }
}
