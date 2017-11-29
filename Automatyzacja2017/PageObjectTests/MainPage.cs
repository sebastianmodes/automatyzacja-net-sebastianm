using System;

namespace PageObjectTests
{
    internal class MainPage
    {
        private static string url = "https://autotestdotnet.wordpress.com/";

        internal static void GoTo()
        {
            Browser.NavigateTo(url);
        }
    }
}