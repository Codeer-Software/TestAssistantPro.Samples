using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;
using System.Windows.Controls;

namespace Driver
{
    [UserControlDriver(TypeFullName = "DemoApp.Views.AllDisplayControl")]
    public class AllDisplayControl_Driver
    {
        public WPFUserControl Core { get; }
        public WPFTextBox TextBox => new WPFTextBox(Core.LogicalTree().ByBinding("NameSearch.Value").Single());
        public WPFComboBox ComboBox => new WPFComboBox(Core.LogicalTree().ByBinding("LanguageSearch.Value").Single());
        public WPFButtonBase Button => new WPFButtonBase(Core.LogicalTree().ByType<ContentControl>().ByContentText("Search").Single());
        public WPFButtonBase Button0 => new WPFButtonBase(Core.LogicalTree().ByType<ContentControl>().ByContentText("Add").Single());
        public WPFButtonBase Button1 => new WPFButtonBase(Core.LogicalTree().ByType<ContentControl>().ByContentText("Delete").Single());
        public WPFDataGrid DataGrid => new WPFDataGrid(Core.LogicalTree().ByBinding("SelectedItem.Value").Single());

        public AllDisplayControl_Driver(AppVar core)
        {
            Core = new WPFUserControl(core);
        }
    }

    public static class AllDisplayControl_Driver_Extensions
    {
        [UserControlDriverIdentify]
        public static AllDisplayControl_Driver Attach_AllDisplayControl(this MainWindow_Driver window)
            => new AllDisplayControl_Driver(window.Core.VisualTree().ByType("DemoApp.Views.AllDisplayControl").Single());
    }
}