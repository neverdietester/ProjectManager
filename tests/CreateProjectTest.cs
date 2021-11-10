using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjectManager
{
    [TestFixture]
    class DeleteProjectTest
    {
        private readonly Project _projectModel = new Project()
        {
            Name = Guid.NewGuid().ToString(),
            State = "release",
            IsInheritCriteria = true,
            Visibility = "public",
            Description = "test"
        };

        [OneTimeSetUp]
        public void OpenMenu()
        {
            AppManager.Instance.SideBar.Manage.Click();
            AppManager.Instance.Menu.Manage.Click();

            if (!AppManager.Instance.ManageProjectPage.Table.Any())
            {
                AppManager.Instance.ManageProjectPage.CreateNewProj().AddNewProject(_projectModel);
            }
        }

        [Test]
        public void DeleteProjectInSystem()
        {
            var expectedProject = AppManager.Instance.ManageProjectPage.GetProjectInTable().ToList();
            expectedProject.Remove(expectedProject.First());
            AppManager.Instance.ManageProjectPage.OpenProject(0).DeleteProject();

            Assert.That(AppManager.Instance.ManageProjectPage.GetProjectInTable(), Is.EquivalentTo(expectedProject).Using(new ProjectComparer()));
        }
    }
}