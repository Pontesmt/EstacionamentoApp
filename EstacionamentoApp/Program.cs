using EstacionamentoApp.Domain.Services;
using EstacionamentoApp.Domain.Interfaces.Repositories;
using EstacionamentoApp.Domain.Interface;
using EstacionamentoApp.Infra.Data.Repositories;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();



builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configurar as injeções de dependencia do projeto?

builder.Services.AddTransient
    <IVeiculoDomainService, VeiculoDomainService>();

builder.Services.AddTransient
    <IVeiculoRepository, VeiculoRepository>();

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
