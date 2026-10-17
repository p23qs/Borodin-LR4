using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Borodin
{
    [Table("Users")]
    public partial class Users
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(20)]
        public string Login { get; set; }
        [Required, StringLength(20)]
        public string Password { get; set; }
        [StringLength(50)]
        public string First_Name { get; set; }
        [Required, StringLength(20)]
        public string Role_Name { get; set; }
        [ForeignKey(nameof(Role_Name))]
        public virtual Roles Roles { get; set; }
    }
}
