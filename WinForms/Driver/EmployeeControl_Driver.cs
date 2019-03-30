using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;

namespace Driver
{
    [UserControlDriver(TypeFullName = "DemoApp.EmployeeControl")]
    public class EmployeeControl_Driver
    {
        public WindowControl Core { get; }
        public FormsDataGridView _grid => new FormsDataGridView(Core.Dynamic()._grid);

        public EmployeeControl_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class EmployeeControl_Driver_Extensions
    {
        [UserControlDriverIdentify]
        public static EmployeeControl_Driver Attach_EmployeeControl(this Demo_Driver window)
            => new EmployeeControl_Driver(new WindowControl(window.Core.IdentifyFromTypeFullName("DemoApp.EmployeeControl")));
    }
}