using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Google_Drive_Verification.PageObjects
{
    public class GoogleDrivePage
    {
        private IWebDriver driver;
        private IWebElement findTestFile;
        private IWebElement uploadFileElement;


        public GoogleDrivePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(12);
        }

        //Show More button
        [FindsBy(How = How.CssSelector, Using = ".Kzazxf.x6jRSb:not(.VuWATc)")]
        [CacheLookup]
        public IWebElement AddFile { get; set; }


        [FindsBy(How = How.Id, Using = "nt:Driv:label")]
        [CacheLookup]
        public IWebElement RecentlyUploaded { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='drive_main_page']/div[2]/div/div[1]/div/div/div[3]/div[2]/div/div[3]/div/div[2]/div/div[4]")]
        [CacheLookup]
        public IWebElement DelteButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".gb_9a")]
        [CacheLookup]
        public IWebElement MyAvatar { get; set; }

        [FindsBy(How = How.Id, Using = "gb_71")]
        [CacheLookup]
        public IWebElement LogoutButton { get; set; }

 
        public void ClickToAddButton()
        {
            AddFile.Click();
        }

        public IWebElement UploadFileElement()
        {
            var menus = driver.FindElements(By.CssSelector("div[role='menuitem']"));
            uploadFileElement = menus.FirstOrDefault(x => x.Text.Contains("File upload"));
            return uploadFileElement;
        }

        public void ClickToUploadFileButton()
        {
            UploadFileElement();
            UploadFileElement().Click();
        }

        public void ClickToRecentlyButton()
        {
            RecentlyUploaded.Click();
        }

        public IWebElement FindTestFile()
        {
            var listOfFiles = driver.FindElements(By.CssSelector("span[class='l-Ab-T-r']"));
            findTestFile = listOfFiles.FirstOrDefault(x => x.Text.Contains("TestFile.txt"));
            return findTestFile;           
        }

        public void ClickToUploadedFile()
        {
            FindTestFile();
            findTestFile.Click();
        }

        public void ClickToDelteButton()
        {            
            DelteButton.Click();
        }

        public void ClickToMyAvatar()
        {
            MyAvatar.Click();
        }

        public void Logout()
        {
            LogoutButton.Click();
        }
         
    }
}