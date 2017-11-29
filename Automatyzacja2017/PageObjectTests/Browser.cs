using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            driver = new ChromeDriver();
        }

        internal static ReadOnlyCollection<IWebElement> FindByXpath(string xpath)
        {
            return driver.FindElements(By.XPath(xpath));
        }

        internal static void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        internal static void WaitForInvisible(By by)
        {
            new WebDriverWait(driver, TimeSpan);
        }

        internal static void Close()
        {
            driver.Quit();
        }
    }
}