using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FontAwesome.WPF;
using RM.Friendly.WPFStandardControls;

namespace Driver.InTarget
{
    public class Finder
    {
        public static Button FindButton(UIElement element, FontAwesomeIcon icon)
            => element.LogicalTree().ByType<Button>().
                Where(e => e.Content is ImageAwesome).Where(e => ((ImageAwesome)e.Content).Icon == icon).Single();
    }
}
