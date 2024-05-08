using Microsoft.EntityFrameworkCore;
using SPLUS.Common.Application.Entities;
using SPLUS.Common.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Connect database
builder.Services.AddDbContext<CommonContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CommonContext")));
builder.Services.AddScoped<IFeatureService, FeatureService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
