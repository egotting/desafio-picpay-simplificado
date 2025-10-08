using desafio_picpay_simplificado.domain.data.Context;
using desafio_picpay_simplificado.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection_string = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseNpgsql(connection_string)
);
builder.Services.InjectRepositories();
builder.Services.InjectServices();
builder.Services.InjectHttpClient();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
//app.UseHttpsRedirection();


app.Run();