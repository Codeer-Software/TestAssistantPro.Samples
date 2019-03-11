using Codeer.Friendly.Windows;
using System.Diagnostics;
using System.IO;

namespace Driver
{
    public static class ProcessController
    {
        public static WindowsAppFriend Start()
        {
            //target path
            var path = @"";
            var info = new ProcessStartInfo(path) { WorkingDirectory = Path.GetDirectoryName(path) };
            return new WindowsAppFriend(Process.Start(info));
        }
    }
}
