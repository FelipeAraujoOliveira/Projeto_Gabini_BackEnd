using Microsoft.EntityFrameworkCore;
using GabiniBackEnd.Repositories;
using GabiniBackEnd.Services;
using Microsoft.OpenApi.Models;

namespace GabiniBackEnd
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
            builder.Services.AddDbContext<GabiniBackEndDbContext>(options =>
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
                options.AddPolicy("AllowAll", corsBuilder =>
                {
                    corsBuilder.AllowAnyOrigin()
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

            // Aplicar migrações e executar seeding
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GabiniBackEndDbContext>();
                
                try
                {
                    await context.Database.MigrateAsync(); // Aplica todas as migrações pendentes
                    await Seeder.SeedAsync(app); // Executa o seeding dos dados
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao aplicar migrações ou executar seeding: {ex.Message}");
                }
            }

            if (app.Environment.IsDevelopment())
            {
                InitializeSwagger(app);
            }

            app.UseCors("AllowAll");
            app.UseAuthorization();
            app.MapControllers();

            await app.RunAsync();
        }
    }
}
