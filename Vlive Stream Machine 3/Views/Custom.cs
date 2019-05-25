using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace Wpfapplication1.Views
{
    public class Custom : HamburgerMenuIconItem
    {
        public static readonly DependencyProperty ToolTipProperty
            = DependencyProperty.Register("ToolTip",
                typeof(object),
                typeof(Custom),
                new PropertyMetadata(null));

        public object ToolTip
        {
            get { return (object)GetValue(ToolTipProperty); }
            set { SetValue(ToolTipProperty, value); }
        }
    }
}