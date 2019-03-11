using System.Collections.Generic;
using Codeer.TestAssistant.GeneratorToolKit;
using Driver.CustomDrivers;
using RM.Friendly.WPFStandardControls;

namespace Driver.Tools
{
    public class CapterAttachTreeMenuAction : ICaptureAttachTreeMenuAction
    {
        public Dictionary<string, MenuAction> GetAction(string accessPath, object driver)
        {
            var dic = new Dictionary<string, MenuAction>();

            dic["Assert"] = () =>
            {
                AssertSingle(accessPath, driver);
            };

            dic["Assert All"] = () =>
            {
                foreach (var e in driver.GetType().GetProperties())
                {
                    var obj = e.GetValue(driver);
                    if (obj == null) continue;

                    AssertSingle(accessPath + "." + e.Name, obj);
                }
            };
            return dic;
        }

        static void AssertSingle(string accessPath, object obj)
        {
            if (obj is WPFTextBox textBox)
            {
                CaptureAdaptor.AddCode(accessPath + ".Text.Is(\"" + textBox.Text + "\");");
            }
            if (obj is WPFComboBox combo)
            {
                CaptureAdaptor.AddCode(accessPath + ".SelectedIndex.Is(" + combo.SelectedIndex + ");");
            }
            if (obj is WPFToggleButton toggle)
            {
                var ret = toggle.IsChecked == null ? "IsNull()" :
                          toggle.IsChecked == true ? "Value.IsTrue()" : "Value.IsFalse()";
                CaptureAdaptor.AddCode(accessPath + ".IsChecked." + ret + ";");
            }
            if (obj is WPFCalendar calender)
            {
                var ret = calender.SelectedDate == null ? "IsNull()" :
                "Is(new DateTime(" + calender.SelectedDate.Value.Year + ", " + calender.SelectedDate.Value.Month + ", " + calender.SelectedDate.Value.Day + "))";
                CaptureAdaptor.AddCode(accessPath + ".SelectedDate." + ret + ";");
            }
            if (obj is WPFNumericUpDownDriver numericUpDown)
            {
                CaptureAdaptor.AddCode(accessPath + ".Value.Is(" + numericUpDown.Value + ");");
            }
            if (obj is WPFDataGrid grid)
            {
                var rowCount = grid.ItemCount;
                var colCount = grid.ColCount;
                for (int row = 0; row < rowCount; row++)
                {
                    for (int col = 0; col < colCount; col++)
                    {
                        var text = grid.GetCellText(row, col);

                        CaptureAdaptor.AddCode(accessPath +
                        ".GetCellText(" + row + ", " + col + ").Is(\"" + text + "\");");
                    }
                }
            }
        }
    }
}
