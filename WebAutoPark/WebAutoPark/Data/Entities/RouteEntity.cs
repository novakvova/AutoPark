using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAutoPark.Data.Entities
{
    [Table("tblRoutes")]
    public class RouteEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string StartLocation { get; set; } = String.Empty;
        [Required, StringLength(255)]
        public string EndLocation { get; set; } = String.Empty;
        [Required, StringLength(255)]
        public double DistanceKm { get; set; }
    }
}
