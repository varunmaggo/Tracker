using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.IRepository.Interfaces;
using Tracker.IRepository.Models;
using Tracker.Services.IServices;

namespace Tracker.Services.Services
{
    public class ProjectService : IProjectService
    {
        private IProjectRepository projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public bool AddProject(ProjectModel project)
        {
            try
            {
                if (project == null)
                {
                    throw new Exception("Project Service: AddProject received null");
                }
                projectRepository.AddProject(project);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ProjectModel> GetProjects()
        {
            return projectRepository.GetAllProjects().ToList();
        }
    }
}
