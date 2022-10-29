using CountryAPI;
using CountryAPI.Repostory;
using CountryAPI.Services;
using Data1.DTO;
using Data1.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(
    options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
builder.Services.AddDbContext<AppDbContext>(p => p.UseNpgsql(builder.Configuration.GetConnectionString("Defaultconnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IServices<Country, CounrtyDto>, CountryServices>();
builder.Services.AddTransient<IRepostory<Country>, CountryRepostory>();

builder.Services.AddTransient<IServices<Region, RegionDto>, RegionServices>();
builder.Services.AddTransient<IRepostory<Region>, RegionRepostory>();



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