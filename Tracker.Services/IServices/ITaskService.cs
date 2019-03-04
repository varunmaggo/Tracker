using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.IRepository.Models;
using Tracker.Services.Models;

namespace Tracker.Services.IServices
{
    public interface ITaskService
    {
        List<TaskModel> GetTasks();
        bool UpsertTask(TaskModel task);
    }
}
