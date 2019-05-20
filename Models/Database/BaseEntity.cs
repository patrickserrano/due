using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Due.Models.Database
{
  public class BaseEntity
  {
    [Column("id")]
    public int Id { get; set; }

    [Column("CreatedAt")]
    public DateTime CreatedAt { get; set; }

    [Column("UpdatedAt")]
    public DateTime UpdatedAt { get; set; }
  }
}