using Technical_Test_Quala.Data;
using Technical_Test_Quala.Repositories;
using Technical_Test_Quala.Controllers;
using Technical_Test_Quala.Services;
using Technical_Test_Quala.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DrapperContext>();
builder.Services.AddScoped<Ias_branch_qualaRepository, as_branch_qualaRepository>();
builder.Services.AddScoped<Ias_branch_qualaService, as_branch_qualaService>();

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
