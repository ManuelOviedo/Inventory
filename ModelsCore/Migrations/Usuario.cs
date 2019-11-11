using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsCore.Migrations
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string? apellido_paterno { get; set; }
        public string? apellido_materno { get; set; }
        public string password { get; set; }
        public int tipo { get; set; }
        public DateTime? actualizado { get; set; }
        public DateTime? eliminado { get; set; }
        public DateTime creado { get; set; }
}
}
