using BusinessLogicLayer.Services.Tasks.DTOs;
using BusinessLogicLayer.Services.Tasks.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SeliseTaskProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet]
        public async Task<IEnumerable<TasksDTO>> Get()
        {
            return await _tasksService.Get();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();
            var task = await _tasksService.GetById(id);
            if (task == null)
                return NotFound();
            return Ok(task);

        }

        [HttpPost]
        public async Task<IActionResult> Post(TasksCreateDTO task)
        {
            var result = await _tasksService.Post(task);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,TasksEditDTO taskData)
        {
            if (taskData == null || id==0)
                return BadRequest();

            var task = await _tasksService.GetById(id);
            if (taskData == null)
                return NotFound();
            
           
            return Ok(await _tasksService.Put(id,taskData));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var task = await _tasksService.GetById(id); ;
            if (task == null)
                return NotFound();

            return Ok(await _tasksService.Delete(id));

        }
    }
}
