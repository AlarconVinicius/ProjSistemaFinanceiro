﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProjSistemaFinanceiro.Apresentacao.DTO.Configuracao;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.Banco;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.Categoria;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.MetodoPagamento;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.NomeCartao;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.TipoConta;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.TipoControle;
using ProjSistemaFinanceiro.Apresentacao.DTO.DTOs.Transacao;
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
using ProjSistemaFinanceiro.Infraestrutura.Configuracao;
using ProjSistemaFinanceiro.Infraestrutura.Repositorio.Generico;
using ProjSistemaFinanceiro.Infraestrutura.Repositorio.Repositorios;

namespace ProjSistemaFinanceiro.Apresentacao.Ioc
{
    public static class InjecaoDependenciaConfig
    {
        public static void RegistrarServicos(this IServiceCollection services, IConfiguration configuration)
        {
            // DB
            services.AddDbContext<ContextoBase>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            //services.AddDbContext<IdentityDataContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("Way2CommerceConnection"))
            //);

            // INTERFACE E REPOSITORIO
            services.AddScoped(typeof(IGenerica<>), typeof(GenericoRepository<>));
            services.AddScoped<IBanco, BancoRepository>();
            services.AddScoped<ICategoria, CategoriaRepository>();
            services.AddScoped<IMetodoPagamento, MetodoPagamentoRepository>();
            services.AddScoped<INomeCartao, NomeCartaoRepository>();
            services.AddScoped<ITipoConta, TipoContaRepository>();
            services.AddScoped<ITipoControle, TipoControleRepository>();
            services.AddScoped<ITransacao, TransacaoRepository>();

            // SERVIÇO DOMINIO
            services.AddScoped<IBancoService, BancoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IMetodoPagamentoService, MetodoPagamentoService>();
            services.AddScoped<INomeCartaoService, NomeCartaoService>();
            services.AddScoped<ITipoContaService, TipoContaService>();
            services.AddScoped<ITipoControleService, TipoControleService>();
            services.AddScoped<ITransacaoService, TransacaoService>();

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
