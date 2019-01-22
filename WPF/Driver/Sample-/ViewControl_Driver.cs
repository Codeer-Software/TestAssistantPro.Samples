using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;
using System.Windows.Controls;
using Driver.InTarget;
using FontAwesome.WPF;

namespace Driver.Sample
{
    [UserControlDriver(TypeFullName = "WpfApplication.ViewControl")]
    public class ViewControl_Driver
    {
        public WPFUserControl Core { get; }
        public WPFTextBox TextBox_名前=> new WPFTextBox(Core.LogicalTree().ByBinding("NameSearch.Value").Single());
        public WPFComboBox ComboBox_言語 => new WPFComboBox(Core.LogicalTree().ByBinding("LanguageSearch.Value").Single());
        public WPFButtonBase Button_検索 => new WPFButtonBase(Core.App.Type<Finder>().FindButton(Core, FontAwesomeIcon.Search));
        public WPFButtonBase Button_削除 => new WPFButtonBase(Core.App.Type<Finder>().FindButton(Core, FontAwesomeIcon.Eraser));
        public WPFDataGrid Grid => new WPFDataGrid(Core.LogicalTree().ByBinding("SelectedItem.Value").Single());

        public ViewControl_Driver(AppVar core)
        {
            Core = new WPFUserControl(core);
            WPFStandardControls_4.Injection(Core.App);
            Core.App.LoadAssembly(typeof(Finder).Assembly);
        }
    }

    public static class ViewControl_Driver_Extensions
    {
        [UserControlDriverIdentify]
        public static ViewControl_Driver Attach_ViewControl(this MainWindow_Driver window)
            => new ViewControl_Driver(window.Core.IdentifyFromTypeFullName("WpfApplication.ViewControl"));
    }
}