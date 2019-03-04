using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.IRepository.Interfaces;
using Tracker.IRepository.Models;
using Tracker.Data;

namespace Tracker.Repository.Repository
{
    public class TaskRepository: BaseRepository, ITaskRepository
    {
        public void AddTask(TaskModel task)
        {
            DbContext.Tasks.Add(new Tasks()
            {
                Name = task.Name,
                Description = task.Description,
                Project_Id = task.Project_Id,
                TaskGroup_Id = task.TaskGroup_Id
            });
            DbContext.SaveChanges();
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            var result = DbContext.Tasks.Select(x => new TaskModel()
            {
                Name = x.Name,
                Description = x.Description,
                Project_Id = x.Project_Id,
                TaskGroup_Id = x.TaskGroup_Id,
                Id_Task = x.Id_Task
            }).ToList();
            return result;
        }

        public bool UpdateTask(TaskModel task)
        {
            var result = DbContext.Tasks.Find(task.Id_Task);
            if (result == null) return false;
            
            else
            {
                if (task.Name != null) result.Name = task.Name;
                if (task.Description != null) result.Description = task.Description;
                if (task.Project_Id!= null) result.Description = task.Description;
                if (task.TaskGroup_Id != null) result.TaskGroup_Id= task.TaskGroup_Id;
                DbContext.SaveChanges();
                return true;
            }
        }
    }
}
