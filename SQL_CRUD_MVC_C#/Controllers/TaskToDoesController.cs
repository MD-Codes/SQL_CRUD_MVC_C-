using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQL_CRUD_MVC_C_.Data;
using SQL_CRUD_MVC_C_.Models;

namespace SQL_CRUD_MVC_C_.Controllers
{
    //[Route("TaskToDoes")]
    public class TaskToDoesController : Controller
    {
        private readonly ToDoDbContext _context;

        public TaskToDoesController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: TaskToDoes
        [Route("TaskToDoes")]
        [Route("TaskToDoes/Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaskToDo.ToListAsync());
        }

        // GET: TaskToDoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskToDo = await _context.TaskToDo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskToDo == null)
            {
                return NotFound();
            }

            return View(taskToDo);
        }

        // GET: TaskToDoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskToDoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskName,Description")] TaskToDo taskToDo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskToDo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskToDo);
        }

        // GET: TaskToDoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskToDo = await _context.TaskToDo.FindAsync(id);
            if (taskToDo == null)
            {
                return NotFound();
            }
            return View(taskToDo);
        }

        // POST: TaskToDoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskName,Description")] TaskToDo taskToDo)
        {
            if (id != taskToDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskToDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskToDoExists(taskToDo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(taskToDo);
        }

        // GET: TaskToDoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskToDo = await _context.TaskToDo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskToDo == null)
            {
                return NotFound();
            }

            return View(taskToDo);
        }

        // POST: TaskToDoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskToDo = await _context.TaskToDo.FindAsync(id);
            if (taskToDo != null)
            {
                _context.TaskToDo.Remove(taskToDo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskToDoExists(int id)
        {
            return _context.TaskToDo.Any(e => e.Id == id);
        }
    }
}
