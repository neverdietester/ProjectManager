using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ProjectManager
{
    public class LoginPage : HelperBase
    {
        public IWebElement UserName => app.Browser.FindElement(By.Id("username"));
        public IWebElement Password => app.Browser.FindElement(By.Id("password"));
        public IWebElement Enter => app.Browser.FindElement(By.XPath("//input[@value='Login']"));
        public LoginPage(AppManager app) : base(app) { }

        public void Authorization(string username, string password)
        {
            UserName.SendKeys(username);
            Enter.Click();
            Password.SendKeys(password);
            Enter.Click();
        }
    }
}