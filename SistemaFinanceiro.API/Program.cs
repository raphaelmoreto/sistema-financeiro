using OfficeOpenXml;
using SistemaFinanceiro.IoC;

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

            //CLASSE ABSTRATA ONDE FICAR� TODAS AS INJE��ES DE DEPEND�NCIAS
            DependecyInjection.AddInfrastructure(builder.Services);

            ExcelPackage.License.SetNonCommercialPersonal("BlaBlaBla");

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
