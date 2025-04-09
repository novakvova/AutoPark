﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAutoPark.Data;
using WebAutoPark.Data.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();  

// Get the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

builder.Services.AddDbContext<AppAutoParkContext>(opt =>
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppAutoParkContext>();
    //dbContext.Database.EnsureDeleted();
    dbContext.Database.Migrate();

    if (dbContext.Roles.Count() == 0)
    {
        string[] roles = { "Менеджер", "Механік", "Диспетчер" };
        foreach(var name in roles)
        {
            var role = new RoleEntity
            {
                Name = name
            };
            dbContext.Roles.Add(role);
            dbContext.SaveChanges();
        }
    }

    if (dbContext.Users.Count() == 0)
    {
        UserEntity[] users = {
            new UserEntity
            {
                FirstName = "Іван",
                LastName = "Петренко",
                Username = "admin",
                Password = "admin123",
                RoleId = 1
            },
            new UserEntity
            {
                FirstName = "Богдан",
                LastName = "Денисенко",
                Username = "mechanic",
                Password = "mechanic123",
                RoleId = 2
            },
            new UserEntity
            {
                FirstName = "Віктор",
                LastName = "Денисюк",
                Username = "dispatcher",
                Password = "dispatcher123",
                RoleId = 3
            }
        };
        dbContext.Users.AddRange(users);
        dbContext.SaveChanges();
    }


    if(!dbContext.Companies.Any())
    {
        var companies = new List<CompanyEntity>
        {
            new () { Name = "ТОВ \"АвтоСвіт\"" },
            new () { Name = "ПП \"Транспортні Лінії\"" },
            new () { Name = "ТОВ \"Експрес Логістика\"" },
            new () { Name = "ПП \"Швидке Таксі\"" },
            new () { Name = "ТОВ \"Доставка Плюс\"" },
            new () { Name = "ТОВ \"Автопарк Захід\"" },
            new () { Name = "ПП \"Міські Перевезення\"" },
            new () { Name = "ТОВ \"Глобал Транс\"" },
            new () { Name = "ПП \"Сервіс-Авто\"" },
            new () { Name = "ТОВ \"Українські Дороги\"" }
        };

        dbContext.Companies.AddRange(companies);
        dbContext.SaveChanges();
    }

    if (!dbContext.VehicleStatuses.Any())
    {
        var statuses = new List<VehicleStatusEntity>
            {
                new () { Name = "Доступний" },
                new () { Name = "У використанні" },
                new () { Name = "На техобслуговуванні" },
                new () { Name = "Не придатний до експлуатації" }
            };

        dbContext.VehicleStatuses.AddRange(statuses);
        dbContext.SaveChanges();
    }

}


app.Run();
