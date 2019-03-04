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
    public class TaskGroupRepository : BaseRepository, ITaskGroupRepository
    {
        public int AddTaskGroup(TaskGroupModel taskGroup)
        {
            var dbTg = DbContext.TaskGroups.Where(x => x.Id_TaskGroup == taskGroup.Id_TaskGroupModel).FirstOrDefault();
            var toAdd = false;
            if (dbTg == null)
            {
                dbTg = new TaskGroups();
                toAdd = true;
            }

            dbTg.GroupName = taskGroup.GroupName;

            if (toAdd)
                DbContext.TaskGroups.Add(dbTg);

            return DbContext.SaveChanges();
        }

        public IQueryable<TaskGroupModel> GetTask_QRY()
        {
            var result = DbContext.TaskGroups.Select(x => new TaskGroupModel()
            {
                GroupName = x.GroupName,
                Id_TaskGroupModel = x.Id_TaskGroup
            }).AsQueryable();

            return result;
        }

        public IEnumerable<TaskGroupModel> GetAllTaskGroups(TaskGroupFilter filter)
        {
            bool filterByName = false;
            if (!string.IsNullOrEmpty(filter.Name))
                filterByName = true;
            return GetTask_QRY().Where(x =>
            (filterByName ? x.GroupName.Contains(filter.Name) : true)
            ).ToList();
        }

        public TaskGroupModel GetById(int id)
        {
            return GetTask_QRY().Where(x => x.Id_TaskGroupModel == id).FirstOrDefault();
        }

        public TaskGroupModel GetByName(string name)
        {
            return GetTask_QRY().Where(x => x.GroupName == name).FirstOrDefault();
        }
    }
}
