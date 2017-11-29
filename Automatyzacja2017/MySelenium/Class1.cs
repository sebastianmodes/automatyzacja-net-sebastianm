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
        private const string PageTitle = "Code Sprinters -";
        private const string TextToSearch = "codesprinters";
        private const string SearchLinkText = "Poznaj nasze podejście";
        private const string CookiePopUpAccept = "Akceptuję";
        private const string AssertTextIsPresent = "WIEDZA NA PIERWSZYM MIEJSCU";

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        //private bool acceptNextAlert = true;

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
            Search(TextToSearch);
            GoToSearchResultByPageTitle(PageTitle);                 
            AcceptCookiePopup(CookiePopUpAccept);
            OpenNextPage(SearchLinkText);
            AssertPageContains(AssertTextIsPresent);

        }

        private void AssertPageContains(string SearchedText)
        {
            Assert.Contains(SearchedText, driver.PageSource);
        }

        private void OpenNextPage(string LinkText)
        {
            Assert.Single(GetElementsByLinkText(LinkText));
            waitForElementPresent(By.LinkText(LinkText), 5);
            driver.FindElement(By.LinkText(LinkText)).Click();
        }

        private void AcceptCookiePopup(string AcceptLinkText)
        {
            driver.FindElement(By.LinkText(AcceptLinkText)).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(11));
            wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.LinkText(AcceptLinkText), AcceptLinkText));
        }

        private System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> GetElementsByLinkText(string SearchLinkText)
        {
            return driver.FindElements(By.LinkText(SearchLinkText));
        }

        private void Search(string query)
        {
            IWebElement searchBox = GetSearchBox();
            searchBox.Clear();
            searchBox.SendKeys(query);
            searchBox.Submit();
        }

        private void GoToSearchResultByPageTitle(string title)
        {
            driver.FindElement(By.LinkText(title)).Click();
            Assert.Equal(PageTitle, driver.Title);
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