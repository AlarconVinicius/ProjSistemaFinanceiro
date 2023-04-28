using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjSistemaFinanceiro.Aplicacao.DTOs.Transacao;
using ProjSistemaFinanceiro.Aplicacao.DTOs.Usuario;
using ProjSistemaFinanceiro.Entidade.Entidades;
using ProjSistemaFinanceiro.Identity.Entidades;
using System.Drawing;

namespace ProjSistemaFinanceiro.Apresentacao.Mapeamentos.Transacao
{
    public class TransacaoMapping
    {
        public TransacaoViewDTO MapToGetDTO(TransacaoEntity objeto)
        {
            if (objeto == null)
            {
                throw new Exception("Transação não encontrado.");
            }
            return new TransacaoViewDTO
            {
                Id = objeto.Id,
                TipoControle = objeto.TipoControle.Nome,
                Categoria = objeto.Categoria.Nome,
                Banco = objeto.Banco.Nome,
                TipoConta = objeto.TipoConta.Nome,
                MetodoPagamento = objeto.MetodoPagamento.Nome,
                NomeCartao = objeto.NomeCartao.Nome,
                Nome = objeto.Nome,
                Descricao = objeto.Descricao,
                Estabelecimento = objeto.Estabelecimento,
                Status = objeto.ObterStatus(),
                Valor = objeto.Valor,
                Entrada = objeto.Entrada,
                Pago = objeto.Pago,
                DataCompra = objeto.DataCompra.ToString("dd/MM/yyyy"),
                DataPagamento = objeto.DataPagamento.ToString("dd/MM/yyyy"),
                DataCriacao = objeto.DataCriacao.ToString("dd/MM/yyyy"),
                DataAlteracao = objeto.DataAlteracao.ToString("dd/MM/yyyy"),
            };
        }
        //DateTime.ParseExact(objeto.DataCompraStr, "dd/MM/yyyy", null);
    }
}
