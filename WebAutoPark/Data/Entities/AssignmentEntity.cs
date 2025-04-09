using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAutoPark.Data.Entities
{
    /// <summary>
    /// Призначення автомобіля та водія на маршрут
    /// </summary>
    [Table("tblAssignments")]
    public class AssignmentEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public VehicleEntity Vehicle { get; set; } = new VehicleEntity();

        [ForeignKey("Driver")]
        public int DriverId { get; set; }
        public DriverEntity Driver { get; set; } = new DriverEntity();

        [ForeignKey("Route")]
        public int RouteId { get; set; }
        public RouteEntity Route { get; set; } = new RouteEntity();

        public DateTime AssignedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
