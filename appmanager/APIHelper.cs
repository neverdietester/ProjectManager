using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Mantis;


namespace ProjectManager.Mantis
{
    public class APIHelper 
    {
        private readonly MantisConnectPortTypeClient client;
        public APIHelper()
        {
            client = new MantisConnectPortTypeClient();
        }

        public IEnumerable<Project> GetProjects(string user = "administrator", string password = "root1")
        {
            var projects = client.mc_projects_get_user_accessible(user, password);
            return projects.Select(x => new Project()
            {
                Id = int.Parse(x.id),
                Name = x.name,
                Description = x.description,
                State = int.Parse(x.status.id),
                Visibility = int.Parse(x.view_state.id),
                IsInheritCriteria = x.inherit_global

            });
        }

        public string AddNewProject(ProjectData project, string user = "administrator", string password = "root1")
        {
            var result = client.mc_project_add(user, password, project);
            return result;
        }
    }
}