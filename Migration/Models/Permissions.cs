using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Models
{
    [Table("permission")]
    public class PermissionsModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public virtual PermissionsModel Permission { get; set; }
#pragma warning disable CA2227 // Las propiedades de colección deben ser de solo lectura
        public virtual ICollection<RoleHasPermissions> Roles { get; set; }
#pragma warning restore CA2227 // Las propiedades de colección deben ser de solo lectura
    }
}
