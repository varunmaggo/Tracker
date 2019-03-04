using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.IRepository.Models;

namespace Tracker.IRepository.Interfaces
{
    public interface ITaskGroupRepository
    {
        IEnumerable<TaskGroupModel> GetAllTaskGroups(TaskGroupFilter filter);
        int AddTaskGroup(TaskGroupModel taskGroup);
        TaskGroupModel GetById(int id);
        TaskGroupModel GetByName(string name);
    }
}
