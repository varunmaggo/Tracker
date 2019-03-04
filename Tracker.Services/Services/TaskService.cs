using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.IRepository.Interfaces;
using Tracker.IRepository.Models;
using Tracker.Services.IServices;
using Tracker.Services.Models;

namespace Tracker.Services.Services
{
    public class TaskService : ITaskService
    {
        private ITaskRepository TaskRepo;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public TaskService(ITaskRepository taskRepo)
        {
            TaskRepo = taskRepo;
        }

        public List<TaskModel> GetTasks()
        {
            return TaskRepo.GetAllTasks().ToList();
        }

        public bool UpsertTask(TaskModel task)
        {
            log.Debug("Entered Upsert Task");
            try
            {
                if (task == null)
                {
                    throw new Exception("TaskService: UpsertTask did not receive a Task!");
                }
                // update
                if (task.Id_Task > 0)
                {
                    if (!TaskRepo.UpdateTask(task)) return false;
                }
                else
                {
                //insert
                    TaskRepo.AddTask(task);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
