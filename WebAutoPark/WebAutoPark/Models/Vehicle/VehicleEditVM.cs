using System.ComponentModel.DataAnnotations;

namespace WebAutoPark.Models.Vehicle
{
    public class VehicleEditVM
    {
        public int Id { get; set; }
        [Display(Name = "Назва автомобіля")]
        [Required(ErrorMessage = "Вкажіть назву")]
        public string Name { get; set; } = string.Empty;
    }
}
