using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;

namespace PageObject
{
    public class AllControlsPage : PageBase
    {
        public AnchorDriver to_home => ById("to-home");
        public AnchorDriver to_movies => ById("to-movies");
        public AnchorDriver to_movies0 => ById("to-movies");
        public TextBoxDriver textBoxName => ById("textBoxName");
        public RadioButtonDriver radioMan => ById("radioMan");
        public RadioButtonDriver radioWoman => ById("radioWoman");
        public CheckBoxDriver checkBoxCellPhone => ById("checkBoxCellPhone");
        public CheckBoxDriver checkBoxCar => ById("checkBoxCar");
        public CheckBoxDriver checkBoxCottage => ById("checkBoxCottage");
        public DropDownListDriver dropDownFruit => ById("dropDownFruit");
        public TextAreaDriver textareaFreeans => ById("textareaFreeans");
        public ButtonDriver inputJS => ById("inputJS");

        public AllControlsPage(IWebDriver driver) : base(driver) { }
    }

    public static class PageObjectExtensions
    {
        [PageObjectIdentify("AllControls", UrlComapreType.Contains)]
        public static AllControlsPage AttachPageObject(this IWebDriver driver) => new AllControlsPage(driver);
    }
}