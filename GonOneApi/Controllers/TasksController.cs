﻿using DataAxisLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QoneBusinessLayer.IMServices;
using QoneModel;
using QoneRepository;
using QoneRepository.IRepository;

namespace GonOneApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : BaseApiController
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int UserID)
        {
            var getTasksResponse = await taskService.GetTasks(UserID);

            if (!getTasksResponse.Success)
            {
                return UnprocessableEntity(getTasksResponse);
            }

            var tasksResponse = getTasksResponse.Tasks.ConvertAll(o => new MTaskResponse { Id = o.Id, IsCompleted = o.IsCompleted, Name = o.Name, Ts = o.Ts });

            return Ok(tasksResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MTaskRequest taskRequest)
        {
            var task = new Mtask { IsCompleted = taskRequest.IsCompleted, Ts = taskRequest.Ts, Name = taskRequest.Name, UserId = UserID };

            var saveTaskResponse = await taskService.SaveTask(task);

            if (!saveTaskResponse.Success)
            {
                return UnprocessableEntity(saveTaskResponse);
            }

            var taskResponse = new MTaskResponse { Id = saveTaskResponse.Task.Id, IsCompleted = saveTaskResponse.Task.IsCompleted, Name = saveTaskResponse.Task.Name, Ts = saveTaskResponse.Task.Ts };

            return Ok(taskResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest(new MDeleteTaskResponse { Success = false, ErrorCode = "D01", Error = "Invalid Task id" });
            }
            var deleteTaskResponse = await taskService.DeleteTask(id, UserID);
            if (!deleteTaskResponse.Success)
            {
                return UnprocessableEntity(deleteTaskResponse);
            }

            return Ok(deleteTaskResponse.TaskId);
        }

        [HttpPut]
        public async Task<IActionResult> Put(MTaskRequest taskRequest)
        {
            var task = new Mtask { Id = taskRequest.Id, IsCompleted = taskRequest.IsCompleted, Ts = taskRequest.Ts, Name = taskRequest.Name, UserId = UserID };

            var saveTaskResponse = await taskService.SaveTask(task);

            if (!saveTaskResponse.Success)
            {
                return UnprocessableEntity(saveTaskResponse);
            }

            var taskResponse = new MTaskResponse { Id = saveTaskResponse.Task.Id, IsCompleted = saveTaskResponse.Task.IsCompleted, Name = saveTaskResponse.Task.Name, Ts = saveTaskResponse.Task.Ts };

            return Ok(taskResponse);
        }
    }
}
