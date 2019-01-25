using Codeer.TestAssistant.GeneratorToolKit;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Driver.InTarget
{
    public class WindowAnalysisMenuAction : IWindowAnalysisMenuAction
    {
        public Dictionary<string, MenuAction> GetAction(object target, WindowAnalysisTreeInfo info)
        {
            var dic = new Dictionary<string, MenuAction>();

            //TODO

            var grid = target as DataGrid;
            if (grid != null)
            {
                dic["Create Grid Column Define."] = () =>
                {
                    AnalyzeWindow.Output.Show();

                    AnalyzeWindow.Output.WriteLine("public class GridColumns");
                    AnalyzeWindow.Output.WriteLine("{");
                    int i = 0;
                    foreach (var e in grid.Columns)
                    {
                        AnalyzeWindow.Output.WriteLine("    const int " + e.Header.ToString() + " = " + i++ + ";");
                    }
                    AnalyzeWindow.Output.WriteLine("}");
                };
            }
            return dic;
        }
    }
}
