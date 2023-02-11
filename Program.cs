using ApiBurguer.Data;
using ApiBurguer.Infra.Repositories;
using ApiBurguer.Infra.Repositories.Interfaces;
using ApiBurguer.Infra.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("server=localhost,1433;database=apiburguer;user id=sa;password=@Aa9988554400;TrustServerCertificate=True"));
builder.Services.AddScoped<IBaseRepository,BaseRepository>();
builder.Services.AddScoped<PaoService>();
builder.Services.AddScoped<IPaoRepository,PaoRepository>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<MolhoService>();
builder.Services.AddScoped<IMolhoRepository,MolhoRepository>();
builder.Services.AddScoped<CarneService>();
builder.Services.AddScoped<ICarneRepository,CarneRepository>();
builder.Services.AddScoped<BebidaService>();
builder.Services.AddScoped<IBebidaRepository,BebidaRepository>();
builder.Services.AddScoped<AcompanhamentoService>();
builder.Services.AddScoped<IAcompanhamentoRepository,AcompanhamentoRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
