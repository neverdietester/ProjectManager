using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ProjectManager
{
    public class ProjectEditPage : HelperBase
    {
        public ProjectEditPage(AppManager app) : base(app) { }

        public ProjectPage DeleteProject()
        {
            for (int i = 0; i < 2; i++)
                app.Browser.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            return new ProjectPage(app);
        }
    }
}