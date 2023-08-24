using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using XP.Business.Interfaces;
using XP.Business.Services;
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

            builder.Services.AddMvcCore().AddApiExplorer();


            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IEmailRepository, EmailRepository>();
            builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<MeuDbContext>();

            
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwagger();
            app.MapControllers();

            app.Run();
        }
    }
}