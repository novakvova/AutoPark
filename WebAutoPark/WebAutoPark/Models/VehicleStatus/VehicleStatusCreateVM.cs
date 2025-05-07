using System.ComponentModel.DataAnnotations;

namespace WebAutoPark.Models.VehicleStatus
{
    public class VehicleStatusCreateVM
    {
        [Display(Name = "Статус автомобіля")]
        [Required(ErrorMessage ="Вкажіть статус")]
        public string Name { get; set; } = string.Empty;
    }
}
