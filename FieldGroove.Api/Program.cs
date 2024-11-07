using System.Text;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using FieldGroove.Application.validation;
using FieldGroove.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using FieldGroove.Infrastructure.Repositories;
using FieldGroove.Domain.Interfaces;
using FieldGroove.Application.Mapper;
using Microsoft.OpenApi.Models;
using FieldGroove.Domain.Models;
using FieldGroove.Application.CQRS.Accounts.IsValid;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

byte[] secretByte = new byte[64];
using (var Random = RandomNumberGenerator.Create())
{
    Random.GetBytes(secretByte);
}
string secretKey = Convert.ToBase64String(secretByte);
JwtModel.Key = secretKey;


builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssemblyContaining<RegisterValidator>();

builder.Services.AddCors(options => options.AddPolicy("policy", x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

#region Auto mapper

builder.Services.AddAutoMapper(typeof(Mapper));

#endregion

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(IsValidQueryHandler).Assembly);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#region JWT_AUTH

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidIssuer = JwtModel.Issuer,
           ValidAudience = JwtModel.Audience,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtModel.Key))
       };
   });

#endregion

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] {}
        }
    });
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors("policy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();