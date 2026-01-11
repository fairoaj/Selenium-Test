using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver) { 
            this.driver = driver;
        }

        IWebElement userName => driver.FindElement(By.Name("Email"));
        IWebElement password => driver.FindElement(By.Name("Password"));
        IWebElement loginBtn => driver.FindElement(By.CssSelector("button[type='submit']"));

        public void ClickLogin() {
            userName.SendKeys("Waseem");
            password.SendKeys("Welcome@123456");
            loginBtn.Click();
        }
    }
}
