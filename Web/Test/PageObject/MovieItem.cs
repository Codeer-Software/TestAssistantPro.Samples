using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;

namespace PageObject
{
    public class MovieItem : ComponentBase
    {
        public IWebElement movie_title => ByName("movie-title").Find();
        public IWebElement movie_releasedate => ByName("movie-releasedate").Find();
        public IWebElement movie_genre => ByName("movie-genre").Find();
        public IWebElement movie_price => ByName("movie-price").Find();
        public AnchorDriver movie_to_edit => ByName("movie-to-edit");
        public AnchorDriver movie_to_details => ByName("movie-to-details");
        public AnchorDriver movie_to_delete => ByName("movie-to-delete");

        public MovieItem(IWebElement element) : base(element) { }
    }
}