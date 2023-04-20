using ProjSistemaFinanceiro.Apresentacao.Extensoes;
using ProjSistemaFinanceiro.Apresentacao.Ioc;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Cors
builder.Services.AddCors();

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddAuthentication(builder.Configuration);
// Injeção de Dependência
builder.Services.RegistrarServicos(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors(p => p
    .AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod());
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

var cultureInfo = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
app.Run();
