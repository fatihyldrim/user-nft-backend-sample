using UnivestHub.Case.Application;
using UnivestHub.Case.Infrastructure;
using UnivestHub.Case.Persistance;
using UnivestHub.Case.WebApi.Middlewares;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = "http://localhost",
        ValidIssuer = "http://localhost",
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secRetKey!.")),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
    };
    opt.RequireHttpsMetadata = false;
    opt.SaveToken = true;
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("release01", cors =>
    {
        cors.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
    });
});

//TODO TECH DEPT
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
//TECH DEPT

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("release01");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
