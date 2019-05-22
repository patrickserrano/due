using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
        public Todo(string title, string details)
        {
            if (string.IsNullOrEmpty(Title))
                throw new Exception("Todo title is required");
            if (string.IsNullOrEmpty(Details))
                throw new Exception("Todo details is required");

            Title = title;
            Details = details;
        }
        public void UpdateTodoStatus(DatabaseContext context, bool todoCompleted)
        {
            this.Status = todoCompleted;
            context.Update(this);
            context.SaveChanges();
        }
    }
}