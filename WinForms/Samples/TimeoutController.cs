using Codeer.Friendly.DotNetExecutor;
using Codeer.Friendly.Windows;
using NUnit.Framework;
using System.Diagnostics;

namespace Driver
{
    static class TimeoutController
    {
        static TypeFinder _finder = new TypeFinder();
        static Process _killer;

        internal static void ResetTimeout(this WindowsAppFriend app)
        {
            app.ClearTimeout();

            var type = _finder.GetType(TestContext.CurrentContext.Test.ClassName);
            var method = type.GetMethod(TestContext.CurrentContext.Test.MethodName);
            var attrs = method.GetCustomAttributes(typeof(TimeoutExAttribute), true);
            if (attrs.Length == 1)
            {
                var timeout = (TimeoutExAttribute)attrs[0];
                var exe = typeof(Killer.Program).Assembly.Location;
                _killer = Process.Start(exe, app.ProcessId + " " + timeout.Time + " \"" + TestResult.MakeErrPngPath() + "\"");
            }
        }

        internal static void ClearTimeout(this WindowsAppFriend app)
        {
            if (_killer != null)
            {
                try
                {
                    _killer.Kill();
                }
                catch { }
                _killer = null;
            }
        }
    }
}
