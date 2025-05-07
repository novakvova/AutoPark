using System.ComponentModel.DataAnnotations;

namespace WebAutoPark.Models.Company
{
    public class CompanyItemVM
    {
        public int Id { get; set; }

        [Display(Name = "Назва компанії")]
        public string Name { get; set; }
    }
}
