using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace PageObjectTests
{
    internal class Browser
    {
        private static IWebDriver driver;

        internal static IWebElement FindElementById(string id)
        {
            return driver.FindElement(By.Id(id));
        }

        static Browser()
        {
            driver = new FirefoxDriver();
        }

        internal static ReadOnlyCollection<IWebElement> FindByXpath(string xpath)
        {
            return driver.FindElements(By.XPath(xpath));
        }

        internal static void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        
        internal static string ReturnPageSource()
        {
            string pagesource = driver.PageSource;
            return pagesource;
        }

        internal static void WaitForElementId(string id)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(id)));
        }

        internal static void WaitForElementXpath(string xpath)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
        }


        //internal static void WaitForInvisible(By by)
        //{
        //    new WebDriverWait(driver, TimeSpan);
        //}

        internal static void Close()
        {
            driver.Quit();
        }
    }
}