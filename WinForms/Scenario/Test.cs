using System.Diagnostics;
using Codeer.Friendly.Windows;
using Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scenario
{
	[TestClass]
    public class Test
    {
        WindowsAppFriend _app;

        [TestInitialize]
        public void TestInitialize() => _app = ProcessController.Start();

        [TestCleanup]
        public void TestCleanup() => Process.GetProcessById(_app.ProcessId).Kill();

        [TestMethod]
        public void CaptureTest()
        {

        }
    }
}

