using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;

namespace PageObject
{
    public class MovieDetailPage : PageBase
    {
        public AnchorDriver to_home => ById("to-home");
        public AnchorDriver to_movies => ById("to-movies");
        public AnchorDriver to_movies0 => ById("to-movies");
        public IWebElement movie_title => ByName("movie-title").Find();
        public IWebElement movie_releasedate => ByName("movie-releasedate").Find();
        public IWebElement movie_genre => ByName("movie-genre").Find();
        public IWebElement movie_price => ByName("movie-price").Find();
        public AnchorDriver to_edit => ById("to-edit");
        public AnchorDriver to_index => ById("to-index");

        public MovieDetailPage(IWebDriver driver) : base(driver) { }
    }

    public static class MovieDetailPageExtensions
    {
        [PageObjectIdentify("/Movies/Details?", UrlComapreType.Contains)]
        public static MovieDetailPage AttachMovieDetailPage(this IWebDriver driver) => new MovieDetailPage(driver);
    }
}