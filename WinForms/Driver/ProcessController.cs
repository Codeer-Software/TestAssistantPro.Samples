using Codeer.Friendly.Windows;
using System.Diagnostics;
using System.IO;

namespace Driver
{
    public static class ProcessController
    {
        public static WindowsAppFriend Start()
        {
            var path = Path.GetFullPath(@"..\..\..\DemoApp\bin\Debug\DemoApp.exe");
            var info = new ProcessStartInfo(path) { WorkingDirectory = Path.GetDirectoryName(path) };
            return new WindowsAppFriend(Process.Start(info));
        }
    }
}
