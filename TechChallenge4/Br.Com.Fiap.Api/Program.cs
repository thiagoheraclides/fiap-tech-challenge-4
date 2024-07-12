using Br.Com.Fiap.Api.Extensions;
using Br.Com.Fiap.Api.Resources.Middleware;
using Br.Com.Fiap.Api.Seed;
using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Application.Services;
using Br.Com.Fiap.Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddJsonOptions(ctrl => ctrl.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Fiap", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Use a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
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

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPerfilService, PerfilService>();
builder.Services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
builder.Services.AddScoped<IConsorcioService, ConsorcioService>();
builder.Services.AddScoped<IPrevidenciaService, PrevidenciaService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<ILanceService, LanceService>();
builder.Services.AddScoped<IResgateService, ResgateService>();
builder.Services.AddScoped<IPagamentoService, PagamentoService>();

string connectionString = builder.Configuration["ConnStr"]
                ?? throw new ArgumentNullException("ConnStr");

builder.Services.AddDbContext<ApiContext>(options 
    => options.UseSqlServer(connectionString));

var privateKey = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Symmetric:Key"]
                    ?? throw new ArgumentNullException("Jwt Symmetric Key"));

builder.Services
    .AddAuthentication(authentication =>
    {
        authentication.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(jwt =>
    {
        jwt.RequireHttpsMetadata = true;
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(privateKey),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddLog4net();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{    
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ContextSeed();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<HttpLoggingMiddleware>();

app.MapControllers();

app.Run();
