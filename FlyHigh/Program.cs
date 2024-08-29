using AutoMapper;
using FlyHigh.Data;
using FlyHigh.Interfaces;
using FlyHigh.Repositories;
using FlyHigh.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperService());
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());

builder.Services.AddDbContext<FlightsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FlightsDbConnString"));
});
builder.Services.AddScoped<ILoggerService, LoggerService>();
builder.Services.AddScoped<IQueryFlights, FlightsRepository>();
builder.Services.AddScoped<IFlightService, FlightService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.UseStatusCodePagesWithReExecute("/error/{0}");
app.UseExceptionHandler("/error"); ;

app.Run();
