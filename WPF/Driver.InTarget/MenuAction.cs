using Codeer.TestAssistant.GeneratorToolKit;
using Microsoft.CSharp;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Driver.InTarget
{
    public class MenuAction : IWindowAnalysisMenuAction
    {
        public Dictionary<string, Codeer.TestAssistant.GeneratorToolKit.MenuAction> GetAction(object target, WindowAnalysisTreeInfo info)
        {
            var dic = new Dictionary<string, Codeer.TestAssistant.GeneratorToolKit.MenuAction>();

            var framework = target as FrameworkElement;
            if (framework != null)
            {
                dic["Sample"] = () =>
                {
                    AnalyzeWindow.Output.Show();
                    AnalyzeWindow.Output.WriteLine(framework.DataContext == null ? string.Empty : framework.DataContext.GetType().FullName);
                };
            }

            return dic;
        }
    }
}
