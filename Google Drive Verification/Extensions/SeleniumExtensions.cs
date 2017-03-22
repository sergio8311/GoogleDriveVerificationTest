using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;

namespace Google_Drive_Verification.Extensions
{
    public class SeleniumExtensions
    {
        public void UploadFile(string path)
        {
            SendKeys.SendWait(path);
            Thread.Sleep(1000);
            SendKeys.SendWait(@"{Enter}");
            Thread.Sleep(1000);
        }


    }
}