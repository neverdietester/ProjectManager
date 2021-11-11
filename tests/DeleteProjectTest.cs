using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProjectManager.Mantis;

namespace ProjectManager
{
    [TestFixture]
    class DeleteProjectTest
    {
        private readonly Project projectModel = new Project()
        {
            Name = Guid.NewGuid().ToString(),
            State = 10,
            IsInheritCriteria = true,
            Visibility = 50,
            Description = "test"
        };

        [OneTimeSetUp]
        public void OpenMenu()
        {
            AppManager.Instance.SideBar.Manage.Click();
            AppManager.Instance.Menu.Manage.Click();

            if (!AppManager.Instance.SoapHelper.GetProjects().Any())
            {
                AppManager.Instance.SoapHelper.AddNewProject(new ProjectData()
                {
                    name = "project1",
                    description = "project2",
                    enabled = true
                });
                AppManager.Instance.Browser.Navigate().Refresh();
            }
        }


        [Test]
        public void DeleteProjectInSystem()
        {
          
            var expectedProject = AppManager.Instance.SoapHelper.GetProjects().OrderBy(x => x.Id).ToList();
            AppManager.Instance.ManageProjectPage.OpenProject(expectedProject.First().Id).DeleteProject();
            expectedProject.Remove(expectedProject.First());
        
            Assert.That(AppManager.Instance.SoapHelper.GetProjects().ToList(), Is.EquivalentTo(expectedProject).Using(new ProjectComparer()));
        }

    }
}