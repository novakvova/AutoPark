using System.ComponentModel.DataAnnotations;

namespace WebAutoPark.Models.VehicleStatus
{
    public class VehicleStatusItemVM
    {
        public int Id { get; set; }

        [Display(Name = "Статус автомобіля")]
        public string Name { get; set; } = string.Empty;
    }
}
