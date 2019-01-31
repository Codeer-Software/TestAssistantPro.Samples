using System.Diagnostics;
using System.IO;
using Codeer.Friendly.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Driver.DemoApp;
using System;

namespace Scenario
{
	[TestClass]
	public class Test
	{
		WindowsAppFriend _app;

		[TestInitialize]
		public void TestInitialize()
		{
			var path = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "../../../DemoApp/bin/Debug/DemoApp.exe"));
			var info = new ProcessStartInfo(path) { WorkingDirectory = Path.GetDirectoryName(path) };
			_app = new WindowsAppFriend(Process.Start(info));
		}

		[TestCleanup]
		public void TestCleanup() => Process.GetProcessById(_app.ProcessId).Kill();

		[TestMethod]
		public void CaptureDemo()
		{

		}
	}
}
