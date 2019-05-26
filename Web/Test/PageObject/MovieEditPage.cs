using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;

namespace PageObject
{
    public class MovieEditPage : PageBase
    {
        public AnchorDriver to_home => ById("to-home");
        public AnchorDriver to_movies => ById("to-movies");
        public AnchorDriver to_movies0 => ById("to-movies");
        public TextBoxDriver movie_title => ById("movie-title");
        public TextBoxDriver movie_releasedate => ById("movie-releasedate");
        public TextBoxDriver movie_genre => ById("movie-genre");
        public TextBoxDriver movie_price => ById("movie-price");
        public ButtonDriver to_save => ById("to-save");
        public AnchorDriver to_index => ById("to-index");

        public MovieEditPage(IWebDriver driver) : base(driver) { }
    }

    public static class MovieEditPageExtensions
    {
        [PageObjectIdentify("/Movies/Edit", UrlComapreType.Contains)]
        public static MovieEditPage AttachMovieEditPage(this IWebDriver driver) => new MovieEditPage(driver);
    }
}