using Codeer.TestAssistant.GeneratorToolKit;
using Microsoft.CSharp;
using System.Windows.Controls;
using System.Linq;
using System.Windows;
using System;
using DemoApp.Views;

namespace Driver.InTarget
{
    public class NamingRule : IDriverElementNameGenerator
    {
        CSharpCodeProvider _provider = new CSharpCodeProvider();

        public int Priority => 1;

        public string GenerateName(object target)
        {
            var name = GenerateNameCore(target);
            return _provider.IsValidIdentifier(name) ? name : string.Empty;
        }

        string GenerateNameCore(object target)
        { 
            if (target is ContentControl content)
            {
                if (content.Content is string) return content.Content.ToString().Replace(" ", "");
            }

            //Get name from nearby TextBlock.
            if (target is TextBox || target is ComboBox || target is Calendar || target is NumericUpDownControl)
            {
                var targetCtrl = target as Control;
                var targetPos = targetCtrl.PointToScreen(new Point());
                var root = targetCtrl.GetLogicalTreeAncestor().Where(e => e is UserControl || e is Window || e is Page).FirstOrDefault();
                if (root == null) return string.Empty;

                //Search for the closest TextBlock on the left.
                Func<FrameworkElement, Point, bool> isSameLine = (ctrl, pos) =>
                {
                    if (pos.Y < targetPos.Y - 5) return false;
                    if (targetPos.Y + targetCtrl.ActualHeight < pos.Y) return false;
                    return true;
                };
                var nearTextBlock = root.GetLogicalTreDescendants().OfType<FrameworkElement>().Select(e => new { ctrl = e, pos = e.PointToScreen(new Point()) }).
                    Where(e => isSameLine(e.ctrl, e.pos) && e.pos.X < targetPos.X).
                    OrderBy(e => e.pos.X).Select(e => e.ctrl).LastOrDefault() as TextBlock;

                //If it is not found, search for the closest TextBlock on the upper side.
                if (nearTextBlock == null)
                {
                    Func<FrameworkElement, Point, bool> isSameCol = (ctrl, pos) =>
                    {
                        if (pos.X < targetPos.X - 5) return false;
                        if (targetPos.X + targetCtrl.ActualWidth < pos.X) return false;
                        return true;
                    };

                    nearTextBlock = root.GetLogicalTreDescendants().OfType<FrameworkElement>().Select(e => new { ctrl = e, pos = e.PointToScreen(new Point()) }).
                       Where(e => isSameCol(e.ctrl, e.pos) && e.pos.Y < targetPos.Y).
                       OrderBy(e => e.pos.Y).Select(e => e.ctrl).LastOrDefault() as TextBlock;
                }

                if (nearTextBlock != null)
                {
                    return nearTextBlock.Text.Replace(" ", "");
                }
            }

            return string.Empty;
        }
    }
}
