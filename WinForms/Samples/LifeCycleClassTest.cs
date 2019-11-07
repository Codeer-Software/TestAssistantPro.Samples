using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Driver
{
    public static class LifeCycleClassTest
    {
        static WindowsAppFriend _app;
        static string _testName;

        public static WindowsAppFriend GetApp(Action<WindowsAppFriend> processStartAction = null)
        {
            var testName = TestContext.CurrentContext.Test.ClassName;
            if (_app != null)
            {
                bool exist = false;
                try
                {
                    exist = Process.GetProcessById(_app.ProcessId) != null;
                }
                catch { }
                if (!exist)
                {
                    _app = null;
                }
            }
            var old = _testName;
            _testName = testName;
            if (_app == null)
            {
                _app = ProcessController.StartApp();
                processStartAction?.Invoke(_app);
                return _app;
            }
            if (old != testName)
            {
                _app = ProcessController.StartApp();
                processStartAction?.Invoke(_app);
                return _app;
            }

            //タイマリセット
            _app.ResetTimeout();

            //デフォルトのサイズに設定
            _app.SetDefaultSize();

            //アクティブにする
            _app.AttachWorkspaceWindow().Activate();
            return _app;
        }

        public static void TestCleanup()
        {
            if (_app == null) return;

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var path = TestResult.MakeErrPngPath();

                //Killerが終了させた場合はすでにエラー画像が残っているので上書きしない
                if (!File.Exists(path))
                {
                    SaveFullScreeShot(path);
                }

                //終了させる
                _app.Kill();
                return;
            }

            //アプリがビジー状態になっているときも終了させる
            //終了操作に入って10秒で終了しないときはアプリがビジーとみなす
            bool alive = true;
            var id = _app.ProcessId;
            var tsk = Task.Factory.StartNew(() =>
            {
                var watch = new Stopwatch();
                watch.Start();
                while (alive)
                {
                    Thread.Sleep(1);
                }
                if (10000 < watch.ElapsedMilliseconds)
                {
                    try
                    {
                        Process.GetProcessById(id).Kill();
                    }
                    catch { }
                    try
                    {
                        var process = Process.GetProcessById(id);
                        if (process != null) process.WaitForExit();
                    }
                    catch { }
                }
            });

            try
            {
                //何かモーダルウィンドウが残っていれば終了
                if (_app.GetFromTypeFullName("").Length != 1)
                {
                    _app.Kill();
                    _app = null;
                    return;
                }

                _app.Kill();
                _app = null;
            }
            catch
            {
                _app.Kill();
                _app = null;
            }
            finally
            {
                alive = false;
                tsk.Wait();
            }

            if (_app != null)
            {
                _app.ClearTimeout();
            }
        }

        public static void End()
        {
            _app.Kill();
            _app = null;
            TestEnvironment.CleanupFiles();
        }

		/// <summary>
		/// 再起動する
		/// </summary>
		/// <returns>再起動後のWindowsAppFriend</returns>
		public static WindowsAppFriend Restart()
		{
			_app = _app.Restart();
			return _app;
		}

        static void SaveFullScreeShot(string path)
        {
            //全スクリーンの合計矩形を取得
            var l = int.MaxValue;
            var t = int.MaxValue;
            var r = int.MinValue;
            var b = int.MinValue;
            foreach (var e in System.Windows.Forms.Screen.AllScreens)
            {
                l = Math.Min(l, e.Bounds.Left);
                t = Math.Min(t, e.Bounds.Left);
                r = Math.Max(r, e.Bounds.Right);
                b = Math.Max(b, e.Bounds.Right);
            }
            var w = r - l + 1;
            var h = b - t + 1;

            //スクリーンショット取得
            using (var bmp = new System.Drawing.Bitmap(w, h))
            using (var g = System.Drawing.Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(new System.Drawing.Point(l, t), new System.Drawing.Point(0, 0), bmp.Size);
                bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
