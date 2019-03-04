using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.IRepository.Models;

namespace Tracker.Services.IServices
{
public    interface IProjectService 
    {
        List<ProjectModel> GetProjects();
        bool AddProject(ProjectModel project);
    }
}
