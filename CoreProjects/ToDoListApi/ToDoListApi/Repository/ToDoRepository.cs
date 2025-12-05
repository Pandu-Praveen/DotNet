using System;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;
using ToDoListApi.Models;
using ToDoListApi.Repository;

namespace ToDoListApi.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ApplicationDbContext _context;

        public ToDoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoTask>> GetAllAsync()
        {
            return await _context.ToDoTasks.AsNoTracking().ToListAsync();
        }

        public async Task<ToDoTask?> GetByIdAsync(int id)
        {
            return await _context.ToDoTasks.FindAsync(id);
        }

        public async Task AddAsync(ToDoTask task)
        {
            await _context.ToDoTasks.AddAsync(task);
        }

        public Task UpdateAsync(ToDoTask task)
        {
            _context.ToDoTasks.Update(task);

            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _context.ToDoTasks.FindAsync(id);
            if (existing != null)
            {
                _context.ToDoTasks.Remove(existing);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
