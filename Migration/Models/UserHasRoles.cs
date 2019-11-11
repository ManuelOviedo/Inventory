using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Models
{
    [Table("user_has_role")]
    public class UserHasRoles
    {
        [Key]
        [Column(Order = 1)]
        public int UserId { get; set; }
        public virtual Users User { get; set; }
        [Key]
        [Column(Order = 2)]
        public int RoleId { get; set; }
        public virtual Roles Role { get; set; }
    }
}
