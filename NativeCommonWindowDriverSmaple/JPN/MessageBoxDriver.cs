using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows.NativeStandardControls;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Driver
{
    public class MessageBoxDriver
    {
        public WindowControl Core { get; }

        public MessageBoxDriver(WindowControl core) => Core = core;
        public string Message => Core.IdentifyFromWindowClass("Static").GetWindowText();
        public NativeButton Button_はい => new NativeButton(Core.IdentifyFromWindowText("はい(&Y)"));
        public NativeButton Button_いいえ => new NativeButton(Core.IdentifyFromWindowText("いいえ(&N)"));
        public NativeButton Button_OK => new NativeButton(Core.IdentifyFromWindowText("OK"));
        public NativeButton Button_キャンセル => new NativeButton(Core.IdentifyFromWindowText("キャンセル"));
	}

    public static class MessageBoxDriverExtensions
    {
        [WindowDriverIdentify(CustomMethod = "TryAttach")]
        public static MessageBoxDriver Attach_MessageBox(this WindowsAppFriend app, string title)
            => new MessageBoxDriver(app.WaitForIdentifyFromWindowText(title));
       
        public static bool TryAttach(WindowControl window, out string title)
        {
            title = null;
            if (window.AppVar != null) return false;
            if (window.GetFromWindowClass("Static").Length != 1) return false;
            var buttons = window.GetFromWindowClass("Static");
            if (buttons.Length == 0 || 3 < buttons.Length) return false;
            title = window.GetWindowText();
            return true;
        }
    }
}