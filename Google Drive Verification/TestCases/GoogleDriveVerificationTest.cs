using System;
using System.Threading;
using System.Windows.Forms;
using Google_Drive_Verification.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Google_Drive_Verification.PageObjects;

namespace Google_Drive_Verification.TestCases
{
    [TestFixture]
    public class GoogleDriveVerificationTest
    {
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Initialize()
        {
            driver.Manage().Window.Maximize();
            //url to login page
            driver.Url = "https://accounts.google.com/ServiceLogin";
            Console.WriteLine("Opened LoginPage");
        }
        
        [Test]
        public void UploadAndDelteFile()
        {
               
            var userName = "g.drive.test.serg@gmail.com";
            var Password = "GoogleDriveVerificationTest";
            var path = @"C:\Projects\GoogleDriveVerificationTest\TestFile\TestFile.txt";
            var expectedFileName = "TestFile.txt";

            var loginPage = new LoginPage(driver);
            var myAccountPage = new MyAccountPage(driver);
            var seleniumExtensions = new SeleniumExtensions();
            var goolgeDrivePage = new GoogleDrivePage(driver);


            //login to Googl account
            loginPage.Login(userName, Password);
            

            //open Google Drive
            myAccountPage.ClickToShowMoreButton();
            myAccountPage.ClickToDriveButton();

            //click to add button
            goolgeDrivePage.ClickToAddButton();
            goolgeDrivePage.ClickToUploadFileButton();
            
            //upload file to google drive
            seleniumExtensions.UploadFile(path);

            //open recently uploaded file
            goolgeDrivePage.ClickToRecentlyButton();

            Thread.Sleep(1500);
            if (goolgeDrivePage.FindTestFile().Text == expectedFileName)
            {
                goolgeDrivePage.ClickToUploadedFile();
                goolgeDrivePage.ClickToDelteButton();
                goolgeDrivePage.ClickToMyAvatar();
                goolgeDrivePage.Logout();
                Console.WriteLine("Logout complete");
                //driver.SwitchTo().Alert().Accept();
            }
               
            else
            {
                Console.WriteLine("The file wasn’t uploaded");
                //MessageBox.Show("The file wasn’t uploaded");

            }
            
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
            Console.WriteLine("Close the browser");
        }

    }
    
}