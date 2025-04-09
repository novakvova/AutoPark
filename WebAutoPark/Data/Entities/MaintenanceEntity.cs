using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAutoPark.Data.Entities
{
    /// <summary>
    /// технічне обслуговування
    /// </summary>
    [Table("tblMaintenances")]
    public class MaintenanceEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public VehicleEntity Vehicle { get; set; } = new VehicleEntity();

        public DateTime Date { get; set; }
        public string Description { get; set; } = String.Empty;
        public decimal Cost { get; set; }
    }
}
