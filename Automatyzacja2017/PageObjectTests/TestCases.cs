using System;
using Xunit;

namespace PageObjectTests
{
    public class TestCases : IDisposable
    {
        [Fact]
        public void CanAddCommentToTheBlogNote()
        {
            MainPage.GoTo();
            MainPage.OpenFirstNote();
            var comment = new Comment
            {
                Text = Guid.NewGuid().ToString(),
                Mail = "test@test.com",
                User = "białko"
            };
            NotePage.AddComment(comment);
            NotePage.AssertCommentText(comment);

            //wejdź na strone bloga
            //otwórz pierwszą notkę
            //dodaj komentarz
            //sprawdź że komentarz się dodał
        }

        [Fact]
        public void ReplyToComment()
        {
            MainPage.GoTo();
            MainPage.OpenFirstNote();
            var comment = new Comment
            {
                Text = Guid.NewGuid().ToString(),
                Mail = "test@test.com",
                User = "białko"
            };
            NotePage.AddComment(comment);
            NotePage.AssertCommentText(comment);

            //wejdź na strone bloga
            //otwórz pierwszą notkę
            //dodaj komentarz
            //sprawdź że komentarz się dodał
        }

        [Fact]
        public void WordPressPublish()
        {
            var pdata = new PostData
            {
                Title = Guid.NewGuid().ToString(),
                Post = "test@test.com"             
            };
            Wordpresslogin.GoTo();
            Wordpresslogin.LogIn();
            WPadmin.AddPost(pdata);
            WPadmin.DeletePost();
        }


        public void Dispose()
        {
            Browser.Close();
        }
    }
}
