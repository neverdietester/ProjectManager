using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ProjectManager
{
    public class AppManager
    {
        private const string Path = "http://localhost/mantisbt-2.25.2/";
        private static readonly Lazy<AppManager> Lazy =
            new Lazy<AppManager>(() => new AppManager());
        public static AppManager Instance => Lazy.Value;
        public IWebDriver Browser { get; }
        public LoginPage LoginPage { get; }
        public ProjectTab Menu { get; }
        public NavigatorTab SideBar { get; }
        public ProjectPage ManageProjectPage { get; }
        public ProjectCreatePage ManageProjectCreatePage { get; }

        private AppManager()
        {
            Browser = new FirefoxDriver("C:\\");
            Browser.Navigate().GoToUrl(Path);
            LoginPage = new LoginPage(this);
            Menu = new ProjectTab(this);
            SideBar = new NavigatorTab(this);
            ManageProjectPage = new ProjectPage(this);
            ManageProjectCreatePage = new ProjectCreatePage(this);
        }
    }
}