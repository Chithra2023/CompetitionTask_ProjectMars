using CompetitionTask_ProjectMars.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace CompetitionTask_ProjectMars.Pages
{
    public class ShareSkillPage : CommonDriver
    {
        private IWebElement shareSkillButton => driver.FindElement(By.LinkText("Share Skill"));
        private IWebElement titleTextBox => driver.FindElement(By.Name("title"));
        private IWebElement descriptionTextBox => driver.FindElement(By.Name("description"));
        private IWebElement categoryDropDown => driver.FindElement(By.Name("categoryId"));
        private IWebElement subCategoryDropDown => driver.FindElement(By.Name("subcategoryId"));
        private IWebElement Tags => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));

        private IList<IWebElement> serviceTypeRadioButton => driver.FindElements(By.Name("serviceType"));

        private IWebElement oneOffServiceRadio => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));
        private IWebElement hourlyServiceRadio => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));
        private IWebElement onsiteRadioButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input"));
        private IWebElement onlineRadioButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));
        private IList<IWebElement> locationTypeRadioButton => driver.FindElements(By.Name("locationType"));
        private IWebElement startDateDropDown => driver.FindElement(By.Name("startDate"));
        private IWebElement endDateDropDown => driver.FindElement(By.Name("endDate"));
        private IList<IWebElement> availableDays => driver.FindElements(By.XPath("//input[@name='Available']"));
        private IList<IWebElement> startTime => driver.FindElements(By.Name("StartTime"));
        private IList<IWebElement> endTime => driver.FindElements(By.Name("EndTime"));
        private IWebElement startTimeDropDown => driver.FindElement(By.XPath("//div[3]/div[2]/input[1]"));
        private IWebElement endTimeDropDown => driver.FindElement(By.XPath("//div[3]/div[3]/input[1]"));
        private IList<IWebElement> skillTradeRadioButton => driver.FindElements(By.Name("skillTrades"));
        private IWebElement skillExchangeRadioButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));
        private IWebElement creditRadioButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));
        private IWebElement SkillExchangeTag => driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@type='text']"));

        //private IList<IWebElement> skillExchangeTags => driver.FindElements(By.XPath("//form[@class='ui form']/div[8]/div[4]/div/div/div/div/span/a"));
        private IWebElement creditTextBox => driver.FindElement(By.XPath("//input[@placeholder='Amount']"));
        private IWebElement workSamplesButton => driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));
        private IList<IWebElement> isActiveRadioButton => driver.FindElements(By.XPath("//input[@name='isActive']"));
        private IWebElement activeRadioButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));
        private IWebElement hiddenRadioButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));
        private IWebElement saveButton => driver.FindElement(By.XPath("//input[@value='Save']"));

        public void AddShareSkill(int rowNumber)
        {
            Wait.WaitForElementToBeClickable(driver, "LinkText", "Share Skill", 10);
            shareSkillButton.Click();

            ExcelUtil.PopulateInCollection(@"C:\Chithra - Industry Connect\MVP Studio\Automation_Final\CompetitionTask_ProjectMars\ShareSkill_TestData.xlsx");

            //Enter Title
            Wait.WaitForElementToBeVisible(driver, "Name", "title", 10);
            titleTextBox.SendKeys(ExcelUtil.ReadData(rowNumber, "Title"));

            //Enter Description
            descriptionTextBox.SendKeys(ExcelUtil.ReadData(rowNumber, "Description"));

            //Select category
            //categoryDropDown.Click();
            SelectElement selectCategory = new SelectElement(categoryDropDown);
            selectCategory.SelectByText(ExcelUtil.ReadData(rowNumber, "Category"));

            //Select Subcategory
            SelectElement selectSubCategory = new SelectElement(subCategoryDropDown);
            selectSubCategory.SelectByText(ExcelUtil.ReadData(rowNumber, "Subcategory"));

            //Enter tag
            Tags.Click();
            Tags.SendKeys(ExcelUtil.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //Enter Service Type
            string ServiceTypeRadioLabel = ExcelUtil.ReadData(rowNumber, "ServiceType");

            if (ServiceTypeRadioLabel.Equals("One-off service"))
            {
                oneOffServiceRadio.Click();
            }

            if (ServiceTypeRadioLabel.Equals("Hourly basis service"))
            {
                hourlyServiceRadio.Click();
            }

            //Enter Location Type
             string LocationTypeRadioLabel = ExcelUtil.ReadData(rowNumber, "LocationType");
            if (LocationTypeRadioLabel.Equals("On-site"))
            {
                onsiteRadioButton.Click();
            }

            if (ServiceTypeRadioLabel.Equals("Online"))
            {
                onlineRadioButton.Click();
            }

            //Enter Start date
            startDateDropDown.SendKeys(ExcelUtil.ReadData(rowNumber, "StartDate"));

            //Enter End date
            endDateDropDown.SendKeys(ExcelUtil.ReadData(rowNumber, "EndDate"));

            //Enter Skill Trade
            string skillTradeRadioLabel = ExcelUtil.ReadData(rowNumber, "SkillTradeOption");
            if (skillTradeRadioLabel.Equals("Skill-exchange"))
            {
                skillExchangeRadioButton.Click();
                SkillExchangeTag.Click();
                SkillExchangeTag.SendKeys(ExcelUtil.ReadData(rowNumber, "SkillExchangeTag"));
                SkillExchangeTag.SendKeys(Keys.Enter);
            }
            if (skillTradeRadioLabel.Equals("Credit"))
            {
                creditRadioButton.Click();
                creditTextBox.SendKeys(ExcelUtil.ReadData(rowNumber, "CreditAmount"));
            }
            
            //Enter IsActive
            string activeTypeRadioLabel = ExcelUtil.ReadData(rowNumber, "ActiveOption");
            if (activeTypeRadioLabel.Equals("Active"))
            {
                activeRadioButton.Click();
            }

            if (activeTypeRadioLabel.Equals("Hidden"))
            {
                hiddenRadioButton.Click();
            }
            //Click on Save
            saveButton.Click();
        }
    }
}
