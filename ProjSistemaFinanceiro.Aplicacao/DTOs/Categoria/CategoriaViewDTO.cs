﻿namespace ProjSistemaFinanceiro.Aplicacao.DTOs.Categoria
{
    public class CategoriaViewDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DataCriacao { get; set; }
        public string DataAlteracao { get; set; }
    }
}
