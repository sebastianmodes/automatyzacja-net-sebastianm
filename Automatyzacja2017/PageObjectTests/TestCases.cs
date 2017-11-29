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
