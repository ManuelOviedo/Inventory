using Migration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Factories
{
    public class UsersFactory
    {
        public UsersFactory(CoreContext ctx)
        {
            if (ctx != null && (!ctx.Users.Any(o => o.NickName == "Erick") || !ctx.Users.Any(o => o.NickName == "SuperAdmin")))
            {
                ctx.Users.Add(new Users()
                {
                    NickName = "Erick",
                    FirstNames = "Erick",
                    Password = BCrypt.Net.BCrypt.HashPassword("123", BCrypt.Net.BCrypt.GenerateSalt()),
                    CreatedAt = DateTime.Now
                });
                var su = new Users()
                {
                    NickName = "SuperAdmin",
                    FirstNames = "Super",
                    LastName = "Admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("satanchild", BCrypt.Net.BCrypt.GenerateSalt()),
                    CreatedAt = DateTime.Now
                };
                ctx.Users.Add(su);
                var suHasRole = new UserHasRoles()
                {
                    Role = ctx.Roles.Where(c => c.Name == Properties.Resources.superAdmin).First(),
                    User = su
                };
                ctx.UserHasRoles.Add(suHasRole);
                ctx.SaveChanges();
            }
        }
    }
}
