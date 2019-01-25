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
                //TODO

                foreach (var e in driver.GetType().GetProperties())
                {
                    var obj = e.GetValue(driver);
                    if (obj == null) continue;
                    var textProp = obj.GetType().GetProperty("Text");
                    if (textProp == null) continue;

                    var text = textProp.GetValue(obj).ToString();

                    CaptureAdaptor.AddCode("Assert.AreEqual(" + accessPath + "." + e.Name + ".Text, \"" + text + "\");");
                }
            };

            return dic;
        }
    }
}
