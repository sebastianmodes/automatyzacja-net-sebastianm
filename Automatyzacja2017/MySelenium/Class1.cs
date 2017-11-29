using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;
using System.Threading;

namespace SeleniumTests
{
    public class Example : IDisposable
    {
        private const string SearchTextBox = "lst-ib";
        private const string Google = "https://google.pl";

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;

        public Example()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();            
            verificationErrors = new StringBuilder();
        }



        [Fact]
        public void TheExampleTest()
        {
            GoToGoogle();
            IWebElement searchBox = GetSearchBox();

            searchBox.Clear();
            searchBox.SendKeys("codesprinters");
            searchBox.Submit();
            driver.FindElement(By.LinkText("Code Sprinters -")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=@color | ]]
            Assert.Equal("Code Sprinters -", driver.Title);

            var element = driver.FindElement(By.PartialLinkText("Poznaj nasze podejście"));
            Assert.NotNull(element);

            var elements = driver.FindElements(By.LinkText("Poznaj nasze podejście"));
            Assert.Single(elements);

            driver.FindElement(By.LinkText("Akceptuję")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(11));
            wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.LinkText("Akceptuję"), "Akceptuję"));

            waitForElementPresent(By.LinkText("Poznaj nasze podejście"), 5);

            driver.FindElement(By.LinkText("Poznaj nasze podejście")).Click();

            //ver1
            Assert.Contains("WIEDZA NA PIERWSZYM MIEJSCU", driver.PageSource);

        }

        private IWebElement GetSearchBox()
        {
            return driver.FindElement(By.Id(SearchTextBox));
        }

        private void GoToGoogle()
        {
            driver.Navigate().GoToUrl(Google);
        }

        protected void waitForElementPresent(By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        protected void waitForElementPresent(IWebElement by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
        //private bool IsElementPresent(By by)
        //{
        //    try
        //    {
        //        driver.FindElement(by);
        //        return true;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;
        //    }
        //}

        //private bool IsAlertPresent()
        //{
        //    try
        //    {
        //        driver.SwitchTo().Alert();
        //        return true;
        //    }
        //    catch (NoAlertPresentException)
        //    {
        //        return false;
        //    }
        //}

        //private string CloseAlertAndGetItsText()
        //{
        //    try
        //    {
        //        IAlert alert = driver.SwitchTo().Alert();
        //        string alertText = alert.Text;
        //        if (acceptNextAlert)
        //        {
        //            alert.Accept();
        //        }
        //        else
        //        {
        //            alert.Dismiss();
        //        }
        //        return alertText;
        //    }
        //    finally
        //    {
        //        acceptNextAlert = true;
        //    }
        //}

        public void Dispose()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.Equal("", verificationErrors.ToString());
        }
    }
}