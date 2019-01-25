using Codeer.TestAssistant.GeneratorToolKit;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Driver.InTarget
{
    public class WindowAnalysisMenuAction : IWindowAnalysisMenuAction
    {
        public Dictionary<string, MenuAction> GetAction(object target, WindowAnalysisTreeInfo info)
        {
            var dic = new Dictionary<string, MenuAction>();
            
            var grid = target as DataGrid;
            if (grid != null)
            {
                dic["Create Grid Column Define to Output."] = () =>
                {
                    AnalyzeWindow.Output.Show();

                    AnalyzeWindow.Output.WriteLine("public class GridColumns");
                    AnalyzeWindow.Output.WriteLine("{");
                    int i = 0;
                    foreach (var e in grid.Columns)
                    {
                        AnalyzeWindow.Output.WriteLine("    const int " + e.Header.ToString().Replace(" ", "") + " = " + i++ + ";");
                    }
                    AnalyzeWindow.Output.WriteLine("}");
                };

                dic["Create Grid Column Define to Code View."] = () =>
                {
                    var code = new StringBuilder();
                    code.AppendLine("namespace " + DriverCreatorAdapter.SelectedNamespace);
                    code.AppendLine("{");
                    code.AppendLine("    public class GridColumns");
                    code.AppendLine("    {");
                    int i = 0;
                    foreach (var e in grid.Columns)
                    {
                        code.AppendLine("        const int " + e.Header.ToString().Replace(" ", "") + " = " + i++ + ";");
                    }
                    code.AppendLine("    }");
                    code.AppendLine("}");
                    DriverCreatorAdapter.AddCode("GridColumns.cs", code.ToString(), target);
                };
            }
            return dic;
        }
    }
}
