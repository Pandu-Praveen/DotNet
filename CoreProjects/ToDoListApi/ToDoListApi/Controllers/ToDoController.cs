using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Models;
using ToDoListApi.Repository;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        //Creating the repo object with Interface IToDoRepository type to access the data access layer
        private readonly IToDoRepository _repo;

        public ToDoController(IToDoRepository repo)
        {
            _repo = repo;
        }

        //Geting all tasks using async method
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repo.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ToDoTask task)
        {
            if (task == null)
                return BadRequest("Task is null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repo.AddAsync(task);
            await _repo.SaveAsync();

            return CreatedAtAction(nameof(GetById), new { id = task.TaskId }, task);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ToDoTask task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

           
            existing.Description = task.Description;
            existing.Priority = task.Priority;
            existing.StartDate = task.StartDate;
            existing.EndDate = task.EndDate;
            existing.Status = task.Status;

            await _repo.UpdateAsync(existing);
            await _repo.SaveAsync();

            return Ok(existing);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repo.DeleteAsync(id);
            await _repo.SaveAsync();

            return NoContent();
        }
    }
}
