using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Killer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var targetId = int.Parse(args[0].Trim());
            var timeout = int.Parse(args[1].Trim());
            var errorPng = args[2].Trim();

            Process process;
            try
            {
                process = Process.GetProcessById(targetId);
                if (process == null) return;
            }
            catch
            {
                return;
            }

            var start = DateTime.Now;
            while (!process.HasExited)
            {
                if (new TimeSpan(0, 0, 0, 0, timeout) < DateTime.Now - start)
                {
                    try
                    {
                        SaveFullScreeShot(errorPng);
                    }
                    catch { }

                    try
                    {
                        process.Kill();
                    }
                    catch { }
                    break;
                }

                Thread.Sleep(500);
            }
            
            try
            {
                Process.GetProcessesByName("WerFault").ToList().ForEach(x => x.Kill());
            }
            catch { }
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
