using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Due.Models;
using Due.Models.Database;

namespace Due.Controllers
{
    public class TodoController : Controller
    {
        private readonly DatabaseContext _context;
        public TodoController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            User testUser = new User("b", "b", "b@example.com");
            _context.Add(testUser);
            _context.SaveChanges();
            Todo todo = new Todo("test2", "this is a test");
            todo.User = testUser;
            _context.Add(todo);
            _context.SaveChanges();
            return View();
        }
    }
}