using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Windows.Controls;
using RM.Friendly.WPFStandardControls;

namespace Driver.Sample
{
    [WindowDriver(TypeFullName = "WpfApplication.VersionWindow")]
    public class VersionWindow_Driver
    {
        public WindowControl Core { get; }
        public WPFButtonBase Button_Min => new WPFButtonBase(Core.VisualTree().ByBinding("Minimize").Single());
        public WPFButtonBase Button_Max => new WPFButtonBase(Core.VisualTree().ByBinding("Maximize").Single());
        public WPFButtonBase Button_Close => new WPFButtonBase(Core.VisualTree().ByBinding("Close").Single());
        public WPFButtonBase Button_閉じる => new WPFButtonBase(Core.LogicalTree().ByType<ContentControl>().ByContentText("閉じる").Single());

        public VersionWindow_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class VersionWindow_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "WpfApplication.VersionWindow")]
        public static VersionWindow_Driver Attach_VersionWindow(this WindowsAppFriend app)
            => new VersionWindow_Driver(app.WaitForIdentifyFromTypeFullName("WpfApplication.VersionWindow"));
    }
}