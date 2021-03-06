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
        public async Task<ActionResult> Index()
        {
            _context.Database.EnsureCreated();
            IQueryable<TodoList> items = from list in _context.ToDoList orderby list.Id select list;
            List<TodoList> mytodolist = await items.ToListAsync();

            var now = DateTime.Parse(DateTime.Now.ToString("g"));

            var  itemTime= await _context.ToDoList.Where(x => x.CreatDateTime == now).ToListAsync();
            if (itemTime.Count > 0)
            {
                TempData["Success2"] = $"{now} Girilen item zamanı gelmiştir!  {string.Join(",",itemTime.Select(x => x.Content))}";
            }
            
            return View(mytodolist);
        }
        public IActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TodoList item)
        {
            if(ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                TempData["Success"] = "İtem Başarıyla Eklendi!";
                return RedirectToAction("Index");
            }
            return View(item);
        }
        public async Task<ActionResult> Edit(int id)
        {
            TodoList item = await _context.ToDoList.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TodoList item)
        {
            if (ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                TempData["Success"] = "İtem Başarıyla Güncellendi!";
                return RedirectToAction("Index");
            }
            return View(item);
        }
        public async Task<ActionResult> Delete(int id)
        {
            TodoList item = await _context.ToDoList.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "Böyle bir kayıt bulunmamıştır!";
            }
            else
            {
                _context.ToDoList.Remove(item);
                await _context.SaveChangesAsync();
                TempData["Success"] = "İtem Başarıyla Silinmiştir!";
            }
            return View(item);
        }
    }
}