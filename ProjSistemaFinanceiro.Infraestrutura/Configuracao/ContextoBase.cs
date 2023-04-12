using Microsoft.EntityFrameworkCore;
using ProjSistemaFinanceiro.Entidade.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Infraestrutura.Configuracao
{
    public class ContextoBase : DbContext
    {
        public ContextoBase(DbContextOptions<ContextoBase> options) : base(options) {}

        public DbSet<BancoEntity> Bancos { get; set; }
        public DbSet<CategoriaEntity> Categorias { get; set; }
        public DbSet<MetodoPagamentoEntity> MetodosDePagamentos { get; set; }
        public DbSet<NomeCartaoEntity> NomeCartoes { get; set; }
        public DbSet<TipoContaEntity> TipoContas { get; set; }
        public DbSet<TipoControleEntity> TipoControles { get; set; }
        public DbSet<TransacaoEntity> Transacoes { get; set; }
    }
}
