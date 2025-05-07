using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAutoPark.Data.Entities;

namespace WebAutoPark.Models.Vehicle
{
    public class VehicleItemVM
    {
        public int Id { get; set; }
        [Display(Name = "Рєстраційний номер")]
        public string RegistrationNumber { get; set; } = string.Empty;
        [Display(Name = "Марка")]
        public string Brand { get; set; } = string.Empty;
        [Display(Name = "Модель")]
        public string Model { get; set; } = string.Empty;
        [Display(Name = "Рік")]
        public int Year { get; set; }

        [Display(Name = "Статус")]
        public string StatusName { get; set; } = string.Empty;

        [Display(Name = "Компанія")]
        public string CompanyName { get; set; } = string.Empty;
    }
}
