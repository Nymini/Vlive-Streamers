using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Text.RegularExpressions;
using System.IO;
using WpfApplication1.Views;
using System.Windows.Shell;
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        private static string color = "#FFFFFF";
        private static string colorb = "#FFFFFF";
        private static bool swap = false;
 
        public MainWindow()
        {
            InitializeComponent();
            HamburgerMenuControl.Content = Home;
            taskBarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
            //Vlive.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            checkColor();
        }

        public static void updateColor(string color1, string color2)
        {
            swap = true;
            color = color1;
            colorb = color2;
        }

        private async void checkColor()
        {
            while(true)
            {
                if (swap)
                {
                    HamburgerMenuControl.PaneBackground = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                    Vlive.WindowTitleBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                    Vlive.NonActiveWindowTitleBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                    Vlive.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorb));
                    swap = false;
                    //return;
                }
                await Task.Delay(2000);
                taskBarItemInfo.ProgressValue = HomeView.getPercent();
            }
        }
        private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs e)
        {
            this.HamburgerMenuControl.Content = e.ClickedItem;
            this.HamburgerMenuControl.IsPaneOpen = false;
        }

    }
}
