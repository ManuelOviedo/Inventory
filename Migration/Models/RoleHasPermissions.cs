using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Models
{
    [Table("role_has_permission")]
    public class RoleHasPermissions
    {
        [Key]
        [Column(Order = 1)]
        public int RoleId { get; set; }
        public virtual Roles Role { get; set; }
        [Key]
        [Column(Order = 2)]
        public int PermissionId { get; set; }
        public virtual PermissionsModel Permission { get; set; }
    }
}
