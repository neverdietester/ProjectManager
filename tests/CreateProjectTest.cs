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
    class CreateProjectTest
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

        }

        [Test]
        public void CreateNewProjectInSystem()
        { 
        var expectedProject = AppManager.Instance.SoapHelper.GetProjects().ToList();
        expectedProject.Add(projectModel);
            AppManager.Instance.ManageProjectPage.CreateNewProj().AddNewProject(projectModel);
        
        Assert.That(AppManager.Instance.SoapHelper.GetProjects().ToList(), Is.EquivalentTo(expectedProject).Using(new ProjectComparer()));
        }

}
}