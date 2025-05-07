using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAutoPark.Data.Entities
{
    /// <summary>
    /// Водій
    /// </summary>
    [Table("tblDrivers")]
    public class DriverEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public DateTime LicenseExpiryDate { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public CompanyEntity? Company { get; set; }
    }
}
