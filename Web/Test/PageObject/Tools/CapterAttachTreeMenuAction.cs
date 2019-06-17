using Codeer.TestAssistant.GeneratorToolKit;
using OpenQA.Selenium;
using Selenium.StandardControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject.Tools
{
    public class CapterAttachTreeMenuAction : ICaptureAttachTreeMenuAction
    {
        public Dictionary<string, MenuAction> GetAction(string accessPath, object driver)
        {
            var dic = new Dictionary<string, MenuAction>();

            if (driver is IWebDriver web)
            {
                dic["Url"] = () =>
                {
                    CaptureAdaptor.AddCode(accessPath + ".Url = \"" + web.Url + "\";");
                };
            }
            else
            {
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
            }
            return dic;
        }

        static void AssertSingle(string accessPath, object obj)
        {
            if (obj is AnchorDriver anchor)
            {
                CaptureAdaptor.AddCode(accessPath + ".Text.Is(\"" + anchor.Text + "\");");
            }
            if (obj is DateDriver date)
            {
                CaptureAdaptor.AddCode(accessPath + ".Text.Is(\"" + date.Text + "\");");
            }
            if (obj is DropDownListDriver dropdown)
            {
                CaptureAdaptor.AddCode(accessPath + ".Text.Is(\"" + dropdown.Text + "\");");
            }
            if (obj is LabelDriver label)
            {
                CaptureAdaptor.AddCode(accessPath + ".Text.Is(\"" + label.Text + "\");");
            }
            if (obj is RadioButtonDriver radio)
            {
                CaptureAdaptor.AddCode(accessPath + ".Checked.Is(" + radio.Checked + ");");
            }
            if (obj is CheckBoxDriver check)
            {
                CaptureAdaptor.AddCode(accessPath + ".check.Is(" + check.Checked + ");");
            }
            if (obj is TextAreaDriver textArea)
            {
                CaptureAdaptor.AddCode(accessPath + ".Text.Is(\"" + textArea.Text + "\");");
            }
            if (obj is TextBoxDriver textBox)
            {
                CaptureAdaptor.AddCode(accessPath + ".Text.Is(\"" + textBox.Text + "\");");
            }
            if (obj is IWebElement element)
            {
                CaptureAdaptor.AddCode(accessPath + ".Text.Is(\"" + element.Text + "\");");
            }
        }
    }
}