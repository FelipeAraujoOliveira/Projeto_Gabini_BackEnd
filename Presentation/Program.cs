using Application.Services;
using Core.Repositories;
using Core.Services;
using Infrastructure;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Presentation.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

namespace Presentation
{
    public class Program
    {
        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gabini API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        private static void InjectRepositoryDependency(IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<GabiniDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        }

        private static void AddControllersAndDependencies(IHostApplicationBuilder builder)
        {
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IProdutoService, ProdutoService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IEnderecoService, EnderecoService>();

            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddScoped<ICarrinhoService, CarrinhoService>();

            

            // Configuração de CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("LocalhostPolicy", policy =>
                    policy.WithOrigins("http://localhost:5173")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
            });
        }

        private static void AuthenticationMiddleware(IHostApplicationBuilder builder)
        {
            var secretKey = builder.Configuration["JwtSettings:SecretKey"]
                            ?? throw new InvalidOperationException("JWT_SECRET_KEY não foi configurada.");

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });
            builder.Services.AddAuthorization();
        }

        private static void InitializeSwagger(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            ConfigureSwagger(builder.Services);
            InjectRepositoryDependency(builder);
            AddControllersAndDependencies(builder);
            AuthenticationMiddleware(builder);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                // Inicialização do Swagger
                InitializeSwagger(app);
            }
            app.UseCors("LocalhostPolicy");

            app.MapControllers();
            app.UseStaticFiles();
            app.Run();
        }
    }

    // Classe para configurar o Swagger para aceitar arquivos de upload
    public class SwaggerFileOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileUploadMime = "multipart/form-data";

            if (operation.RequestBody == null || !operation.RequestBody.Content.Any(x => x.Key.Equals(fileUploadMime, StringComparison.InvariantCultureIgnoreCase)))
            {
                return;
            }

            operation.RequestBody.Content[fileUploadMime].Schema.Properties["file"] = new OpenApiSchema
            {
                Type = "string",
                Format = "binary"
            };
        }
    }
}
