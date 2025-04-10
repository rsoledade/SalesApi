using SalesApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SalesApi.Application.Services;
using SalesApi.Application.Interfaces;
using SalesApi.Application.Configuration;
using SalesApi.Application.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Conexão com o PostgreSQL
builder.Services.AddDbContext<SalesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Serviços de aplicação
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddInfrastructure();

var app = builder.Build();

// Configuração do pipeline de requisições
if (app.Environment.IsDevelopment())
{
    // Opções de configuração para desenvolvimento, se necessário
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
