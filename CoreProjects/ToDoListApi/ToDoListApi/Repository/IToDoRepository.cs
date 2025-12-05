using ToDoListApi.Models;

namespace ToDoListApi.Repository
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDoTask>> GetAllAsync();
        Task<ToDoTask?> GetByIdAsync(int id);
        Task AddAsync(ToDoTask task);
        Task UpdateAsync(ToDoTask task);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}

