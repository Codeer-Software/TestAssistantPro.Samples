using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;

namespace Driver.Sample
{
    [WindowDriver(TypeFullName = "WpfApplication.MainWindow")]
    public class MainWindow_Driver
    {
        public WindowControl Core { get; }
        public WPFButtonBase ButtonMin => new WPFButtonBase(Core.VisualTree().ByBinding("Minimize").Single());
        public WPFButtonBase ButtonMax => new WPFButtonBase(Core.VisualTree().ByBinding("Maximize").Single());
        public WPFButtonBase ButtonClose => new WPFButtonBase(Core.VisualTree().ByBinding("Close").Single());
        public WPFMenuBase Menu => new WPFMenuBase(Core.LogicalTree().ByType("System.Windows.Controls.Menu").Single());
        public WPFTabControl Tab => new WPFTabControl(Core.LogicalTree().ByType("System.Windows.Controls.TabControl").Single());

        public MainWindow_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class MainWindow_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "WpfApplication.MainWindow")]
        public static MainWindow_Driver Attach_MainWindow(this WindowsAppFriend app)
            => new MainWindow_Driver(app.WaitForIdentifyFromTypeFullName("WpfApplication.MainWindow"));
    }
}