﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAutoPark.Data.Entities
{
    /// <summary>
    /// компанія
    /// </summary>
    [Table("tblCompanies")]
    public class CompanyEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }  = string.Empty;

        public ICollection<VehicleEntity> Vehicles { get; set; } = new List<VehicleEntity>();
        public ICollection<DriverEntity> Drivers { get; set; } = new List<DriverEntity>();
    }
}
