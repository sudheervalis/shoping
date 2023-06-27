using DataAxisLayer.Models;
using Microsoft.EntityFrameworkCore;
using QoneBusinessLayer.IMServices;
using QoneRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QoneBusinessLayer.MService
{
    public class TaskService : ITaskService
    {
        private readonly RaoneContext tasksDbContext;

        public TaskService(RaoneContext _tasksDbContext)
        {
            this.tasksDbContext = _tasksDbContext;
        }

        public async Task<MDeleteTaskResponse> DeleteTask(int taskId, int userId)
        {
            var task = await tasksDbContext.Mtasks.FindAsync(taskId);

            if (task == null)
            {
                return new MDeleteTaskResponse
                {
                    Success = false,
                    Error = "Task not found",
                    ErrorCode = "T01"
                };
            }

            if (task.UserId != userId)
            {
                return new MDeleteTaskResponse
                {
                    Success = false,
                    Error = "You don't have access to delete this task",
                    ErrorCode = "T02"
                };
            }

            tasksDbContext.Mtasks.Remove(task);

            var saveResponse = await tasksDbContext.SaveChangesAsync();

            if (saveResponse >= 0)
            {
                return new MDeleteTaskResponse
                {
                    Success = true,
                    TaskId = task.Id
                };
            }

            return new MDeleteTaskResponse
            {
                Success = false,
                Error = "Unable to delete task",
                ErrorCode = "T03"
            };
        }

        public async Task<MGetTasksResponse> GetTasks(int userId)
        {
            var tasks = await tasksDbContext.Mtasks.Where(o => o.UserId == userId).ToListAsync();

            return new MGetTasksResponse { Success = true, Tasks = tasks };

        }

        public async Task<MSaveTaskResponse> SaveTask(Mtask task)
        {
            if (task.Id == 0)
            {
                await tasksDbContext.Mtasks.AddAsync(task);
            }
            else
            {
                var taskRecord = await tasksDbContext.Mtasks.FindAsync(task.Id);

                taskRecord.IsCompleted = task.IsCompleted;
                taskRecord.Ts = task.Ts;
            }

            var saveResponse = await tasksDbContext.SaveChangesAsync();

            if (saveResponse >= 0)
            {
                return new MSaveTaskResponse
                {
                    Success = true,
                    Task = task
                };
            }
            return new MSaveTaskResponse
            {
                Success = false,
                Error = "Unable to save task",
                ErrorCode = "T05"
            };
        }
    }
}
