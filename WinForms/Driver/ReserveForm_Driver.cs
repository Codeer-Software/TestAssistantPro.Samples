using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;

namespace Driver
{
    [WindowDriver(TypeFullName = "DemoApp.ReserveForm")]
    public class ReserveForm_Driver
    {
        public WindowControl Core { get; }
        public FormsTextBox _textBoxName => new FormsTextBox(Core.Dynamic()._textBoxName);
        public FormsTextBox _textBoxCount => new FormsTextBox(Core.Dynamic()._textBoxCount);
        public FormsMonthCalendar _date => new FormsMonthCalendar(Core.Dynamic()._date);
        public FormsTextBox _textBoxTime => new FormsTextBox(Core.Dynamic()._textBoxTime);
        public FormsButton _buttonOK => new FormsButton(Core.Dynamic()._buttonOK);
        public FormsCheckBox _checkBoxNonSmoke => new FormsCheckBox(Core.Dynamic()._checkBoxNonSmoke);

        public ReserveForm_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class ReserveForm_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "DemoApp.ReserveForm")]
        public static ReserveForm_Driver Attach_ReserveForm(this WindowsAppFriend app)
            => new ReserveForm_Driver(app.WaitForIdentifyFromTypeFullName("DemoApp.ReserveForm"));
    }
}