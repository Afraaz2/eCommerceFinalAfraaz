using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Support
{
    internal static class SupporterMethods
    {
        public static void TakeScreenShot(IWebDriver driver, string FileName)
        {
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\AfraazTiwana\Pictures\Saved Pictures\" + FileName + ".png", ScreenshotImageFormat.Png);
        }

        public static void TakeScreenshotElement(IWebElement elm, string FileName)
        {
            ITakesScreenshot sselm = elm as ITakesScreenshot;
            Screenshot file = sselm.GetScreenshot();
            file.SaveAsFile(@"C:\Users\AfraazTiwana\Pictures\Saved Pictures\" + FileName + ".png", ScreenshotImageFormat.Png);
        }

        public static void WaitForElmStatic(IWebDriver driver, int Seconds, By locator)
        {
            WebDriverWait myWait = new WebDriverWait(driver, TimeSpan.FromSeconds(Seconds));
            myWait.Until(drv => drv.FindElement(locator).Displayed);
        }
    }
}
