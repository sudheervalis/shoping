using DataAxisLayer.Models;
using QoneRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QoneBusinessLayer.IMServices
{
    public interface ITaskService
    {
        Task<MGetTasksResponse> GetTasks(int userId);
        Task<MSaveTaskResponse> SaveTask(Mtask task);
        Task<MDeleteTaskResponse> DeleteTask(int taskId, int userId);
    }
}
