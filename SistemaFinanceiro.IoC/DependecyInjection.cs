using Microsoft.Extensions.DependencyInjection;
using SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.Application.Services;
using SistemaFinanceiro.Domain.Entities;
using SistemaFinanceiro.Domain.Interfaces;
using SistemaFinanceiro.Infrastructure.Connection;
using SistemaFinanceiro.Infrastructure.Interfaces;
using SistemaFinanceiro.Infrastructure.Repositories;

namespace SistemaFinanceiro.IoC
{
    public static class DependecyInjection
    {
        //O "this" NO PARÂMETRO DO MÉTODO (this IServiceCollection services) SIGNIFICA QUE O MÉTODO "AddInfrastructure" É UMA EXTENSÃO PERSONALIZADA DO "builder.Services" na program.cs
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //INVERSÃO DE DEPENDÊNCIA
            //AQUI, SEMPRE QUE UMA CLASSE DEPENDER O 'IDatabaseConnection' PASSO O 'DatabaseConnectionSqlServer'
            services.AddScoped<IDatabaseConnection, DatabaseConnectionSqlServer>();

            //AQUI, SEMPRE QUE UMA CLASSE DEPENDER O 'IDatabaseConnection' PASSO O 'DatabaseConnectionMySql'
            //services.AddScoped<IDatabaseConnection, DatabaseConnectionMySql>();

            //CONTROLLER
            services.AddScoped<ICategoriaServices, CategoriaService>();
            services.AddScoped<ITransacaoServices, TransacaoService>();

            //SERVICES
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();

            //REPOSITORIES
            services.AddScoped<IBaseRepository<Categoria>, BaseRepository<Categoria>>();
            services.AddScoped<IBaseRepository<Transacao>, BaseRepository<Transacao>>();

            return services;
        }
    }
}
