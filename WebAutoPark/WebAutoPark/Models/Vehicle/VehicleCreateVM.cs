using System.ComponentModel.DataAnnotations;
using WebAutoPark.Helpers;

namespace WebAutoPark.Models.Vehicle;

public class VehicleCreateVM
{

    [Display(Name = "Реєстраційний номер автомобіля")]
    [Required(ErrorMessage = "Вкажіть реєстраційний номер")]
    public string RegistrationNumber { get; set; } = string.Empty;
    [Display(Name = "Марка")]
    [Required(ErrorMessage = "Вкажіть марку")]
    public string Brand { get; set; } = string.Empty;
    [Display(Name = "Модель")]
    [Required(ErrorMessage = "Вкажіть модель")]
    public string Model { get; set; } = string.Empty;
    [Display(Name = "Рік випуску")]
    [Required(ErrorMessage = "Вкажіть рік випуску")]
    public int Year { get; set; }

    [Display(Name = "Статус")]
    [Required(ErrorMessage = "Вкажіть статус")]
    public int StatusId { get; set; }

    [Display(Name = "Статус")]
    public List<SelectItemViewModel>? VehicleStatuses { get; set; }

    [Display(Name = "Компанія")]
    [Required(ErrorMessage = "Вкажіть компанію")]
    public int CompanyId { get; set; }

    [Display(Name = "Компанія")]
    public List<SelectItemViewModel>? Companies { get; set; }
}
