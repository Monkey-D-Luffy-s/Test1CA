using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Serilog;
using Test1CA.Middlewares;
using Test1Core;
using Test1Core.DomainModels.Dtos;
using Test1Core.Mappers;
using Test1Core.Validators;
using Test1Infrastructure;


var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/Errorlogs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddAutoMapper(typeof(UserMapper).Assembly);
// Add services to the container.
builder.Services.AddTest1CoreServices();
builder.Services.AddTest1InfrastructureServices();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
