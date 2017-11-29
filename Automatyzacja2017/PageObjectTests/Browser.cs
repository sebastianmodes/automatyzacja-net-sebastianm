using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace PageObjectTests
{
    internal class Browser
    {
        private static IWebDriver driver;

        static Browser()
        {
            driver = new ChromeDriver();
        }

        internal static void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        internal static void Close()
        {
            driver.Quit();
        }
    }
}