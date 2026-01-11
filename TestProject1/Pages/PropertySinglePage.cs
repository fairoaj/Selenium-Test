using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace TestProject1.Pages
{
    public class PropertySinglePage
    {
        private readonly IWebDriver driver;

        public PropertySinglePage(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void OpenAccordionIfNotExpanded(By accordionLocator)
        {
            var accordion = driver.FindElement(accordionLocator);
            string classAttribute = accordion.GetAttribute("class");

            if (!classAttribute.Contains("in"))
            {
                // Find the accordion toggle (usually the heading/title/button)
                // my doubt => why cannot use "accordionLocator" for expand section
                var toggleButton = accordion.FindElement(By.XPath("./preceding-sibling::*[1]"));
                toggleButton.Click();
                //accordion.Click(); => why cannot use this?
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(d => accordion.GetAttribute("class").Contains("in"));
            }
        }


        public void ClickTab(string tabText)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var locator = By.XPath($"//ul[@class='option-list']//a[normalize-space()='{tabText}']");
            var tab = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            try
            {
                tab.Click();
            }
            catch
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", tab);
            }
        }


        //public void ClickTab(By locator)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    var element = wait.Until(exp)
        //    driver.FindElement(locator).Click();
        //}

        public void OpenSectionAndClickTab(By accordionLocator, string tabText)
        {
            OpenAccordionIfNotExpanded(accordionLocator);
            ClickTab(tabText);
        }
    }
}
