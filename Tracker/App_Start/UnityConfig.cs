using System.Web.Http;
using Tracker.Services.IOCConfig;
using Tracker.Services.IServices;
using Tracker.Services.Services;
using Unity;
using Unity.WebApi;

namespace Tracker
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ITaskService, TaskService>();
            container.RegisterType<IProjectService, ProjectService>();
            container.RegisterType<ITaskGroupService, TaskGroupService>();
            IOCConfig.RegisterComponents(container);

            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}