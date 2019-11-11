using ModelsCore.Migrations;
using ModelsCore.Models;
using System;
using System.Data.Entity;

namespace migrations
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
