using Migration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Factories
{
    public class RolesFactory
    {
        public RolesFactory(CoreContext ctx)
        {
            var types = new string[] { "administrator", "cashier", "normal_user", "SU" };
            foreach (string Type in types)
            {
                if (ctx != null && !ctx.Roles.Any(o => o.Name == Type))
                {
                    var typesCollection = new Roles()
                    {
                        Name = Type
                    };
                    ctx.Roles.Add(typesCollection);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
