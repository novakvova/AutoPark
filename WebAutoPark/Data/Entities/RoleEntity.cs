using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAutoPark.Data.Entities
{
    [Table("tblRoles")]
    public class RoleEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}
