
using Microsoft.EntityFrameworkCore;
using VueWebApi.Models;

namespace VueWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var conn = builder.Configuration.GetConnectionString("OnlineShop_DB_Conn");
            if (conn != null)
            {
                if (conn.Contains("%ContentRootPath%"))
                {
                    conn = conn.Replace("%ContentRootPath%", builder.Environment.ContentRootPath);
                }
            }
            builder.Services.AddDbContext<OnlineShopContext>(options =>
            {
                options.UseSqlServer(conn);
            });
            //builder.Services.AddDbContext<OnlineShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineShop_DB_Conn") ?? throw new InvalidOperationException("Connection string 'webapiContext' not found.")));





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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}