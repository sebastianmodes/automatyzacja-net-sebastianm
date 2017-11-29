using System;
using System.Linq;

namespace PageObjectTests
{
    internal class NotePage
    {
        internal static void AddComment(Comment testData)
        {
            var commentBox = Browser.FindElementById("comment");
            commentBox.Click();
            commentBox.SendKeys(testData.Text);

            var email = Browser.FindElementById("email");
            email.Click();
            email.SendKeys(testData.Mail);

            var nameLabel = Browser.FindByXpath("//label[@for='author']");
            nameLabel.First().Click();
            nameLabel.First().SendKeys(testData.User);

            var name = Browser.FindElementById("author");
            name.Click();
            name.SendKeys(testData.User);

            var submit = Browser.FindElementById("comment-submit");
            submit.Click();
        }
    }
}