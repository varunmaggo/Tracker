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
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public void AddProject(ProjectModel project)
        {
            DbContext.Projects.Add(new Projects()
            {
                Name = project.Name
            });
        }

        public IEnumerable<ProjectModel> GetAllProjects()
        {
            var result = DbContext.Projects.Select(x => new ProjectModel()
            {
                Name = x.Name,
                Id_Project = x.Id_Project
            }).ToList();
            return result;
        }
    }
}
