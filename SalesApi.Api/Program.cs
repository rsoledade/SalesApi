using SalesApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SalesApi.Application.Services;
using SalesApi.Application.Interfaces;
using SalesApi.Application.Configuration;
using SalesApi.Application.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Conex�o com o PostgreSQL
builder.Services.AddDbContext<SalesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Servi�os de aplica��o
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddInfrastructure();

var app = builder.Build();

// Configura��o do pipeline de requisi��es
if (app.Environment.IsDevelopment())
{
    // Op��es de configura��o para desenvolvimento, se necess�rio
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
