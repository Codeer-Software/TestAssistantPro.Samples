using Codeer.TestAssistant.GeneratorToolKit;
using Microsoft.CSharp;
using System.Windows.Controls;

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
            var content = target as ContentControl;
            if (content != null)
            {
                if (content.Content is string) return content.Content.ToString();
            }
            return string.Empty;
        }
    }
}
