using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAutoPark.Data.Entities
{
    /// <summary>
    /// Статуси автомобіля
    /// </summary>
    [Table("tblVehicleStatuses")]
    public class VehicleStatusEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(256)]
        public string Name { get; set; } = string.Empty;
    }
}
