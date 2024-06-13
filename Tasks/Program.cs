using Data.Context;
using Data.Repository;
using Manager.Implementation.Manager;
using Manager.Interfaces.Managers;
using Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();


//inject dependency
builder.Services.AddScoped<IManTaskRepository, ManTaskRepository>();
builder.Services.AddScoped<IManTaskManager, ManTaskManager>();

//ADD FOR ME CONTEXT ACCESS TO DONNES PROJECT MYSQL
//add access datacontext
builder.Services.AddDbContextPool<MyContext>(
    c => c.UseMySql(builder.Configuration.GetConnectionString("ConnLocal"),
     ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConnLocal")))
);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
