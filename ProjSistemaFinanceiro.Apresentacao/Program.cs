using FluentValidation;
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
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB
builder.Services.AddDbContext<ContextoBase>(options =>
        options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

// INTERFACE E REPOSITORIO
builder.Services.AddScoped(typeof(IGenerica<>), typeof(GenericoRepository<>));
builder.Services.AddScoped<IBanco, BancoRepository>();
builder.Services.AddScoped<ICategoria, CategoriaRepository>();
builder.Services.AddScoped<IMetodoPagamento, MetodoPagamentoRepository>();
builder.Services.AddScoped<INomeCartao, NomeCartaoRepository>();
builder.Services.AddScoped<ITipoConta, TipoContaRepository>();
builder.Services.AddScoped<ITipoControle, TipoControleRepository>();
builder.Services.AddScoped<ITransacao, TransacaoRepository>();

// SERVI�O DOMINIO
builder.Services.AddScoped<IBancoService, BancoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IMetodoPagamentoService, MetodoPagamentoService>();
builder.Services.AddScoped<INomeCartaoService, NomeCartaoService>();
builder.Services.AddScoped<ITipoContaService, TipoContaService>();
builder.Services.AddScoped<ITipoControleService, TipoControleService>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

// FluentValidation
builder.Services.AddScoped<IValidator<BancoAddDTO>, BancoAddValidator>();
builder.Services.AddScoped<IValidator<BancoUpdDTO>, BancoUpdValidator>();
builder.Services.AddScoped<IValidator<CategoriaAddDTO>, CategoriaAddValidator>();
builder.Services.AddScoped<IValidator<CategoriaUpdDTO>, CategoriaUpdValidator>();
builder.Services.AddScoped<IValidator<MetodoPagamentoAddDTO>, MetodoPagamentoAddValidator>();
builder.Services.AddScoped<IValidator<MetodoPagamentoUpdDTO>, MetodoPagamentoUpdValidator>();
builder.Services.AddScoped<IValidator<NomeCartaoAddDTO>, NomeCartaoAddValidator>();
builder.Services.AddScoped<IValidator<NomeCartaoUpdDTO>, NomeCartaoUpdValidator>();
builder.Services.AddScoped<IValidator<TipoContaAddDTO>, TipoContaAddValidator>();
builder.Services.AddScoped<IValidator<TipoContaUpdDTO>, TipoContaUpdValidator>();
builder.Services.AddScoped<IValidator<TipoControleAddDTO>, TipoControleAddValidator>();
builder.Services.AddScoped<IValidator<TipoControleUpdDTO>, TipoControleUpdValidator>();
builder.Services.AddScoped<IValidator<TransacaoAddDTO>, TransacaoAddValidator>();
builder.Services.AddScoped<IValidator<TransacaoUpdDTO>, TransacaoUpdValidator>();


// FluentValidation Auto
//builder.Services.AddFluentValidation(options =>
//{
//    // Automatic registration of validators in assembly
//    options.RegisterValidatorsFromAssembly(typeof(Program).Assembly);

//    //// Validate child properties and root collection elements
//    //options.ImplicitlyValidateChildProperties = true;
//    //options.ImplicitlyValidateRootCollectionElements = true;

//});

// Cors

builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(p => p
    .AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var cultureInfo = new CultureInfo("pt-BR");
//DateTime.Now.ToString(cultureInfo.DateTimeFormat.ShortDatePattern);
//cultureInfo.DateTimeFormat.ShortDatePattern = "dd /MM/yyyy";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
app.Run();
