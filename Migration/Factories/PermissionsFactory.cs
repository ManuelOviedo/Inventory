using Migration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Factories
{
    public class PermissionsFactory
    {
        public PermissionsFactory(CoreContext ctx)
        {
            if (ctx != null)
            {
                var attribs = new string[] { "view ", "edit ", "delete ", "update ", "restore " };
                var modules = new string[] { "sales", "clients", "users" };
                foreach (string attrib in attribs)
                {
                    foreach (string module in modules)
                    {
                        string permissionName = attrib + module;
                        if (!ctx.Permissions.Any(P => P.Name == permissionName))
                        {
                            string parentPermissionName = attribs[0] + module;
                            var permissionRecord = new PermissionsModel()
                            {
                                Name = attrib + module
                            };
                            if (Array.IndexOf(attribs, attrib) != 0)
                            {
                                permissionRecord.Permission = ctx.Permissions
                                                .Where(p => p.Name == parentPermissionName)
                                                .Select(p => p).First();
                            }
#pragma warning disable CA1062 // Validar argumentos de métodos públicos
                            ctx.Permissions.Add(permissionRecord);
#pragma warning restore CA1062 // Validar argumentos de métodos públicos
                            ctx.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
