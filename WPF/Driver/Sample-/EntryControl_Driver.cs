using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;
using System.Windows.Controls;

namespace Driver.Sample
{
    [UserControlDriver(TypeFullName = "WpfApplication.EntryControl")]
    public class EntryControl_Driver
    {
        public WPFUserControl Core { get; }
        public WPFTextBox TextBox_名前 => new WPFTextBox(Core.Dynamic()._textBoxName);
        public WPFTextBox TextBox_メールアドレス => new WPFTextBox(Core.LogicalTree().ByBinding("Mail.Value").Single());
        public WPFComboBox ComboBox_言語 => new WPFComboBox(Core.LogicalTree().ByBinding("Language.Value").Single());
        public WPFToggleButton Radio_男性 => new WPFToggleButton(Core.LogicalTree().ByType<ContentControl>().ByContentText("男性").Single());
        public WPFToggleButton Radio_女性 => new WPFToggleButton(Core.LogicalTree().ByType<ContentControl>().ByContentText("女性").Single());
        public WPFCalendar Calendar => new WPFCalendar(Core.LogicalTree().ByBinding("BirthDay.Value").Single());
        public WPFButtonBase Button_登録 => new WPFButtonBase(Core.LogicalTree().ByType<ContentControl>().ByContentText("登録").Single());

        public EntryControl_Driver(AppVar core)
        {
            Core = new WPFUserControl(core);
        }
    }

    public static class EntryControl_Driver_Extensions
    {
        [UserControlDriverIdentify]
        public static EntryControl_Driver Attach_EntryControl(this MainWindow_Driver window)
            => new EntryControl_Driver(window.Core.IdentifyFromTypeFullName("WpfApplication.EntryControl"));
    }
}