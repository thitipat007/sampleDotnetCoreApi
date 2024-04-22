using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using sampleDotnetCoreApi;
using sampleDotnetCoreApi.Api.Core.Models;
using sampleDotnetCoreApi.Api.Core.Models.Request;
using sampleDotnetCoreApi.Api.Core.Validators;
using sampleDotnetCoreApi.Api.Repositories;
using sampleDotnetCoreApi.Api.Repositories.IRepositories;
using sampleDotnetCoreApi.Services;
using sampleDotnetCoreApi.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

//SECTION - Add Configure
builder.Services.Configure<ApplicationConfiguration>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddControllers();

//!SECTION - Add Services
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=localhost;Database=StepMart;User Id=sa;Password=root@2024;TrustServerCertificate=True;"));

builder.Services.AddTransient<IOrderRepository>(e => new OrderRepository(e.GetService<ApplicationDbContext>()));

builder.Services.AddTransient<IOrderService>(e => new OrderService(e.GetService<IOrderRepository>(), e.GetService<IProductRepository>()));

builder.Services.AddTransient<IValidator<int>, OrderIdValidator>();
builder.Services.AddTransient<IValidator<CreateOrderRequest>, CreateOrderValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// }).AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidIssuer = "my domain",
//         ValidAudience = "my domain",
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my secret key")),
//         ClockSkew = TimeSpan.Zero
//     };
// });



var app = builder.Build();

// app.UseAuthentication();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapControllers();
app.Run();
