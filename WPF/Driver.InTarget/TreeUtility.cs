using System.Collections.Generic;
using System.Windows;

namespace Driver.InTarget
{
    public static class TreeUtility
    {
        public static IEnumerable<DependencyObject> GetLogicalTreDescendants(this DependencyObject obj)
        {
            List<DependencyObject> list = new List<DependencyObject>();
            list.Add(obj);
            foreach (var e in LogicalTreeHelper.GetChildren(obj))
            {
                DependencyObject d = e as DependencyObject;
                if (d != null)
                {
                    list.AddRange(GetLogicalTreDescendants(d));
                }
            }
            return list;
        }

        public static IEnumerable<DependencyObject> GetLogicalTreeAncestor(this DependencyObject obj)
        {
            List<DependencyObject> list = new List<DependencyObject>();
            while (obj != null)
            {
                list.Add(obj);
                obj = LogicalTreeHelper.GetParent(obj);
            }
            return list;
        }
    }
}