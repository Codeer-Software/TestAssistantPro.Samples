using System.Collections.Generic;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;

namespace Driver.Tools
{
    public class CapterAttachTreeMenuAction : ICapterAttachTreeMenuAction
    {
        public Dictionary<string, MenuAction> GetAction(string accessPath, object driver)
        {
            var dic = new Dictionary<string, MenuAction>();

            dic["Assert"] = () =>
            {
                foreach (var e in driver.GetType().GetProperties())
                {
                    var obj = e.GetValue(driver);
                    if (obj == null) continue;

                    if (obj is WPFTextBox textBox)
                    {
                        CaptureAdaptor.AddCode(accessPath + "." + e.Name + ".Text.Is(\"" + textBox.Text + "\");");
                    }
                    if (obj is WPFComboBox combo)
                    {
                        CaptureAdaptor.AddCode(accessPath + "." + e.Name + ".SelectedIndex.Is(" + combo.SelectedIndex + ");");
                    }
                    if (obj is WPFToggleButton toggle)
                    {
                        var ret = toggle.IsChecked == null ? "IsNull()" :
                                  toggle.IsChecked == true ? "Value.IsTrue()" : "Value.IsFalse()";
                        CaptureAdaptor.AddCode(accessPath + "." + e.Name + ".IsChecked." + ret + ";");
                    }
                    if (obj is WPFCalendar calender)
                    {
                        var ret = calender.SelectedDate == null ? "IsNull()" :
                        "Is(new DateTime(" + calender.SelectedDate.Value.Year + ", " +  calender.SelectedDate.Value.Month + ", " + calender.SelectedDate.Value.Day + "))";
                        CaptureAdaptor.AddCode(accessPath + "." + e.Name + ".SelectedDate." + ret + ";");
                    }
                }
            };

            return dic;
        }
    }
}
