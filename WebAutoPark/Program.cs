using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAutoPark.Data;
using WebAutoPark.Data.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Get the connection string from appsettings.json
//var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
var connectionString = builder.Configuration.GetConnectionString("PgSqlConnection");

builder.Services.AddDbContext<AppAutoParkContext>(opt =>
    opt.UseNpgsql(connectionString));
//opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

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
        foreach (var name in roles)
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


    if (!dbContext.Companies.Any())
    {
        var companies = new List<CompanyEntity>
        {
            new CompanyEntity() { Name = "ТОВ \"АвтоСвіт\"" },
            new CompanyEntity() { Name = "ПП \"Транспортні Лінії\"" },
            new CompanyEntity() { Name = "ТОВ \"Експрес Логістика\"" },
            new CompanyEntity() { Name = "ПП \"Швидке Таксі\"" },
            new CompanyEntity() { Name = "ТОВ \"Доставка Плюс\"" },
            new CompanyEntity() { Name = "ТОВ \"Автопарк Захід\"" },
            new CompanyEntity() { Name = "ПП \"Міські Перевезення\"" },
            new CompanyEntity() { Name = "ТОВ \"Глобал Транс\"" },
            new CompanyEntity() { Name = "ПП \"Сервіс-Авто\"" },
            new CompanyEntity() { Name = "ТОВ \"Українські Дороги\"" }
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
        var companies = dbContext.Companies
            .Where(x => x.Name != "")
            .ToList();
        var statuses = dbContext.VehicleStatuses
            .Where(x => x.Name != "")
            .ToList();

        var vehicles = new List<VehicleEntity>
        {
            new VehicleEntity()
            {
                RegistrationNumber = "АА1234ВО",
                Brand = "Renault",
                Model = "Trafic",
                Year = 2018,
                StatusId = statuses.First(s => s.Name == "Доступний").Id,
                CompanyId = companies[0].Id
            },
            new VehicleEntity()
            {
                RegistrationNumber = "ВС5678НР",
                Brand = "Mercedes-Benz",
                Model = "Sprinter",
                Year = 2020,
                StatusId = statuses.First(s => s.Name == "У використанні").Id,
                CompanyId = companies[1].Id
            },
            new VehicleEntity()
            {
                RegistrationNumber = "КА9988КК",
                Brand = "Ford",
                Model = "Transit",
                Year = 2019,
                StatusId = statuses.First(s => s.Name == "На техобслуговуванні").Id,
                CompanyId = companies[2].Id
            },
            new VehicleEntity()
            {
                RegistrationNumber = "АН1111СІ",
                Brand = "Volkswagen",
                Model = "Crafter",
                Year = 2017,
                StatusId = statuses.First(s => s.Name == "Не придатний до експлуатації").Id,
                CompanyId = companies[3].Id
            },
            new VehicleEntity()
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
                LicenseExpiryDate = DateTime.UtcNow.Date.AddYears(3),
                CompanyId = companies[0].Id
            },
            new ()
            {
                FullName = "Петренко Олег Васильович",
                LicenseNumber = "BB654321",
                LicenseExpiryDate = DateTime.UtcNow.Date.AddYears(2),
                CompanyId = companies[1].Id
            },
            new ()
            {
                FullName = "Ковальчук Марія Іванівна",
                LicenseNumber = "CC345678",
                LicenseExpiryDate = DateTime.UtcNow.Date.AddYears(4),
                CompanyId = companies[2].Id
            },
            new ()
            {
                FullName = "Дмитрук Андрій Олексійович",
                LicenseNumber = "DD987654",
                LicenseExpiryDate = DateTime.UtcNow.Date.AddYears(1),
                CompanyId = companies[3].Id
            },
            new ()
            {
                FullName = "Лисенко Наталія Володимирівна",
                LicenseNumber = "EE112233",
                LicenseExpiryDate = DateTime.UtcNow.Date.AddYears(5),
                CompanyId = companies[4].Id
            }

        };

        dbContext.Drivers.AddRange(drivers);
        dbContext.SaveChanges();
    }



    if (!dbContext.Routes.Any())
    {
        var routes = new List<RouteEntity>
        {
            new ()
            {
                StartLocation = "Київ",
                EndLocation = "Львів",
                DistanceKm = 540
            },
            new ()
            {
                StartLocation = "Одеса",
                EndLocation = "Харків",
                DistanceKm = 720
            },
            new ()
            {
                StartLocation = "Дніпро",
                EndLocation = "Запоріжжя",
                DistanceKm = 85
            },
            new ()
            {
                StartLocation = "Луцьк",
                EndLocation = "Рівне",
                DistanceKm = 70
            },
            new ()
            {
                StartLocation = "Ужгород",
                EndLocation = "Івано-Франківськ",
                DistanceKm = 260
            },
            new ()
            {
                StartLocation = "Кропивницький",
                EndLocation = "Миколаїв",
                DistanceKm = 210
            },
            new ()
            {
                StartLocation = "Херсон",
                EndLocation = "Запоріжжя",
                DistanceKm = 230
            },
            new ()
            {
                StartLocation = "Чернівці",
                EndLocation = "Київ",
                DistanceKm = 525
            }
        };

        dbContext.Routes.AddRange(routes);
        dbContext.SaveChanges();
    }

    if (!dbContext.Assignments.Any())
    {
        var vehicles = dbContext.Vehicles.ToList();
        var drivers = dbContext.Drivers.ToList();
        var routes = dbContext.Routes.ToList();

        // Проста логіка: перші 5 Assignment, з різними комбінаціями
        var assignments = new List<AssignmentEntity>
        {
            new ()
            {
                VehicleId = vehicles[0].Id,
                DriverId = drivers[0].Id,
                RouteId = routes[0].Id,
                AssignedAt = DateTime.UtcNow.Date.AddDays(-5),
                CompletedAt = DateTime.UtcNow.Date.AddDays(-4)
            },
            new ()
            {
                VehicleId = vehicles[1].Id,
                DriverId = drivers[1].Id,
                RouteId = routes[1].Id,
                AssignedAt = DateTime.UtcNow.Date.AddDays(-3),
                CompletedAt = DateTime.UtcNow.Date.AddDays(-2)
            },
            new ()
            {
                VehicleId = vehicles[2].Id,
                DriverId = drivers[2].Id,
                RouteId = routes[2].Id,
                AssignedAt = DateTime.UtcNow.Date.AddDays(-2),
                CompletedAt = DateTime.UtcNow.Date.AddDays(-1)
            },
            new ()
            {
                VehicleId = vehicles[3].Id,
                DriverId = drivers[3].Id,
                RouteId = routes[3].Id,
                AssignedAt = DateTime.UtcNow.Date.AddDays(-1),
                CompletedAt = null // ще не завершено
            },
            new ()
            {
                VehicleId = vehicles[4].Id,
                DriverId = drivers[4].Id,
                RouteId = routes[4].Id,
                AssignedAt = DateTime.UtcNow.Date,
                CompletedAt = null // активне призначення
            }

        };

        dbContext.Assignments.AddRange(assignments);
        dbContext.SaveChanges();
    }

    if (!dbContext.Maintenances.Any())
    {
        var vehicles = dbContext.Vehicles.ToList();

        var maintenances = new List<MaintenanceEntity>
        {
            new ()
            {
                VehicleId = vehicles[0].Id,
                Description = "Планова заміна мастила та фільтрів",
                Date = DateTime.UtcNow.Date.AddDays(-90),
                Cost = 2500
            },
            new ()
            {
                VehicleId = vehicles[1].Id,
                Description = "Заміна гальмівних колодок",
                Date = DateTime.UtcNow.Date.AddDays(-60),
                Cost = 1800
            },
            new ()
            {
                VehicleId = vehicles[2].Id,
                Description = "Діагностика електросистеми",
                Date = DateTime.UtcNow.Date.AddDays(-30),
                Cost = 900
            },
            new ()
            {
                VehicleId = vehicles[3].Id,
                Description = "Ремонт ходової частини",
                Date = DateTime.UtcNow.Date.AddDays(-15),
                Cost = 3400
            },
            new ()
            {
                VehicleId = vehicles[4].Id,
                Description = "ТО перед рейсом",
                Date = DateTime.UtcNow.Date.AddDays(-5),
                Cost = 1200
            }

        };

        dbContext.Maintenances.AddRange(maintenances);
        dbContext.SaveChanges();
    }


}


app.Run();
