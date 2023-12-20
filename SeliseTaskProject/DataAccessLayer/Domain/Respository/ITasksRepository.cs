using DataAccessLayer.Entities;

namespace DataAccessLayer.Domain.Respository
{
    public interface ITasksRepository
    {
        Task<bool> Delete(int id);
        Task<List<Tasks>> Get();
        Task<Tasks> GetById(int id);
        Task<bool> Post(Tasks task);
        Task<bool> Put(Tasks taskData);
    }
}