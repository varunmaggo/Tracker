using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.IRepository.Models;

namespace Tracker.IRepository.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<TaskModel> GetAllTasks();
        void AddTask(TaskModel task);
        bool UpdateTask(TaskModel task);
    }
}
