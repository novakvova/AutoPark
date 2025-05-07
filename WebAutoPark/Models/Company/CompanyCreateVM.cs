using System.ComponentModel.DataAnnotations;

namespace WebAutoPark.Models.Company
{
    public class CompanyCreateVM
    {
        [Display(Name = "Назва компанії")]
        [Required(ErrorMessage ="Вкажіть назву")]
        public string Name { get; set; }
    }
}
