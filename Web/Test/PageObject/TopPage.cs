using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;

namespace PageObject
{
    public class TopPage : PageBase
    {
        public AnchorDriver to_home => ById("to-home");
        public AnchorDriver to_movies => ById("to-movies");
        public AnchorDriver to_movies0 => ById("to-movies");
        public ButtonDriver to_demo => ById("to-demo");

        public TopPage(IWebDriver driver) : base(driver) { }
    }

    public static class TopPageExtensions
    {
        [PageObjectIdentify("testassistantpro-demo.azurewebsites.net/", UrlComapreType.EndsWith)]
        public static TopPage AttachTopPage(this IWebDriver driver) => new TopPage(driver);
    }
}