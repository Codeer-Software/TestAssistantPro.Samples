using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;

namespace Driver
{
    [UserControlDriver(TypeFullName = "DemoApp.ScheduleControl")]
    public class ScheduleControl_Driver
    {
        public WindowControl Core { get; }
        public FormsListBox _lsit => new FormsListBox(Core.Dynamic()._lsit);
        public FormsButton _buttonAdd => new FormsButton(Core.Dynamic()._buttonAdd);

        public ScheduleControl_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class ScheduleControl_Driver_Extensions
    {
        [UserControlDriverIdentify]
        public static ScheduleControl_Driver Attach_ScheduleControl(this Demo_Driver window)
            => new ScheduleControl_Driver(new WindowControl(window.Core.IdentifyFromTypeFullName("DemoApp.ScheduleControl")));
    }
}