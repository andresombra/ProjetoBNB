using BNB.Application.Interfaces;
using BNB.Application.Services;
using BNB.Domain.Repositories;
using BNB.Infrastructure;
using BNB.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using BNB.Domain.Validators;
using FluentValidation.AspNetCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<BancoContext>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService,ClienteService>();

builder.Services.AddDbContext<BancoContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddFluentValidationAutoValidation()
//                .AddValidatorsFromAssemblyContaining<ClienteValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
