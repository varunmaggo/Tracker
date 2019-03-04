using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.IRepository.Interfaces;
using Tracker.Repository.Repository;
using Unity;

namespace Tracker.Services.IOCConfig
{
    public static class IOCConfig
    {
        public static void RegisterComponents(UnityContainer unityContainer)
        {
            unityContainer.RegisterType<IUserRepository, UserRepository>();
            unityContainer.RegisterType<ITaskRepository, TaskRepository>();
            unityContainer.RegisterType<IProjectRepository, ProjectRepository>();
            unityContainer.RegisterType<ITaskGroupRepository, TaskGroupRepository>();
        }
       
    }
}
