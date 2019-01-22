using System.Diagnostics;
using System.IO;
using Codeer.Friendly.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Codeer.Friendly;
using Driver;
using System.Windows;
using Codeer.Friendly.Dynamic;

namespace Scenario
{
    [TestClass]
    public class Test
    {
        WindowsAppFriend _app;

        [TestInitialize]
        public void TestInitialize()
        {
            var path = Path.GetFullPath(@"todo");
            var info = new ProcessStartInfo(path) { WorkingDirectory = Path.GetDirectoryName(path) };
            _app = new WindowsAppFriend(Process.Start(info));
        }

        [TestCleanup]
        public void TestCleanup() => Process.GetProcessById(_app.ProcessId).Kill();

        [TestMethod]
        public void FriendlyDemo()
        {
            _app.Type<Application>().Current.MainWindow.Title = "ABC";
        }

        [TestMethod]
        public void CaptureDemo()
        {

        }
    }
}
