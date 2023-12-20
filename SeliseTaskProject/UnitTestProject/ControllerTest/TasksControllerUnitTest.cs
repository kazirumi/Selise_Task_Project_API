using BusinessLogicLayer.Services.Tasks.DTOs;
using BusinessLogicLayer.Services.Tasks.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SeliseTaskProject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.ControllerTest
{
    public class TasksControllerUnitTest
    {
        private readonly Mock<ITasksService> taskService;
        public TasksControllerUnitTest()
        {
            taskService = new Mock<ITasksService>();
        }

        [Fact]
        public void GetTasksList_TaskstList()
        {
            //arrange
            var tasksList = GetTasksData();
            if(tasksList!=null)
            taskService.Setup(x => x.Get())
                .ReturnsAsync(tasksList);
            var tasksController = new TasksController(taskService.Object);
            //act
            var tasksResult = tasksController.Get();
            //assert
            Assert.NotNull(tasksResult);
            Assert.Equal(GetTasksData().Count(), tasksResult.Result.Count());
            tasksResult.Status.Equals(200);
            
        }

        [Fact]
        public async void GetTasksByID_Tasks()
        {
            //arrange
            var tasksList = GetTasksData();
            taskService.Setup(x => x.GetById(2))
                .ReturnsAsync(tasksList[1]);
            var tasksController = new TasksController(taskService.Object);
            //act
            var tasksResult = await tasksController.Get(2) as OkObjectResult;
            //assert
            Assert.NotNull(tasksResult);
            Assert.IsType<OkObjectResult>(tasksResult);
            var tasksResultValue = tasksResult.Value as TasksDTO;
            tasksResult.StatusCode.Equals(200);
            Assert.Equal(tasksList[1].Id, tasksResultValue.Id);
            
        }

        [Fact]
        public async void AddTasks_bool()
        {
            //arrange
            var tasksList = GetTasksData();
            var tasksCreateDTO = tasksList[2].Adapt<TasksCreateDTO>();

            taskService.Setup(x => x.Post(tasksCreateDTO))
                .ReturnsAsync(true);
            var tasksController = new TasksController(taskService.Object);
            //act
            var tasksResult =await tasksController.Post(tasksCreateDTO) as OkObjectResult;
            //assert
            Assert.NotNull(tasksResult);
            tasksResult.StatusCode.Equals(200);
            var tasksResultValue = Convert.ToBoolean(tasksResult.Value);
            Assert.Equal(tasksResultValue, true);
        }

        [Fact]
        public async void UpdateTasks_bool()
        {
            //arrange
            var tasksList = GetTasksData();
            var tasksEditDTO = tasksList[1].Adapt<TasksEditDTO>();
            taskService.Setup(x => x.GetById(1))
                .ReturnsAsync(tasksList[1]);

            taskService.Setup(x => x.Put(1,tasksEditDTO))
                .ReturnsAsync(true);

            var tasksController = new TasksController(taskService.Object);
            //act
            var tasksResult = await tasksController.Put(1,tasksEditDTO) as OkObjectResult;
            //assert
            Assert.NotNull(tasksResult);
            tasksResult.StatusCode.Equals(200);
            var tasksResultValue = Convert.ToBoolean(tasksResult.Value);
            Assert.Equal(tasksResultValue, true);
        }

        [Fact]
        public async void UpdateTasks_Could_Not_Found()
        {
            //arrange
            var tasksList = GetTasksData();
            var tasksEditDTO = tasksList[1].Adapt<TasksEditDTO>();
            taskService.Setup(x => x.GetById(1))
                .ReturnsAsync((TasksDTO)null);

            taskService.Setup(x => x.Put(1, tasksEditDTO))
                .ReturnsAsync(true);

            var tasksController = new TasksController(taskService.Object);
            //act
            var tasksResult = await tasksController.Put(1, tasksEditDTO) as NotFoundObjectResult;
            
            //assert
            Assert.NotNull(tasksResult);
            tasksResult.StatusCode.Equals(404); //Tasks not found
            
        }

        [Fact]
        public async void DeleteTasks_bool()
        {
            //arrange
            var tasksList = GetTasksData();
            
            taskService.Setup(x => x.GetById(1))
                .ReturnsAsync(tasksList[1]);

            taskService.Setup(x => x.Delete(1))
                .ReturnsAsync(true);

            var tasksController = new TasksController(taskService.Object);
            //act
            var tasksResult = await tasksController.Delete(1) as OkObjectResult;

            //assert
            Assert.NotNull(tasksResult);
            tasksResult.StatusCode.Equals(200); 
            var tasksResultValue = Convert.ToBoolean(tasksResult.Value);
            Assert.Equal(tasksResultValue, true);

        }

        [Fact]
        public async void DeleteTasks_Could_Not_Found()
        {
            //arrange
            var tasksList = GetTasksData();

            taskService.Setup(x => x.GetById(1))
                .ReturnsAsync((TasksDTO)null);

            taskService.Setup(x => x.Delete(1))
                .ReturnsAsync(true);

            var tasksController = new TasksController(taskService.Object);
            //act
            var tasksResult = await tasksController.Delete(1) as NotFoundObjectResult;

            //assert
            Assert.Null(tasksResult);


        }

        private List<TasksDTO> GetTasksData()
        {
            List<TasksDTO> tasksData = new List<TasksDTO>
        {
            new TasksDTO
            {
                Id=1,
                Title="Test",
                Description="Test",
                DueDate=DateTime.Now,
                Status="Pending"

            },
             new TasksDTO
            {
                Id=2,
                Title="Test",
                Description="Test",
                DueDate=DateTime.Now,
                Status="Pending"
            },
             new TasksDTO
            {
                Id=3,
                Title="Test",
                Description="Test",
                DueDate=DateTime.Now,
                Status="Pending"
            },
        };
            return tasksData;
        }
    }
}
