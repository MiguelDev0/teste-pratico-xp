using Microsoft.EntityFrameworkCore;
using XP.API.Configuration;
using XP.Business.Interfaces;
using XP.Data.Context;
using XP.Data.Ropositories;

namespace XP.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MeuDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("XpDB"));
            });
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<MeuDbContext>();

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}