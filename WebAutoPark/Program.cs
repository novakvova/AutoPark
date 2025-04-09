using Microsoft.EntityFrameworkCore;
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

    if (!dbContext.Vehicles.Any())
    {
        var companies = dbContext.Companies.ToList();
        var statuses = dbContext.VehicleStatuses.ToList();

        var vehicles = new List<VehicleEntity>
        {
            new ()
            {
                RegistrationNumber = "АА1234ВО",
                Brand = "Renault",
                Model = "Trafic",
                Year = 2018,
                StatusId = statuses.First(s => s.Name == "Доступний").Id,
                CompanyId = companies[0].Id
            },
            new ()
            {
                RegistrationNumber = "ВС5678НР",
                Brand = "Mercedes-Benz",
                Model = "Sprinter",
                Year = 2020,
                StatusId = statuses.First(s => s.Name == "У використанні").Id,
                CompanyId = companies[1].Id
            },
            new ()
            {
                RegistrationNumber = "КА9988КК",
                Brand = "Ford",
                Model = "Transit",
                Year = 2019,
                StatusId = statuses.First(s => s.Name == "На техобслуговуванні").Id,
                CompanyId = companies[2].Id
            },
            new ()
            {
                RegistrationNumber = "АН1111СІ",
                Brand = "Volkswagen",
                Model = "Crafter",
                Year = 2017,
                StatusId = statuses.First(s => s.Name == "Не придатний до експлуатації").Id,
                CompanyId = companies[3].Id
            },
            new ()
            {
                RegistrationNumber = "ІК3456ТР",
                Brand = "Peugeot",
                Model = "Boxer",
                Year = 2021,
                StatusId = statuses.First(s => s.Name == "Доступний").Id,
                CompanyId = companies[4].Id
            }
        };

        dbContext.Vehicles.AddRange(vehicles);
        dbContext.SaveChanges();
    }

    if (!dbContext.Drivers.Any())
    {
        var companies = dbContext.Companies.ToList();

        var drivers = new List<DriverEntity>
        {
            new ()
            {
                FullName = "Іваненко Сергій Миколайович",
                LicenseNumber = "AA123456",
                LicenseExpiryDate = DateTime.Today.AddYears(3),
                CompanyId = companies[0].Id
            },
            new ()
            {
                FullName = "Петренко Олег Васильович",
                LicenseNumber = "BB654321",
                LicenseExpiryDate = DateTime.Today.AddYears(2),
                CompanyId = companies[1].Id
            },
            new ()
            {
                FullName = "Ковальчук Марія Іванівна",
                LicenseNumber = "CC345678",
                LicenseExpiryDate = DateTime.Today.AddYears(4),
                CompanyId = companies[2].Id
            },
            new ()
            {
                FullName = "Дмитрук Андрій Олексійович",
                LicenseNumber = "DD987654",
                LicenseExpiryDate = DateTime.Today.AddYears(1),
                CompanyId = companies[3].Id
            },
            new ()
            {
                FullName = "Лисенко Наталія Володимирівна",
                LicenseNumber = "EE112233",
                LicenseExpiryDate = DateTime.Today.AddYears(5),
                CompanyId = companies[4].Id
            }
        };

        dbContext.Drivers.AddRange(drivers);
        dbContext.SaveChanges();
    }

}


app.Run();
