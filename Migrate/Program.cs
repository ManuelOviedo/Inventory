using ModelsCore.Migrations;
using ModelsCore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrate
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Creando base de datos... ");
                Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
                Console.WriteLine("Base de datos creada.");
                Console.WriteLine("><-----------------------------------------------------------------------><");
                Console.WriteLine("\nCreando tabla usuarios  y registros...");
                var dbContext = new DataContext();
                dbContext.Usuario.Add(
                    new Usuario()
                    {
                        nombres = "SAGRARIO",
                        apellido_paterno = null,
                        apellido_materno = null,
                        // hash and save a password
                        password = BCrypt.Net.BCrypt.HashPassword("123"),
                        tipo = 1,
                        actualizado = null,
                        eliminado = null,
                        creado = DateTime.Now
                    }
                );
                dbContext.Usuario.Add(
                    new Usuario()
                    {
                        nombres = "Erick",
                        apellido_paterno = null,
                        apellido_materno = null,
                        // hash and save a password
                        password = BCrypt.Net.BCrypt.HashPassword("123"),
                        tipo = 1,
                        actualizado = null,
                        eliminado = null,
                        creado = DateTime.Now
                    }
                );
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            Console.ReadLine();
        }
    }
}
