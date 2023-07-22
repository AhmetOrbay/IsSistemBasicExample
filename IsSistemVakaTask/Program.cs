using IsSistemVakaTask.Extension;
using IsSistemVakaTask.Models.Entities;
using IsSistemVakaTask.Repositories;
using IsSistemVakaTask.Repositories.Interfaces;
using IsSistemVakaTask.Services;
using IsSistemVakaTask.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;
// Add services to the container.

service.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
service.AddEndpointsApiExplorer();
service.AddSwaggerGen();

builder.Services.AddDbContextPool<VakaDbContext>(config =>
{
    config.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"));
    config.EnableSensitiveDataLogging();

});
#region Db Implement

    service.AddScoped<VakaDbContext>();
        service.AddTransient<IReservationRepo, ReservationRepo>();
        service.AddTransient<ITableRepo, TableRepo>();
#endregion

#region Service Implement
    service.AddTransient<ITableService, TableService>();
        service.AddTransient<IReservationService, ReservationService>(); 
        service.AddTransient<IEmailService, EmailService>();
#endregion

service.AddAutoMapper(typeof(AutoMapperProfile));

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
