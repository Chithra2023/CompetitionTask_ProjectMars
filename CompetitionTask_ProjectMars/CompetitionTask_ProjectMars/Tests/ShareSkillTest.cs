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

        [Test, Order(1)]
        public void AddShareSkill()
        {
            // Login Page object initialization and definition
            ShareSkillPage shareSkillPageObj = new ShareSkillPage();
            shareSkillPageObj.AddShareSkillListing(2);
        }

        [Test, Order(2)]
        public void EditListing()
        {
            // Login Page object initialization and definition
            ManageListingsPage manageListingPageObj = new ManageListingsPage();
            manageListingPageObj.EditListings(2);
        }
        [Test, Order(3)]
        public void DeleteListing()
        {
            ManageListingsPage manageListingPageObj = new ManageListingsPage();
            manageListingPageObj.DeleteListings(2);

        }

        [TearDown]
        public void quit()
        {
            driver.Quit();
        }
    }
}
