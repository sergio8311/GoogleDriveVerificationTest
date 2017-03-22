using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Google_Drive_Verification.PageObjects
{
    public class MyAccountPage
    {
        private IWebDriver driver;

        public MyAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(12);
        }

        //Show More button
        [FindsBy(How = How.CssSelector, Using = "#gb#gb a.gb_b")]
        [CacheLookup]
        public IWebElement ShowMore { get; set; }

        [FindsBy(How = How.Id, Using = "gb49")]
        [CacheLookup]
        public IWebElement DriveButton { get; set; }

        //click to Show more button

        public void ClickToShowMoreButton()
        {
            ShowMore.Click();
        }

        //click to drive button
        public void ClickToDriveButton()
        {
            DriveButton.Click();
        }

    }
}