using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetoCarrinhoProdutos.Repositories;
using ProjetoCarrinhoProdutos.Services;
using System.Text;
using Microsoft.OpenApi.Models;
using ProjetoCarrinhoProdutos.Controllers;

namespace ProjetoCarrinhoProdutos
{
    public class Program
    {
        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GabiniBackEnd", Version = "v1" });
            });
        }

        private static void InjectRepositoryDependency(IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<CarrinhoDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        }

        private static void AddControllersAndDependencies(IHostApplicationBuilder builder)
        {
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

            // Configurar CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            builder.Services.AddScoped<ProdutoService>();
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<CarrinhoService>();
            builder.Services.AddScoped<AuthService>();

            builder.Services.AddScoped<ProdutoRepository>();
            builder.Services.AddScoped<CarrinhoRepository>();
            builder.Services.AddScoped<UsuarioRepository>();
        }

        private static void InitializeSwagger(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureSwagger(builder.Services);
            InjectRepositoryDependency(builder);
            AddControllersAndDependencies(builder);

            var app = builder.Build();
            await Seeder.SeedAsync(app);

            if (app.Environment.IsDevelopment())
            {
                InitializeSwagger(app);
            }

            // Usar a política de CORS
            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
