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
        private object loginpageObj;

        public ShareSkillTest()
        {
            driver = new ChromeDriver(); 
        
        }
        [OneTimeSetUp]
        public void SignIn()
        {
            // Login Page object initialization and definition
            LoginPage loginpageObj = new LoginPage(driver);
            loginpageObj.loginActions();
        }

        [Test]
       public void AddShareSkill()
        {
            // Login Page object initialization and definition
            ShareSkillPage shareSkillPageObj = new ShareSkillPage();
            shareSkillPageObj.AddShareSkill(2);

        }
    }
}
