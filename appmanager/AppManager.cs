using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using ProjectManager.Mantis;

namespace ProjectManager
{
    public class AppManager
    {
        public string Path => "http://localhost/mantisbt-2.25.2/";
        private static readonly Lazy<AppManager> Lazy =
            new Lazy<AppManager>(() => new AppManager());
        public static AppManager Instance => Lazy.Value;
        public IWebDriver Browser { get; }
        public LoginPage LoginPage { get; }
        public ProjectTab Menu { get; }
        public NavigatorTab SideBar { get; }
        public ProjectPage ManageProjectPage { get; }
        public ProjectCreatePage ManageProjectCreatePage { get; }

        public APIHelper SoapHelper { get; set; }

        private AppManager()
        {
            Browser = new FirefoxDriver("C:\\");
            Browser.Navigate().GoToUrl(Path);
            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            LoginPage = new LoginPage(this);
            Menu = new ProjectTab(this);
            SideBar = new NavigatorTab(this);
            ManageProjectPage = new ProjectPage(this);
            ManageProjectCreatePage = new ProjectCreatePage(this);
            SoapHelper = new APIHelper();
        }
    }
}