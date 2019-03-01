using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODO.Models;
using TODO.Helpers;

namespace TODO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        DataContext _context;
        public TodoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTodo()
        {
            var todos = _context.Todos.OrderBy(t => t.Id).ToList();
            return Ok(todos);
        }

        [HttpGet("{todoId}", Name = "GetTodo")]
        public IActionResult GetTodoById(int todoId)
        {
            var todo = _context.Todos.Find(todoId);
            if (todo == null) return NotFound();
            return Ok(todo);
        }

        [HttpPost]
        public IActionResult AddTodo([FromBody]Todo todoItem)
        {
            var newTodo = new Todo
            {
                TodoItem = todoItem.TodoItem,
                DateAdded = DateTime.Now
            };
            _context.Add(newTodo);
            _context.SaveChanges();
            return CreatedAtRoute("GetTodo", new { todoId = newTodo.Id }, newTodo);
        }

        [HttpPut("{todoId}")]
        public IActionResult FinishTodo(int todoId)
        {
            var todo = _context.Todos.Find(todoId);
            if (todo == null) return NotFound();
            if (todo.DateFinished != null) return BadRequest("Todo is already updated");
            todo.DateFinished = DateTime.Now;
            _context.Todos.Update(todo);
            _context.SaveChanges();
            return Ok(todo);
        }

        [HttpDelete("{todoId}")]
        public IActionResult DeleteTodo(int todoId)
        {
            var todo = _context.Todos.Find(todoId);
            if (todo == null) return NotFound();
            _context.Todos.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}