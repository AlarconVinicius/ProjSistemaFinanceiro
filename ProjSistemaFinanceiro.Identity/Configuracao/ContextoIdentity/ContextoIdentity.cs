using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjSistemaFinanceiro.Identity.Entidades;

namespace ProjSistemaFinanceiro.Identity.Configuracao.ContextoIdentity
{
    public class ContextoIdentity : IdentityDbContext<ApplicationUserEntity>
    {
        public ContextoIdentity(DbContextOptions<ContextoIdentity> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserEntity>().ToTable("AspNetUsers");

            base.OnModelCreating(builder);
        }
    }
}
