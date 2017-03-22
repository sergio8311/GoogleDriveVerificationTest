using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Google_Drive_Verification.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(12);
        }

        //UserName field
        [FindsBy(How = How.Id, Using = "Email")]
        [CacheLookup]
        public IWebElement UserName { get; set; }

        //Password field
        [FindsBy(How = How.Id, Using = "Passwd")]
        [CacheLookup]
        public IWebElement Password { get; set; }

        //Login button
        [FindsBy(How = How.Id, Using = "signIn")]
        [CacheLookup]
        public IWebElement LoginButton { get; set; }

        //Next button
        [FindsBy(How = How.Id, Using = "next")]
        [CacheLookup]
        public IWebElement NextButton { get; set; }

        //Click to NextButton
        public void ClickToNextButton()
        {
            NextButton.Click();
        }
        
        //click to LoginButton

        public void ClickToLoginButton()
        {
            LoginButton.Click();
        }

        public void Login(string userName, string password)
        {
            UserName.SendKeys(userName);
            NextButton.Click();
            Password.SendKeys(password);
            LoginButton.Click();
        }

    }


}