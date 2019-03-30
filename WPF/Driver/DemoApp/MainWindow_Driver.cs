using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;

namespace Driver.DemoApp
{
    [WindowDriver(TypeFullName = "DemoApp.Views.MainWindow")]
    public class MainWindow_Driver
    {
        public WindowControl Core { get; }
        public WPFButtonBase Button => new WPFButtonBase(Core.VisualTree().ByBinding("Minimize").Single());
        public WPFButtonBase Button0 => new WPFButtonBase(Core.VisualTree().ByBinding("Maximize").Single());
        public WPFButtonBase Button1 => new WPFButtonBase(Core.VisualTree().ByBinding("Close").Single());
        public WPFMenuBase Menu => new WPFMenuBase(Core.LogicalTree().ByType("System.Windows.Controls.Menu").Single());

        public MainWindow_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class MainWindow_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "DemoApp.Views.MainWindow")]
        public static MainWindow_Driver Attach_MainWindow(this WindowsAppFriend app)
            => new MainWindow_Driver(app.WaitForIdentifyFromTypeFullName("DemoApp.Views.MainWindow"));
    }
}