using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class SeleniumCustomMethod
    {

        public static void click(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Click();
        }

        public static void EnterText(IWebDriver driver, By locator, string text)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }

        public static void ClickWhenClickable(IWebDriver driver, By locator, int timeout = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));

            element.Click();
        }

    }
}
