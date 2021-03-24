using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InveonTodoList.Controllers.Infrastructure;
using InveonTodoList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InveonTodoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _context;
        public ToDoController(ToDoContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> ToDoGetList()
        {
            IQueryable<TodoList> items = from list in _context.ToDoList orderby list.Id select list;
            List<TodoList> mytodolist = await items.ToListAsync();
            return View(mytodolist);
        }
    }
}