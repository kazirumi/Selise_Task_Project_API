using BusinessLogicLayer.Services.Tasks.DTOs;
using DataAccessLayer.Data;
using DataAccessLayer.Domain.Respository;
using DataAccessLayer.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BusinessLogicLayer.Services.Tasks.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

      
        public async Task<List<TasksDTO>> Get()
        {
            var Tasks= await _tasksRepository.Get();
            if(Tasks.Count()>0)
            return Tasks.Adapt<List<TasksDTO>>();

            return null;

        }


        public async Task<TasksDTO> GetById(int id)
        {
            var task= await _tasksRepository.GetById(id);

            if (task != null)
                return task.Adapt<TasksDTO>();

            return null;
        }


        public async Task<bool> Post(TasksCreateDTO taskData)
        {
            var task = taskData.Adapt<DataAccessLayer.Entities.Tasks>();
            await _tasksRepository.Post(task);
            return true;

        }


        public async Task<bool> Put(int id,TasksEditDTO taskData)
        {
            
            var task = taskData.Adapt<DataAccessLayer.Entities.Tasks>();
            task.Id = id;
            await _tasksRepository.Put(task);
            return true;

        }


        public async Task<bool> Delete(int id)
        {
            await _tasksRepository.Delete(id);
            return true;
        }

       
    }
}
