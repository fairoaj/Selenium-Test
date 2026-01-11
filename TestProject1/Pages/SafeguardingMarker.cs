using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class SafeguardingMarker
    {
        private readonly IWebDriver driver;
        

        public SafeguardingMarker(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement add => driver.FindElement(By.XPath("//button[contains(@class, 'jq-safe-guarding-add-btn-Id')]"));
        IWebElement edit => driver.FindElement(By.Id(""));
        IWebElement delete => driver.FindElement(By.Id(""));

        public void AddNewRecord()
        {

            // Click the Add button
            driver.FindElement(By.XPath("//button[contains(@class, 'jq-safe-guarding-add-btn-Id')]")).Click();

            // Find the modal dialog (assumes it's immediately in the DOM and visible)
            var modal = driver.FindElement(By.CssSelector(".modal-dialog"));

            // Open dropdown
            new WebDriverWait(driver, TimeSpan.FromSeconds(15))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementToBeClickable(By.XPath("//button[contains(@data-id,'Details_TypeId')]"))).Click();

            // Select 3rd option
            new WebDriverWait(driver, TimeSpan.FromSeconds(15))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementToBeClickable(By.XPath("//span[normalize-space()='Adult - Mental Health']")))
                .Click();


            // Find the textarea inside the modal
            new WebDriverWait(driver, TimeSpan.FromSeconds(15))
           .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
               By.Id("Details_PublicInfo")))
           .SendKeys("Public Test");

            new WebDriverWait(driver, TimeSpan.FromSeconds(15))
           .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
               By.Id("Details_Notes")))
           .SendKeys("Private Test");

            //Using the "for" attribute which links to input's id
            driver.FindElement(By.CssSelector("label[for='Details_RiskToStaff']")).Click();

            // new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions
            //.ElementToBeClickable(By.CssSelector("button.jq-modal-submit"))).Click();


            //var addButton = driver.FindElement(By.CssSelector(".modal-footer .jq-modal-submit"));
            ((IJavaScriptExecutor)driver).ExecuteScript("$('.jq-modal-submit').trigger('click');");






        }

    }
}
