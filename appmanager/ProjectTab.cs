using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ProjectManager
{
    public class ProjectTab : HelperBase
    {
        public IWebElement Manage => app.Browser.FindElement(By.XPath("//a[contains(@href, 'manage_proj_page')]"));
        public ProjectTab(AppManager app) : base(app) { }

        public void CreateNewProject()
        {
            app.Browser.FindElement(By.XPath("//button[contains(text(), 'Create New Project')]")).Click();
        }
    }
}