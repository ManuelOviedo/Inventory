using Migration.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using System.Data.Entity.Migrations;
using Migration.Migrations;
using System.Data.Entity.Validation;
using Migration.Factories;
using System.Reflection;
using System.Diagnostics;

namespace Migration
{
    public static class Program
    {
        private const string MigrationString = "Running migrations...\n";
        private const string MigrationSuccessString = "Migrations succesfuly executed...\n";
        private const string Asterixes = "*******************************************************************\n\n";
        private const string Exeses = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx\n\n";
        private const string RunningSeedsString = "Running seeds (in case there are)...\n";
        private const string SeedsSuccessString = "Seeds succesfuly executed...\n";
        private const string SuccessString = "Success!...\n\n";
        private const string PopulatingDBString = "Populating first data into database.....";
        private const string PopulateTableString = "Populating [{0}] table.....\n";
        private const string PopulationSucceededString = "[{0}] table population succeeded.....\n\n";
        private const string AllSucceededString = "All proccess done succesfuly!\n\n";
        private const string ErrorsMainString = "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:\n\n";
        private const string ErrorsEachString = "- Property: \"{0}\", Error: \"{1}\"\n";
        private const string PressAnyString = "Press any key to exit...";

        public static string MigrationString1 => MigrationString;
        public static string MigrationSuccessString1 => MigrationSuccessString;
        public static string Asterixes1 => Asterixes;
        public static string RunningSeedsString1 => RunningSeedsString;
        public static string SeedsSuccessString1 => SeedsSuccessString;
        public static string SuccessString1 => SuccessString;
        public static string PopulatingDBString1 => PopulatingDBString;
        public static string PopulationSucceededString1 => PopulationSucceededString;
        public static string AllSucceededString1 => AllSucceededString;

        public static string ErrosEachString1 => ErrorsEachString;

        public static string ErrorsMainString1 => ErrorsMainString;

        public static string PressAnyString1 => PressAnyString;

        static void Main()
        {
            try
            {
                First();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(Exeses);
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine(ErrorsMainString1,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine(ErrorsEachString,
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                Console.WriteLine(Exeses);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message + "\n");
                // Get stack trace for the exception with source file information
                StackTrace st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                Console.WriteLine("--> " + st);
                Console.WriteLine("----> " + line);
            }
            Console.WriteLine(PressAnyString1);
            Console.ReadKey();
        }

        private static void First()
        {
            switch (MainMenu())
            {
                case 1:
                    {
                        RunMigrations();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("*************************************************");
                        foreach (Roles role in GetListRoles())
                        {
                            Console.WriteLine("{0}.- {1}", role.Id, role.Name);
                        }
                        Console.WriteLine("*************************************************");
                        Console.WriteLine("... Select an id or press * to return");
                        Console.WriteLine("*************************************************");
                        var value = Console.ReadLine();
#pragma warning disable CA1307 // Especificar StringComparison
                        if (value.Equals("*"))
#pragma warning restore CA1307 // Especificar StringComparison
                        {
                            First();
                        }
                        else
                        {
#pragma warning disable CA1305 // Especificar IFormatProvider
                            ListRolesPermissions(Convert.ToInt32(value));
#pragma warning restore CA1305 // Especificar IFormatProvider
                        }
                        break;
                    }
            }
        }

        private static void ListRolesPermissions(int roleId)
        {
#pragma warning disable CA2000 // Desechar (Dispose) objetos antes de perder el ámbito
            var ctx = new CoreContext();
#pragma warning restore CA2000 // Desechar (Dispose) objetos antes de perder el ámbito
            var role = ctx.Roles.Where(p => p.Id == roleId).First();
            Console.WriteLine("*************************************************");
            var permissions = Roles.GetAllPermissions(role);
            Console.WriteLine(permissions);
            if (permissions != null)
            {
                foreach (var permission in permissions)
                {
                    Console.WriteLine("* {0}.- {1}", permission.Id, permission.Name);
                }
            }
            else
            {
                Console.WriteLine("The specified role has not permissions yet");
            }
            Console.WriteLine("**************************************************");
        }

        private static IQueryable<Roles> GetListRoles()
        {
#pragma warning disable CA2000 // Desechar (Dispose) objetos antes de perder el ámbito
            var ctx = new CoreContext();
#pragma warning restore CA2000 // Desechar (Dispose) objetos antes de perder el ámbito
            return ctx.Roles.Select(p => p);
        }

        private static void RunMigrations()
        {
            var configuration = new Configuration
            {
                ContextType = typeof(CoreContext)
            };
            DbMigrator migrator = new DbMigrator(configuration);
            Console.WriteLine(MigrationString1);
            migrator.Update();
            Console.WriteLine(MigrationSuccessString1);
            Console.WriteLine(Asterixes1);
            Console.WriteLine(RunningSeedsString1);
#pragma warning disable CA2000 // Desechar (Dispose) objetos antes de perder el ámbito
            configuration.ReSeed(new CoreContext());
#pragma warning restore CA2000 // Desechar (Dispose) objetos antes de perder el ámbito
            Console.WriteLine(SeedsSuccessString1);
            Console.WriteLine(Asterixes1);
            Console.WriteLine(SuccessString1);

            //RunPowershell("EntityFramework\\Enable-Migrations");
            //RunPowershell("EntityFramework\\Add-Migration initial");
            //RunPowershell("EntityFramework\\Update-Database");

            using (var ctx = new CoreContext())
            {
                var Permissions = "permission";
                var Roles = "role";
                var Users = "user";
                Console.WriteLine(PopulatingDBString1);
                Console.WriteLine(Asterixes1);
                // Roles
                Console.WriteLine(PopulateTableString, Roles);
                var RF = new RolesFactory(ctx);
                RF = null;
                Console.WriteLine(PopulationSucceededString1, Roles);
                Console.WriteLine(Asterixes1);
                // Permissions
                Console.WriteLine(PopulateTableString, Permissions);
                var PF = new PermissionsFactory(ctx);
                PF = null;
                Console.WriteLine(PopulationSucceededString1, Permissions);
                Console.WriteLine(Asterixes1);
                // Users
                Console.WriteLine(PopulateTableString, Users);
                var UF = new UsersFactory(ctx);
                UF = null;
                Console.WriteLine(PopulationSucceededString1, Users);
                Console.WriteLine(Asterixes1);
                Console.WriteLine(AllSucceededString1);
            }
        }

        private static int MainMenu()
        {
            Console.WriteLine(Asterixes1);
            Console.WriteLine("************************************************");
            Console.WriteLine("*            Main Menu                         *");
            Console.WriteLine("*            1. Run migrations                 *");
            Console.WriteLine("*            2. Try to list roles              *");
            Console.WriteLine("*            5. Exit                           *");
            Console.WriteLine("************************************************");
#pragma warning disable CA1305 // Especificar IFormatProvider
            return Convert.ToInt32(Console.ReadLine());
#pragma warning restore CA1305 // Especificar IFormatProvider
        }

        public static bool HasMethod(this object objectToCheck, string methodName)
        {
            try
            {
                if (objectToCheck == null)
                {
                    return false;
                }
                var type = objectToCheck.GetType();
                return type.GetMethod(methodName) != null;
            }
            catch (AmbiguousMatchException)
            {
                // ambiguous means there is more than one result,
                // which means: a method with that name does exist
                return true;
            }
        }

        private static void RunPowershell(string command)
        {

            var powerShell = PowerShell.Create();
            powerShell.AddCommand(command);
            powerShell.Invoke();
            powerShell.Dispose();

        }
    }
}
