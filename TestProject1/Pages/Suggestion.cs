using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{

    public class Suggestion
    {

        private readonly IWebDriver driver;

        public Suggestion(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickSuggestion(string text)
        {
            driver.FindElement(By.Id("jq-nacc-top-bar-search-input-answer-field-Id")).SendKeys(text);

            // Wait until suggestions list is visible
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.FindElement(By.Id("ui-id-2")).Displayed);

            // Now get all suggestion items
            var suggestions = driver.FindElements(By.CssSelector("#ui-id-2 li.d-flex.ui-menu-item"));

            // Loop through and click the matching suggestion
            foreach (var suggestion in suggestions)
            {
                if (suggestion.Text.Contains(text, StringComparison.OrdinalIgnoreCase))
                {
                    suggestion.Click();
                    break;
                }
            }


        }



    }
}
