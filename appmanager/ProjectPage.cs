using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProjectManager.Mantis;
using System.Globalization;

namespace ProjectManager
{
    public class ProjectPage : HelperBase
    {
        public IList<IWebElement> Table => app.Browser.FindElements(By.XPath(
            "//i[@class='fa fa-puzzle-piece ace-icon']/ancestor::div[@class='widget-box widget-color-blue2']//tbody/tr"));
        public ProjectPage(AppManager app) : base(app) { }

        public ProjectCreatePage CreateNewProj()
        {
            app.Browser.FindElement(By.XPath("//button[@type='submit']")).Click();
            return new ProjectCreatePage(app);
        }

        public ProjectEditPage OpenProject(int id)
        {
            app.Browser.FindElement(By.XPath($"//td/a[contains(@href, 'id={id}')]")).Click();
            return new ProjectEditPage(app);
        }

        public IEnumerable<Project> GetProjectInTable()
        {
            List<Project> projectsList = new List<Project>();

            foreach (var value in Table)
            {
                var tds = value.FindElements(By.XPath("./td"));
                projectsList.Add(new Project() { Name = tds[0].Text, State = int.Parse(tds[1].Text), Visibility = int.Parse(tds[3].Text), Description = tds[4].Text });
            }

            return projectsList;
        }
    }
}