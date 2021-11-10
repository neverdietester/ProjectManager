using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ProjectManager
{
    public class NavigatorTab : HelperBase
    {
        public IWebElement Manage => app.Browser.FindElement(By.XPath("//a[contains(@href, 'manage_overview_page')]"));
        public NavigatorTab(AppManager app) : base(app) { }

    }
}