using AutoMapper;
using FluentValidation;
using Gbso.TechnicalTest.Bll.ValidationRules;
using Gbso.TechnicalTest.Cl;
using Gbso.TechnicalTest.Dal;
using Gbso.TechnicalTest.Dto;
using Gbso.TechnicalTest.WebApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add dbContext
builder.Services.AddDbContext<RootContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString(Utils.CONNECTION_ROOT_NAME))
);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Add service providers
builder.Services.AddServicesLayer();
builder.Services.AddDataLayer();
// Add validation rules
builder.Services.AddBllValidationRulesLayer();
// Add AutoMapper
builder.Services.AddSingleton(new MapperConfiguration(mc => mc.AddProfile(typeof(AutoMapperConfiguration))).CreateMapper());

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