using System;
using Xunit;

namespace PageObjectTests
{
    public class AddingBlogCommentsTests : IDisposable
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



        public void Dispose()
        {
            Browser.Close();
        }
    }
}
