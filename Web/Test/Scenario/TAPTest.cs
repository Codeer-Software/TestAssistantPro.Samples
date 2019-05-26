using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject;

namespace Scenario
{
    public class TAPTest
    {
        IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "http://testassistantpro-demo.azurewebsites.net/";
        }

        [TearDown]
        public void TearDown() => _driver.Dispose();

        [TestCase]
        public void Test()
        {
            var topPage = _driver.AttachTopPage();
            topPage.to_demo.Invoke();

            var moviesPage = _driver.AttachMoviesPageIndex();
            moviesPage.tbody.GetItem(1).movie_to_details.Invoke();

            var movieDetailPage = _driver.AttachMovieDetailPage();
            movieDetailPage.to_edit.Invoke();

            var movieEditPage = _driver.AttachMovieEditPage();
            movieEditPage.movie_title.Edit("映画１xx");
            movieEditPage.movie_releasedate.Edit(2019, 06, 19);
            movieEditPage.movie_genre.Edit("SF");
            movieEditPage.movie_price.Edit("2000");
            movieEditPage.to_save.Invoke();
        }
    }
}
