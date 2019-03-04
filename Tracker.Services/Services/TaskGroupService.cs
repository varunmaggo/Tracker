using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.IRepository.Interfaces;
using Tracker.IRepository.Models;
using Tracker.Services.Exceptions;
using Tracker.Services.IServices;

namespace Tracker.Services.Services
{
    public class TaskGroupService : ITaskGroupService
    {
        private ITaskGroupRepository TaskGroupRepo;

        public TaskGroupService(ITaskGroupRepository taskGroupRepo)
        {
            TaskGroupRepo = taskGroupRepo;
        }
        public int AddTaskGroup(TaskGroupModel taskGroup)
        {

            if (taskGroup == null)
            {
                throw new BaseException("TaskGroupService: Insert TaskGroupService did not receive a valid TaskGroup");
            }

            if (string.IsNullOrEmpty(taskGroup.GroupName))
                throw new BaseException("Invalid Task Group Name");

            if (TaskGroupRepo.GetByName(taskGroup.GroupName) != null) throw new BaseException("This task already exists");

            return TaskGroupRepo.AddTaskGroup(taskGroup);
        }

        public TaskGroupModel GetById(int id)
        {
            return TaskGroupRepo.GetById(id);
        }

        public List<TaskGroupModel> GetTaskGroups(TaskGroupFilter filter)
        {
            return TaskGroupRepo.GetAllTaskGroups(filter).ToList();
        }
    }
}
