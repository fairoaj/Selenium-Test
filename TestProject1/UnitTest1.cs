using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using TestProject1.Pages;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NpmsLogin()
        {
            // to fix crom driver version
            // This line automatically downloads the correct ChromeDriver version
            new DriverManager().SetUpDriver(new ChromeConfig());

            //create new instance of selenium web driver
            IWebDriver driver = new ChromeDriver();
            // navigate to the url
            driver.Navigate().GoToUrl("https://www.waterlilylabs.com:816/Account/Login");
            // maximize the window
            driver.Manage().Window.Maximize();
            //SeleniumCustomMethod.EnterText(driver, By.Name("Email"), "Waseem");
            //SeleniumCustomMethod.EnterText(driver, By.Name("Password"), "Welcome@123456");
            //SeleniumCustomMethod.click(driver, By.CssSelector("button[type='submit']"));

            LoginPage login = new LoginPage(driver);
            login.ClickLogin();

            // click profile button && clear history
            SeleniumCustomMethod.click(driver, By.CssSelector("a.user-profile-btn.dropdown-toggle"));
            Thread.Sleep(1000);
            SeleniumCustomMethod.click(driver, By.CssSelector("ul.dropdown-menu a[href='/Account/ClearHistory']"));
            // click profile button && clear history
            Thread.Sleep(1000);
            SeleniumCustomMethod.click(driver, By.CssSelector("a.user-profile-btn.dropdown-toggle"));
            Thread.Sleep(1000);
            SeleniumCustomMethod.click(driver, By.CssSelector("ul.dropdown-menu a[href='/Account/ClearHistory']"));
            Thread.Sleep(1000);

            // search property
            Suggestion propertySuggestion = new Suggestion(driver);
            propertySuggestion.ClickSuggestion("no-30");

            PropertySinglePage subTab = new PropertySinglePage(driver);
            subTab.OpenSectionAndClickTab(
                    By.Id("jq-property-single-page-booking-and-rental-category-tabs-body-id"),
                    "Safeguarding marker"
                    );
            Thread.Sleep(1000);
            SafeguardingMarker safeguarding = new SafeguardingMarker(driver);
            safeguarding.AddNewRecord();
        }

    }
}