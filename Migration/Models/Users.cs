using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Models
{
    [Table("user")]
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The username(s) is required"), MaxLength(60, ErrorMessage = "Username is too large")]
        public string NickName { get; set; }
        [Required(ErrorMessage = "The user's first name(s) is required"), MaxLength(100, ErrorMessage = "User's first name(s) too large")]
        public string FirstNames { get; set; }
        [MaxLength(60, ErrorMessage = "User name(s) too large")]
        public string LastName { get; set; }
        [MaxLength(60, ErrorMessage = "User name(s) too large")]
        public string SecondLastName { get; set; }
        [Required(ErrorMessage = "Password is required"), MaxLength(150, ErrorMessage = "User name(s) too large")]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DeletedAt { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

#pragma warning disable CA2227 // Las propiedades de colección deben ser de solo lectura
        public virtual ICollection<UserHasRoles> Role { get; set; }
#pragma warning restore CA2227 // Las propiedades de colección deben ser de solo lectura
    }
}
