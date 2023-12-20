using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Domain.Respository
{
    public class TasksRepository : ITasksRepository
    {
        private readonly ApplicationDBContext _context;

        public TasksRepository(ApplicationDBContext context)
        {
            _context = context;
        }


        public async Task<List<Tasks>> Get()
        {
            return await _context.Tasks.ToListAsync();

        }


        public async Task<Tasks> GetById(int id)
        {
            return (Tasks)await _context.Tasks.FirstOrDefaultAsync(m => m.Id == id);

        }


        public async Task<bool> Post(Tasks task)
        {
            var done =_context.Add(task);
            _context.SaveChanges();
             
            return true;

        }


        public async Task<bool> Put(Tasks taskData)
        {

            var task = await _context.Tasks.FindAsync(taskData.Id);
            task.Title = taskData.Title;
            task.Description = taskData.Description;
            task.Status = taskData.Status;
            task.DueDate = taskData.DueDate;
            
            _context.SaveChanges();

            return true;

        }


        public async Task<bool> Delete(int id)
        {
            
            var task = await _context.Tasks.FindAsync(id);

            _context.Tasks.Remove(task);
             _context.SaveChanges();

            return true;

        }


    }
}
