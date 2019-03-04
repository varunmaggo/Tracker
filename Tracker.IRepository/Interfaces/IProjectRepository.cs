using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.IRepository.Models;

namespace Tracker.IRepository.Interfaces
{
    public interface IProjectRepository
    {
        IEnumerable<ProjectModel> GetAllProjects();
        void AddProject(ProjectModel project);
    }
}
