using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;
using System.Windows.Controls;
using Driver.CustomDrivers;

namespace Driver.DemoApp
{
    [UserControlDriver(TypeFullName = "DemoApp.Views.EntryControl")]
    public class EntryControl_Driver
    {
        public WPFUserControl Core { get; }
        public WPFTextBox Name => new WPFTextBox(Core.Dynamic()._textBoxName);
        public WPFTextBox email => new WPFTextBox(Core.LogicalTree().ByBinding("Mail.Value").Single());
        public WPFComboBox Preferredlanguage => new WPFComboBox(Core.LogicalTree().ByBinding("Language.Value").Single());
        public WPFToggleButton Man => new WPFToggleButton(Core.LogicalTree().ByType<ContentControl>().ByContentText("Man").Single());
        public WPFToggleButton Woman => new WPFToggleButton(Core.LogicalTree().ByType<ContentControl>().ByContentText("Woman").Single());
        public WPFCalendar Birthday => new WPFCalendar(Core.LogicalTree().ByBinding("BirthDay.Value").Single());
        public WPFNumericUpDownDriver Age => new WPFNumericUpDownDriver(Core.LogicalTree().ByBinding("Age.Value").Single());
        public WPFButtonBase Entry => new WPFButtonBase(Core.LogicalTree().ByType<ContentControl>().ByContentText("Entry").Single());
        public WPFButtonBase Cancel => new WPFButtonBase(Core.LogicalTree().ByType<ContentControl>().ByContentText("Cancel").Single());

        public EntryControl_Driver(AppVar core)
        {
            Core = new WPFUserControl(core);
        }
    }

    public static class EntryControl_Driver_Extensions
    {
        [UserControlDriverIdentify]
        public static EntryControl_Driver Attach_EntryControl(this MainWindow_Driver window)
            => new EntryControl_Driver(window.Core.VisualTree().ByType("DemoApp.Views.EntryControl").Single());
    }
}