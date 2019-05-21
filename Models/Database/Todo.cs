using System.ComponentModel.DataAnnotations.Schema;

namespace Due.Models.Database
{
    public class Todo : BaseEntity
    {
        [Column("Title")]
        public string Title { get; set; }
        [Column("Details")]
        public string Details { get; set; }
        [Column("Status")]
        public bool Status { get; set; }
        [Column("User")]
        public User User { get; set; }
    }
}