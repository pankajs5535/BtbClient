//Auto Mapper
using BtbClient.Application.Mapping;
using BtbClient.Application.Validators;
using BtbClient.Persistence.Data;
// Register FluentValidation.

using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnections")));

builder.Services.AddValidatorsFromAssemblyContaining<CreateRawMaterialValidator>();

builder.Services.AddAutoMapper(cfg => { }, typeof(ItemProfile).Assembly);



builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
