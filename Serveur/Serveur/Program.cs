using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serveur.Common;
using Serveur.Data;
using Serveur.Helpers;
using Serveur.Mapping;
using Serveur.Middleware;
using Serveur.Models.Entities;
using Serveur.Repositories.Implementations;
using Serveur.Repositories.Interfaces;
using Serveur.Services.Implementations;
using Serveur.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToArray();

        var message = errors.Length > 0
            ? string.Join(" | ", errors)
            : "Validation failed.";

        return new BadRequestObjectResult(ApiResponse<object>.Fail(message));
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbConnectionType = Environment.GetEnvironmentVariable("ACCESSPOS_DB_CONNECTION");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.Equals(dbConnectionType, "sqlsrv", StringComparison.OrdinalIgnoreCase))
{
    var host = Environment.GetEnvironmentVariable("ACCESSPOS_DB_HOST");
    var port = Environment.GetEnvironmentVariable("ACCESSPOS_DB_PORT");
    var database = Environment.GetEnvironmentVariable("ACCESSPOS_DB_DATABASE");
    var username = Environment.GetEnvironmentVariable("ACCESSPOS_DB_USERNAME");
    var password = Environment.GetEnvironmentVariable("ACCESSPOS_DB_PASSWORD");

    if (!string.IsNullOrWhiteSpace(host)
        && !string.IsNullOrWhiteSpace(port)
        && !string.IsNullOrWhiteSpace(database)
        && !string.IsNullOrWhiteSpace(username)
        && !string.IsNullOrWhiteSpace(password))
    {
        connectionString = $"Server={host},{port};Database={database};User Id={username};Password={password};TrustServerCertificate=True;Encrypt=True";
    }
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.SectionName));
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

var jwtOptions = builder.Configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>()
    ?? throw new InvalidOperationException("JWT configuration is missing.");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await dbContext.Database.MigrateAsync();

    var adminEmail = Environment.GetEnvironmentVariable("SUPERADMIN_EMAIL")?.Trim().ToLowerInvariant()
        ?? "admin@convoiturage.local";
    var adminPassword = Environment.GetEnvironmentVariable("SUPERADMIN_PASSWORD")
        ?? "Admin@123456";
    var adminName = Environment.GetEnvironmentVariable("SUPERADMIN_NAME")?.Trim()
        ?? "Super Admin";

    var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher<User>>();
    await ApplicationDbSeeder.SeedDemoDataAsync(
        dbContext,
        passwordHasher,
        adminName,
        adminEmail,
        adminPassword);
}

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
