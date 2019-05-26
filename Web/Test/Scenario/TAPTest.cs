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
        public void TestScenario()
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

        [TestCase]
        public void TestAll()
        {
            //TODO Controlsへ行くところ id が間違ってる。重複。
            _driver.Url = "http://testassistantpro-demo.azurewebsites.net/AllControls";
            var allControlsPage = _driver.AttachPageObject();
            allControlsPage.textBoxName.Edit("abc");
            allControlsPage.radioWoman.Edit();
            allControlsPage.checkBoxCellPhone.Edit(true);
            allControlsPage.checkBoxCar.Edit(true);
            allControlsPage.checkBoxCottage.Edit(false);
            allControlsPage.dropDownFruit.Edit("Banana");
            allControlsPage.textareaFreeans.Edit("aaa");
            allControlsPage.inputJS.Invoke();
        }
    }
}
