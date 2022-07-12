using BusinessLogic;
using DataLayer;
using DataLayer.Repositories;
using Dota2replaysaver.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Custom stuff

builder.Services.AddDbContext<MatchDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DotaReplaySaverDB")));
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddTransient<IMatchLogic, MatchLogic>();

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
