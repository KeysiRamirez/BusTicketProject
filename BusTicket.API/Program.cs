
using BusTicket.Data.Context;
using BusTicket.Data.Interfaces;
using BusTicket.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusTicket.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<BoletoContext>(options => 
                                                            options.UseSqlServer(builder.Configuration.GetConnectionString("BoletoConnString")));

            builder.Services.AddTransient<IBusRepository, BusRepository>();  
            builder.Services.AddTransient<IDriver, DriverRepository>();
            builder.Services.AddTransient<IBusDriver, BusDriverRepository>();
            builder.Services.AddTransient<IRoute, RouteRepository>();

            builder.Services.AddControllers();

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}