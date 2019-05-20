using System.ComponentModel.DataAnnotations.Schema;

namespace Due.Models.Database
{
  [Table("user")]
  public class User : BaseEntity
  {
    [Column("FirstName")]
    public string FirstName { get; set; }

    [Column("LastName")]
    public string LastName { get; set; }

    [Column("Email")]
    public string Email { get; set; }
  }
}