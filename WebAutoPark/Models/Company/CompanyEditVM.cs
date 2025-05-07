using System.ComponentModel.DataAnnotations;

namespace WebAutoPark.Models.Company
{
    public class CompanyEditVM
    {
        public int Id { get; set; }
        [Display(Name = "Назва компанії")]
        [Required(ErrorMessage ="Вкажіть назву")]
        public string Name { get; set; } = string.Empty;
    }
}
