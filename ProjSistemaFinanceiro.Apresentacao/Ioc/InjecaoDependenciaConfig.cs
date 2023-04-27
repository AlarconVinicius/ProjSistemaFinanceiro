using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjSistemaFinanceiro.Apresentacao.DTO.Configuracao;
using ProjSistemaFinanceiro.Aplicacao.DTOs.Banco;
using ProjSistemaFinanceiro.Aplicacao.DTOs.Categoria;
using ProjSistemaFinanceiro.Aplicacao.DTOs.MetodoPagamento;
using ProjSistemaFinanceiro.Aplicacao.DTOs.NomeCartao;
using ProjSistemaFinanceiro.Aplicacao.DTOs.TipoConta;
using ProjSistemaFinanceiro.Aplicacao.DTOs.TipoControle;
using ProjSistemaFinanceiro.Aplicacao.DTOs.Transacao;
using ProjSistemaFinanceiro.Aplicacao.Interfaces.IServicos;
using ProjSistemaFinanceiro.Apresentacao.Validadores.Banco;
using ProjSistemaFinanceiro.Apresentacao.Validadores.Categoria;
using ProjSistemaFinanceiro.Apresentacao.Validadores.MetodoPagamento;
using ProjSistemaFinanceiro.Apresentacao.Validadores.NomeCartao;
using ProjSistemaFinanceiro.Apresentacao.Validadores.TipoConta;
using ProjSistemaFinanceiro.Apresentacao.Validadores.TipoControle;
using ProjSistemaFinanceiro.Apresentacao.Validadores.Transacao;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IGenerica;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Dominio.Servicos;
using ProjSistemaFinanceiro.Identity.Configuracao.ContextoIdentity;
using ProjSistemaFinanceiro.Identity.Servicos;
using ProjSistemaFinanceiro.Infraestrutura.Configuracao;
using ProjSistemaFinanceiro.Infraestrutura.Repositorio.Generico;
using ProjSistemaFinanceiro.Infraestrutura.Repositorio.Repositorios;
using ProjSistemaFinanceiro.Identity.Entidades;

namespace ProjSistemaFinanceiro.Apresentacao.IoC
{
    public static class InjecaoDependenciaConfig
    {
        public static void RegistrarServicos(this IServiceCollection services, IConfiguration configuration)
        {
            // CONTEXTOS
            services.AddDbContext<ContextoBase>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddDbContext<ContextoIdentity>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddDefaultIdentity<ApplicationUserEntity>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ContextoIdentity>()
                .AddDefaultTokenProviders();


            // INTERFACE E REPOSITORIO
            services.AddScoped(typeof(IGenerica<>), typeof(GenericoRepository<>));
            services.AddScoped<IBanco, BancoRepository>();
            services.AddScoped<ICategoria, CategoriaRepository>();
            services.AddScoped<IMetodoPagamento, MetodoPagamentoRepository>();
            services.AddScoped<INomeCartao, NomeCartaoRepository>();
            services.AddScoped<ITipoConta, TipoContaRepository>();
            services.AddScoped<ITipoControle, TipoControleRepository>();
            services.AddScoped<ITransacao, TransacaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // SERVIÇO DOMINIO
            services.AddScoped<IBancoService, BancoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IMetodoPagamentoService, MetodoPagamentoService>();
            services.AddScoped<INomeCartaoService, NomeCartaoService>();
            services.AddScoped<ITipoContaService, TipoContaService>();
            services.AddScoped<ITipoControleService, TipoControleService>();
            services.AddScoped<ITransacaoService, TransacaoService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            // AutoMapper
            services.AddAutoMapper(typeof(AutoMapperConfig));

            // FluentValidation
            services.AddScoped<IValidator<BancoAddDTO>, BancoAddValidator>();
            services.AddScoped<IValidator<BancoUpdDTO>, BancoUpdValidator>();
            services.AddScoped<IValidator<CategoriaAddDTO>, CategoriaAddValidator>();
            services.AddScoped<IValidator<CategoriaUpdDTO>, CategoriaUpdValidator>();
            services.AddScoped<IValidator<MetodoPagamentoAddDTO>, MetodoPagamentoAddValidator>();
            services.AddScoped<IValidator<MetodoPagamentoUpdDTO>, MetodoPagamentoUpdValidator>();
            services.AddScoped<IValidator<NomeCartaoAddDTO>, NomeCartaoAddValidator>();
            services.AddScoped<IValidator<NomeCartaoUpdDTO>, NomeCartaoUpdValidator>();
            services.AddScoped<IValidator<TipoContaAddDTO>, TipoContaAddValidator>();
            services.AddScoped<IValidator<TipoContaUpdDTO>, TipoContaUpdValidator>();
            services.AddScoped<IValidator<TipoControleAddDTO>, TipoControleAddValidator>();
            services.AddScoped<IValidator<TipoControleUpdDTO>, TipoControleUpdValidator>();
            services.AddScoped<IValidator<TransacaoAddDTO>, TransacaoAddValidator>();
            services.AddScoped<IValidator<TransacaoUpdDTO>, TransacaoUpdValidator>();
        }
    }
}
