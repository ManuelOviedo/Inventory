using Migration.Models;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class CoreContext : DbContext
    {
        public CoreContext() : base("server=201.164.192.146; userid=root;password=mysqlInstanceLosVolcanes;database=inventory;persistsecurityinfo=True")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CoreContext>());
        }

        public DbSet<PermissionsModel> Permissions { get; set; }
        public DbSet<RoleHasPermissions> RoleHasPermissions { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserHasRoles> UserHasRoles { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
