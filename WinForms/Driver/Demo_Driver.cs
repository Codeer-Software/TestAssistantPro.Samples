using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;

namespace Driver
{
    [WindowDriver(TypeFullName = "DemoApp.Demo")]
    public class Demo_Driver
    {
        public WindowControl Core { get; }
        public FormsTabControl _tab => new FormsTabControl(Core.Dynamic()._tab);
        public EmployeeControl_Driver _employee => new EmployeeControl_Driver(new WindowControl(Core.Dynamic()._employee));
        public ScheduleControl_Driver _schedule => new ScheduleControl_Driver(new WindowControl(Core.Dynamic()._schedule));
        public AllControl_Driver _allControl => new AllControl_Driver(new WindowControl(Core.Dynamic()._allControl));
        public OriginalControl_Driver originalControl1 => new OriginalControl_Driver(new WindowControl(Core.Dynamic().originalControl1));

        public Demo_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class Demo_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "DemoApp.Demo")]
        public static Demo_Driver Attach_Demo(this WindowsAppFriend app)
            => new Demo_Driver(app.WaitForIdentifyFromTypeFullName("DemoApp.Demo"));
    }
}