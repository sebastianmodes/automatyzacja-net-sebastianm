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
            NotePage.AddComment(new Comment
            {
                Text = "Lorem ipsum dolor sit",
                Mail = "test@test.com",
                User = "białko"
            });
            
      
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
