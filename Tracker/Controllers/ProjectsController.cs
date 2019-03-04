using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tracker.IRepository.Models;
using Tracker.Services.IServices;

namespace Tracker.Controllers
{
    
    public class ProjectsController : ApiController
    {
        protected IProjectService projectService;

        public ProjectsController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        public IHttpActionResult GetProjects()
        {
            return Ok(projectService.GetProjects());
        }

        [HttpPost]
        public IHttpActionResult AddProject([FromBody] ProjectModel project)
        {
            return Ok(projectService.AddProject(project));
        }
    }
}