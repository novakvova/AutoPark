using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAutoPark.Data.Entities
{
    /// <summary>
    /// Автомобіль
    /// </summary>
    [Table("tblVehicles")]
    public class VehicleEntity
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string RegistrationNumber { get; set; } = string.Empty;
        [Required, StringLength(255)]
        public string Brand { get; set; } = string.Empty;
        [Required, StringLength(255)]
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public VehicleStatusEntity Status { get; set; } = new VehicleStatusEntity();

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; } = new CompanyEntity();
    }
}
