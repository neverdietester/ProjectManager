using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjectManager
{
    [SetUpFixture]
    class SetUpFixture
    {
        [OneTimeSetUp]
        public void LoginAsAdmin()
        {
            AppManager.Instance.LoginPage.Authorization("administrator", "root1");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            AppManager.Instance.Browser.Navigate().GoToUrl(AppManager.Instance.Path + "logout_page.php");
        }
    }
}