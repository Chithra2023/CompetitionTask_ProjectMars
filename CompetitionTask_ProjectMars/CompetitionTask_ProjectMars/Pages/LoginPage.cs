using CompetitionTask_ProjectMars.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionTask_ProjectMars.Pages
{
    public class LoginPage : CommonDriver
    {
        public LoginPage(IWebDriver driver)
        {

            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement signInButton;

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement userNameTextBox;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement passwordTextbox;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement loginButton;

        public void loginActions()
        {
            //Launch portal
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://192.168.0.107:5000/");
            //Click on SignIn
            signInButton.Click();

            ExcelUtil.PopulateInCollection(@"C:\Chithra - Industry Connect\MVP Studio\Automation_Final\CompetitionTask_ProjectMars\Login Details.xlsx");

            //Enter Username
            userNameTextBox.SendKeys(ExcelUtil.ReadData(2, "Username"));

            //Enter password
            passwordTextbox.SendKeys(ExcelUtil.ReadData(2, "Password"));

            //Click Login Button
            loginButton.Click();
        }
    }
}
