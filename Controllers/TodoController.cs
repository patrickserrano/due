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
    [Route("/[controller]/api/v1/")]
    [Route("/[controller]")]
    public class TodoController : Controller
    {
        private readonly DatabaseContext _context;
        public TodoController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This is the route for creating a new todo. The UI can use the pretty URI `/todo/new` while the backend API can use the versioned URI `/todo/api/v1/new`
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        [HttpPost("new")]
        public string New([FromBody] Todo todo)
        {
            _context.Add(todo);
            _context.SaveChanges();
            return "Saved!";
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }

    }
}