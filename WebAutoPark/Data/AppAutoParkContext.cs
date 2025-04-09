using Microsoft.EntityFrameworkCore;
using WebAutoPark.Data.Entities;

namespace WebAutoPark.Data
{
    //Контекст підлючення до БД
    public class AppAutoParkContext : DbContext
    {
        public AppAutoParkContext(DbContextOptions<AppAutoParkContext> contextOptions)
           : base(contextOptions)
        { }

        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<VehicleStatusEntity> VehicleStatuses { get; set; }
        public DbSet<VehicleEntity> Vehicles { get; set; }
        public DbSet<DriverEntity> Drivers { get; set; }
        public DbSet<RouteEntity> Routes { get; set; }
        public DbSet<AssignmentEntity> Assignments { get; set; }

    }
}
