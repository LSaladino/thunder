using Data.Context;
using Data.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
using Manager.Implementation.Manager;
using Manager.Interfaces.Managers;
using Manager.Interfaces.Repositories;
using Manager.Mappings;
using Manager.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();

// dependency injection
builder.Services.AddScoped<IManTaskRepository, ManTaskRepository>();
builder.Services.AddScoped<IManTaskManager, ManTaskManager>();

//add access datacontext
//builder.Services.AddDbContextPool<MyContext>(
//    c => c.UseMySql(builder.Configuration.GetConnectionString("ConnLocal"),
//     ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConnLocal")))
//);

builder.Services.AddDbContext<MyContext>(c => c.UseNpgsql(conn));


// validations
builder.Services
    .AddValidatorsFromAssemblyContaining(typeof(NewManTaskValidator))
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

// mapper
builder.Services.AddAutoMapper(typeof(NewManTaskMappingProfile), typeof(UpdateManTaskMappingProfile));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
