using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ProjectManager
{
    public class ProjectCreatePage : HelperBase
    {
        public ProjectCreatePage(AppManager app) : base(app) { }

        public ProjectPage AddNewProject(Project project)
        {
            app.Browser.FindElement(By.Id("project-name")).SendKeys(project.Name);
            
            new SelectElement(app.Browser.FindElement(By.Id("project-status"))).SelectByText(project.State);
            if (project.IsInheritCriteria)
                app.Browser.FindElement(By.XPath("//input[@id='project-inherit-global']/../span")).Click();
            new SelectElement(app.Browser.FindElement(By.Id("project-view-state"))).SelectByText(project.Visibility);
            
            app.Browser.FindElement(By.Id("project-description")).SendKeys(project.Description);
            app.Browser.FindElement(By.XPath("//input[@value='Add Project']")).Click();
            
            var wait = new WebDriverWait(app.Browser, new TimeSpan(0, 0, 10));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(d => d.FindElement(By.XPath("//div[@class='table-responsive']")));

            return new ProjectPage(app);
        }
    }
}