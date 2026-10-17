using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Borodin
{
    [Table("Roles")]
    public partial class Roles
    {
        public Roles() { Users = new HashSet<Users>(); }

        [Key, StringLength(20)]
        public string Name { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
