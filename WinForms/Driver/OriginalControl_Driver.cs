using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Driver;
using Ong.Friendly.FormsStandardControls;

namespace Driver
{
    [UserControlDriver(TypeFullName = "DemoApp.OriginalControl")]
    public class OriginalControl_Driver
    {
        public WindowControl Core { get; }
        public BlockControlDriver _blockControl => new BlockControlDriver(Core.Dynamic()._blockControl);
        public FormsButton _buttonAdd => new FormsButton(Core.Dynamic()._buttonAdd);

        public OriginalControl_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class OriginalControl_Driver_Extensions
    {
        [UserControlDriverIdentify]
        public static OriginalControl_Driver Attach_OriginalControl(this Demo_Driver window)
            => new OriginalControl_Driver(new WindowControl(window.Core.IdentifyFromTypeFullName("DemoApp.OriginalControl")));
    }
}