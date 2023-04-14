using Microsoft.EntityFrameworkCore;
using ProjSistemaFinanceiro.Apresentacao.DTO.Configuracao;
using ProjSistemaFinanceiro.Dominio.Interfaces.IClasses;
using ProjSistemaFinanceiro.Dominio.Interfaces.IGenerica;
using ProjSistemaFinanceiro.Dominio.Interfaces.IServicos;
using ProjSistemaFinanceiro.Dominio.Servicos;
using ProjSistemaFinanceiro.Infraestrutura.Configuracao;
using ProjSistemaFinanceiro.Infraestrutura.Repositorio.Generico;
using ProjSistemaFinanceiro.Infraestrutura.Repositorio.Repositorios;

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

// SERVIÇO DOMINIO
builder.Services.AddScoped<IBancoService, BancoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IMetodoPagamentoService, MetodoPagamentoService>();
builder.Services.AddScoped<INomeCartaoService, NomeCartaoService>();
builder.Services.AddScoped<ITipoContaService, TipoContaService>();
builder.Services.AddScoped<ITipoControleService, TipoControleService>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
