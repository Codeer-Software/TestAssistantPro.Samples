using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace DemoApp
{

    /// <summary>
    /// ウィンドウ情報。
    /// </summary>
    [Serializable]
    public class WindowInfo
    {
        IntPtr _handle;
        string _text = string.Empty;
        string _typeFullName = string.Empty;
        string _dotNetFieldPath = string.Empty;
        string _className = string.Empty;
        int _dialogId;
        int[] _zIndex = new int[0];
        int[] _logicalTreeIndex = new int[0];
        int[] _visualTreeIndex = new int[0];
        WindowInfo[] _children = new WindowInfo[0];
        Rectangle _bounds;

        [NonSerialized]
        object _targetObject;

        /// <summary>
        /// ウィンドウハンドル。
        /// </summary>
        public IntPtr Handle { get { return _handle; } set { _handle = value; } }

        /// <summary>
        /// ウィンドウテキスト。
        /// </summary>
        public string Text { get { return _text; } set { _text = value; } }

        /// <summary>
        /// .Netタイプフルネーム。
        /// </summary>
        public string TypeFullName { get { return _typeFullName; } set { _typeFullName = value; } }

        /// <summary>
        /// .Netの場合、この変数を取得するためのフルパス。
        /// </summary>
        public string DotNetFieldPath { get { return _dotNetFieldPath; } set { _dotNetFieldPath = value; } }

        /// <summary>
        /// ダイアログID。
        /// </summary>
        public int DialogId { get { return _dialogId; } set { _dialogId = value; } }

        /// <summary>
        /// ZIndex。
        /// </summary>
        public int[] ZIndex { get { return _zIndex; } set { _zIndex = value; } }

        /// <summary>
        /// LogicalTreeで取得した順番Index。
        /// </summary>
        public int[] LogicalTreeIndex { get { return _logicalTreeIndex; } set { _logicalTreeIndex = value; } }

        /// <summary>
        /// VisualTreeで取得した順番Index。
        /// </summary>
        public int[] VisualTreeIndex { get { return _visualTreeIndex; } set { _visualTreeIndex = value; } }

        /// <summary>
        /// ウィンドウクラス名称。
        /// </summary>
        public string ClassName { get { return _className; } set { _className = value; } }

        /// <summary>
        /// 子ウィンドウ。
        /// </summary>
        public WindowInfo[] Children { get { return _children; } set { _children = value; } }

        /// <summary>
        /// スクリーン座標での矩形。
        /// </summary>
        public Rectangle Bounds { get { return _bounds; } set { _bounds = value; } }

        /// <summary>
        /// 対象オブジェクト。
        /// シリアライズ対象外。
        /// </summary>
        public object TargetObject { get { return _targetObject; } set { _targetObject = value; } }
    }

    /// <summary>
    /// WPF解析。
    /// </summary>
    public class WpfAnalyzer
    {
        bool _isKeepVisualTree;

        /// <summary>
        /// 矩形。
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        /// <summary>
        /// ウィンドウ矩形の取得。
        /// </summary>
        /// <param name="hwnd">ウィンドウハンドル。</param>
        /// <param name="lpRect">矩形。</param>
        /// <returns>成否。</returns>
        [DllImport("user32.dll")]
        internal static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WpfAnalyzer() { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="isKeepVisualTree">visualTreeをキープするか</param>
        public WpfAnalyzer(bool isKeepVisualTree)
        {
            _isKeepVisualTree = isKeepVisualTree;
        }

        /// <summary>
        /// ウィンドウハンドルからオブジェクトへ変換。
        /// </summary>
        /// <param name="windowHandle">ウィンドウハンドル。</param>
        /// <returns>オブジェクト</returns>
        public object FromHandle(IntPtr windowHandle)
        {
            if (Application.Current == null)
            {
                return null;
            }
            foreach (Window element in Application.Current.Windows)
            {
                if (new WindowInteropHelper(element).Handle == windowHandle)
                {
                    return element;
                }
            }
            return null;
        }

        /// <summary>
        /// オブジェクトの持つウィンドウハンドルを取得
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <returns>ウィンドウハンドル</returns>
        public IntPtr GetHandle(object obj)
        {
            Window top = obj as Window;
            if (top == null)
            {
                return IntPtr.Zero;
            }
            return new WindowInteropHelper(top).Handle;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="windowHandle">ハンドル</param>
        /// <returns>ウィンドウ情報</returns>
        public WindowInfo Analyze(IntPtr windowHandle)
        {
            Window top = FromHandle(windowHandle) as Window;
            if (top == null)
            {
                return null;
            }

            RECT rc = new RECT();
            GetWindowRect(windowHandle, ref rc);
            WindowInfo info = GetWIndowInfoLogicalIndex(top, new System.Windows.Point(rc.left, rc.top), new List<int>());
            info.Text = top.Title;
            info.Handle = windowHandle;

            //ヴィジュアルツリーも追加
            WindowInfo visualInfo = GetWIndowInfoVisualIndex(top, new System.Windows.Point(rc.left, rc.top), new List<int>());
            if (_isKeepVisualTree)
            {
                MutualIndex(visualInfo.Children, info.Children);
                List<WindowInfo> children = new List<WindowInfo>(info.Children);
                children.AddRange(visualInfo.Children);
                info.Children = children.ToArray();
            }
            else
            {
                info.Children = MergeDuplication(visualInfo.Children, info.Children);
            }
            return info;
        }

        /// <summary>
        /// 重複をマージする
        /// </summary>
        /// <param name="visualInfo">ビジュアル情報</param>
        /// <param name="info">ロジカルツリー情報</param>
        /// <returns>重複を取り除いたビジュアル要素</returns>
        static WindowInfo[] MergeDuplication(WindowInfo[] visualInfo, WindowInfo[] logicalInfo)
        {
            List<WindowInfo> faltVisual = new List<WindowInfo>();
            ToFlat(visualInfo, faltVisual, true);
            List<WindowInfo> faltLogical = new List<WindowInfo>();
            ToFlat(logicalInfo, faltLogical, true);

            for (int i = faltVisual.Count - 1; 0 <= i; i--)
            {
                int logicalInfoIndex = IndexOf(faltLogical, faltVisual[i]);
                if (logicalInfoIndex != -1)
                {
                    faltLogical[logicalInfoIndex].VisualTreeIndex = faltVisual[i].VisualTreeIndex;
                    faltVisual.RemoveAt(i);
                }
            }
            faltLogical.AddRange(faltVisual);
            return faltLogical.ToArray();
        }

        /// <summary>
        /// インデックスをお互い持ち合う
        /// </summary>
        /// <param name="visualInfo">ビジュアル情報</param>
        /// <param name="info">ロジカルツリー情報</param>
        static void MutualIndex(WindowInfo[] visualInfo, WindowInfo[] logicalInfo)
        {
            List<WindowInfo> faltVisual = new List<WindowInfo>();
            ToFlat(visualInfo, faltVisual, false);
            List<WindowInfo> faltLogical = new List<WindowInfo>();
            ToFlat(logicalInfo, faltLogical, false);
            for (int i = 0; i < faltVisual.Count; i++)
            {
                int findIndex = IndexOf(faltLogical, faltVisual[i]);
                if (findIndex != -1)
                {
                    faltLogical[findIndex].VisualTreeIndex = faltVisual[i].VisualTreeIndex;
                }
            }
            for (int i = 0; i < faltLogical.Count; i++)
            {
                int findIndex = IndexOf(faltVisual, faltLogical[i]);
                if (findIndex != -1)
                {
                    faltVisual[findIndex].LogicalTreeIndex = faltLogical[i].LogicalTreeIndex;
                }
            }
        }

        /// <summary>
        /// ツリー構造からフラットなリストに変更
        /// </summary>
        /// <param name="infos">情報</param>
        /// <param name="list">リスト</param>
        /// <param name="clearChildren">子をクリアするか</param>
        static void ToFlat(WindowInfo[] infos, List<WindowInfo> list, bool clearChildren)
        {
            foreach (WindowInfo info in infos)
            {
                list.Add(info);
                ToFlat(info.Children, list, clearChildren);
                if (clearChildren)
                {
                    info.Children = new WindowInfo[0];
                }
            }
        }

        /// <summary>
        /// リストの中から参照が一致するインデックスを見つける。
        /// </summary>
        /// <param name="list">リスト。</param>
        /// <param name="obj">オブジェクト。</param>
        /// <returns>インデックス。</returns>
        private static int IndexOf(List<WindowInfo> list, WindowInfo obj)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (ReferenceEquals(obj.TargetObject, list[i].TargetObject))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// ロジカルツリーからウィンドウ情報取得
        /// </summary>
        /// <param name="target">対象</param>
        /// <param name="rootPos">ルート位置</param>
        /// <param name="logicalIndex">ロジカルインデックス</param>
        /// <returns>ウィンドウ情報</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        static WindowInfo GetWIndowInfoLogicalIndex(object target, System.Windows.Point rootPos, List<int> logicalIndex)
        {
            WindowInfo info = CreateWindowInfo(target, rootPos, logicalIndex, new List<int>());

            //子情報
            List<WindowInfo> list = new List<WindowInfo>();
            DependencyObject dep = target as DependencyObject;
            if (dep != null)
            {
                int index = 0;
                foreach (object child in LogicalTreeHelper.GetChildren(dep))
                {
                    logicalIndex.Add(index);
                    list.Add(GetWIndowInfoLogicalIndex(child, rootPos, logicalIndex));
                    logicalIndex.RemoveAt(logicalIndex.Count - 1);
                    index++;
                }
            }
            info.Children = list.ToArray();
            return info;
        }

        /// <summary>
        /// ビジュアルツリーからウィンドウ情報取得
        /// </summary>
        /// <param name="target">対象</param>
        /// <param name="rootPos">ルート位置</param>
        /// <param name="visualIndex">ビジュアルインデックス</param>
        /// <returns>ウィンドウ情報</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        static WindowInfo GetWIndowInfoVisualIndex(object target, System.Windows.Point rootPos, List<int> visualIndex)
        {
            WindowInfo info = CreateWindowInfo(target, rootPos, new List<int>(), visualIndex);

            //子情報
            List<WindowInfo> list = new List<WindowInfo>();
            Visual visual = target as Visual;
            if (visual != null)
            {
                int count = VisualTreeHelper.GetChildrenCount(visual);
                for (int index = 0; index < count; index++)
                {
                    object child = VisualTreeHelper.GetChild(visual, index);
                    visualIndex.Add(index);
                    list.Add(GetWIndowInfoVisualIndex(child, rootPos, visualIndex));
                    visualIndex.RemoveAt(visualIndex.Count - 1);
                }
            }
            info.Children = list.ToArray();
            return info;
        }

        /// <summary>
        /// ウィンドウ情報作成
        /// </summary>
        /// <param name="target">対象</param>
        /// <param name="rootPos">ルート位置</param>
        /// <param name="logicalIndex">ロジカルインデックス</param>
        /// <param name="visualIndex">ビジュアルインデックス</param>
        /// <returns>ウィンドウ情報</returns>
        static WindowInfo CreateWindowInfo(object target, System.Windows.Point rootPos, List<int> logicalIndex, List<int> visualIndex)
        {
            WindowInfo info = new WindowInfo();

            //情報設定
            info.TargetObject = target;
            info.TypeFullName = target.GetType().FullName;
            FrameworkElement frameworkElement = target as FrameworkElement;
            if (frameworkElement != null && frameworkElement.IsLoaded)
            {
                try
                {
                    System.Windows.Point pos = frameworkElement.PointToScreen(new System.Windows.Point(0, 0));
                    info.Bounds = new Rectangle((int)(pos.X - rootPos.X), (int)(pos.Y - rootPos.Y),
                        (int)frameworkElement.ActualWidth, (int)frameworkElement.ActualHeight);
                }
                catch { }
            }
            info.LogicalTreeIndex = logicalIndex.ToArray();
            info.VisualTreeIndex = visualIndex.ToArray();
            return info;
        }
    }
}