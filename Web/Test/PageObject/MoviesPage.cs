using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;

namespace PageObject
{
    public class MoviesPage : PageBase
    {
        public AnchorDriver to_home => ById("to-home");
        public AnchorDriver to_movies => ById("to-movies");
        public AnchorDriver to_movies0 => ById("to-movies");
        public AnchorDriver to_create => ById("to-create");
        public ItemsControlDriver<MovieItem> tbody => ByXPath("//table[@id='movies-table']/tbody");

        public MoviesPage(IWebDriver driver) : base(driver) { }
    }

    public static class MoviesPageExtensions
    {
        //TODO これはデモ映え良くない。同じページは同じURLにしてください。

        [PageObjectIdentify("Movies/Index", UrlComapreType.EndsWith)]
        public static MoviesPage AttachMoviesPageIndex(this IWebDriver driver) => new MoviesPage(driver);

        [PageObjectIdentify("Movies", UrlComapreType.EndsWith)]
        public static MoviesPage AttachMoviesPage(this IWebDriver driver) => new MoviesPage(driver);
    }
}