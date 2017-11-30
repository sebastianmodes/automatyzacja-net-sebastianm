﻿using System;
using System.Linq;
using Xunit;

namespace PageObjectTests
{
    internal class NotePage
    {
        internal static void AddComment(Comment testData)
        {
            var commentBox = Browser.FindElementById("comment");
            commentBox.Click();
            commentBox.SendKeys(testData.Text);

            var emailLabel = Browser.FindByXpath("//label[@for='email']").First();
            emailLabel.Click();


            var email = Browser.FindElementById("email");
            email.Click();
            email.SendKeys(testData.Mail);

            var nameLabel = Browser.FindByXpath("//label[@for='author']").First();
            nameLabel.Click();

            var name = Browser.FindElementById("author");
            name.SendKeys(testData.User);

            var submit = Browser.FindElementById("comment-submit");
            submit.Click();
        }
        public static void AssertCommentText(Comment comment)
        {
            Assert.Contains(comment.Text, Browser.ReturnPageSource());
        }
    }
}