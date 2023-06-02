using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiHealtyEats.Data;
using WebAPiHealtyEats.Mapper;
using WebAPiHealtyEats.Repository;
using WebAPiHealtyEats.Repository.IRepository;
using WebAPiHealtyEats.UserMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar los repositorios 
builder.Services.AddScoped<IUsuarioRepository, UserRepository>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(UserMapper));
builder.Services.AddAutoMapper(typeof(RestaurantMapper));
builder.Services.AddAutoMapper(typeof(HealthStatusMapper));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
