using CompetitionTask_ProjectMars.Pages;
using CompetitionTask_ProjectMars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionTask_ProjectMars.Tests
{
    public class ShareSkillTest : CommonDriver
    {
        [Test]
        public void SignIn()
        {
            driver = new ChromeDriver();
            // Login Page object initialization and definition
            LoginPage loginpageObj = new LoginPage(driver);
            loginpageObj.loginActions();
        }
    }
}
