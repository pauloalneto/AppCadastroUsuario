using AppCadastroUsuario.Api.Application.AutoMapper;
using AppCadastroUsuario.Api.Application.Interfaces;
using AppCadastroUsuario.Api.Application.Services;
using AppCadastroUsuario.Api.Data;
using AppCadastroUsuario.Api.Data.Repository;
using AppCadastroUsuario.Api.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using System.Text;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.MongoDB("mongodb://127.0.0.1:27017/logs", collectionName:"appCadastroUsuarioLogs")
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    //Serilog
    builder.Host.UseSerilog();
    Log.Information("Iniciando a aplicação");
    //Context
    builder.Services.AddDbContext<AppCadastroUsuarioContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });


    //AutoMapper
    builder.Services.AddAutoMapper(typeof(DomainToDtoMappingProfile), typeof(DtoToDomainMappingProfile));

    // Add services to the container.
    builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    builder.Services.AddScoped<IUsuarioApplicationService, UsuarioApplicationService>();
    builder.Services.AddScoped<IUsuarioService, UsuarioService>();
    builder.Services.AddScoped<AppCadastroUsuarioContext>();

    builder.Services.AddScoped<IAuthApplicationService, AuthApplicationService>();


    //CORS
    var clientAuthorityEndPoint = builder.Configuration.GetSection("ClientAuthorityEndPoint:Default").Value.Split(',');
    var cors = "_allowSpecificOrigins";

    builder.Services.AddCors(options =>
    {
        options.AddPolicy(cors, policy =>
        {
            policy.WithOrigins(clientAuthorityEndPoint).AllowAnyHeader().AllowAnyMethod();
        });
    });


    builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                    });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //JWT Authentication
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfigs:Secret"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


    app.UseCors(cors);
    //app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "A aplicação foi encerrada. " + ex.Message);
}
finally
{
    Log.CloseAndFlush();
}