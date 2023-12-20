using BusinessLogicLayer.Services.Tasks.DTOs;

namespace BusinessLogicLayer.Services.Tasks.Services
{
    public interface ITasksService
    {
        Task<bool> Delete(int id);
        Task<List<TasksDTO>> Get();
        Task<TasksDTO> GetById(int id);
        Task<bool> Post(TasksCreateDTO task);
        Task<bool> Put(int id,TasksEditDTO taskData);
    }
}