using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Models
{
    [Table("role")]
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

#pragma warning disable CA2227 // Las propiedades de colección deben ser de solo lectura
        public virtual ICollection<UserHasRoles> Users { get; set; }
        public virtual ICollection<RoleHasPermissions> Permissions { get; set; }
#pragma warning restore CA2227 // Las propiedades de colección deben ser de solo lectura

        public static IEnumerable<PermissionsModel> GetAllPermissions(Roles role)
        {
            try
            {
#pragma warning disable CA2000 // Desechar (Dispose) objetos antes de perder el ámbito
                if (role != null)
                {
                    if (role.Name == Properties.Resources.superAdmin)
                    {
                        return new CoreContext().Permissions;
                    }
                    Console.WriteLine(role.Permissions.ToList().Count);
                    if (role.Permissions.ToList().Count == 0)
                    {
                        throw new NullReferenceException();
                    }
                    IEnumerable<PermissionsModel> permissions = new List<PermissionsModel>();
                    var ctx = new CoreContext();
                    foreach (var permission in role.Permissions)
                    {
                        var perm = ctx.Permissions.Where(p => p.Id == permission.PermissionId).First();
                        permissions.Concat(new[] { perm });
                    }
                    return permissions;
                }
            }
            catch (NullReferenceException){ }
            catch (InvalidOperationException) { }
            return null;
#pragma warning restore CA2000 // Desechar (Dispose) objetos antes de perder el ámbito
        }

    }
}
