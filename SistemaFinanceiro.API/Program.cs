using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Application.Services;
using SistemaFinanceiro.Domain.Interfaces;
using SistemaFinanceiro.Infrastructure.Connection;
using SistemaFinanceiro.Infrastructure.Interfaces;
using SistemaFinanceiro.Infrastructure.Repositories;

namespace SistemaFinanceiro.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //INVERSÃO DE DEPENDÊNCIA
            //AQUI, SEMPRE QUE UMA CLASSE DEPENDER O 'IDatabaseConnection' PASSO O 'DatabaseConnectionSqlServer'
            builder.Services.AddScoped<IDatabaseConnection, DatabaseConnectionSqlServer>();

            //AQUI, SEMPRE QUE UMA CLASSE DEPENDER O 'IDatabaseConnection' PASSO O 'DatabaseConnectionMySql'
            //builder.Services.AddScoped<IDatabaseConnection, DatabaseConnectionMySql>();

            //CONTROLLER
            builder.Services.AddScoped<ICategoriaServices, CategoriaService>();
            builder.Services.AddScoped<ITransacaoServices, TransacaoService>();

            //SERVICES
            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();

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
        }
    }
}
