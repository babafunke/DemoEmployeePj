
using DemoEmployeePj.Data;
using DemoEmployeePj.Managers;
using DemoEmployeePj.Mappers;
using DemoEmployeePj.Repo;
using Microsoft.EntityFrameworkCore;

namespace DemoEmployeePj
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
            builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DemoEmployeeDbConnection")));
            builder.Services.AddScoped<IEmployeeMapper, EmployeeMapper>();
            builder.Services.AddScoped<IRepoService, SqlServerRepoService>();
            builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();

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
