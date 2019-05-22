using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Due.Models.Database
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("Email")]
        public string Email { get; set; }
        public User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}