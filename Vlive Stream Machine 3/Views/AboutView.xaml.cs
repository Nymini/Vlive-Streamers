using System.Windows.Controls;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Threading;
using System.IO;
using WpfApplication1.Views;
using WindowsInput.Native;
using WindowsInput;
namespace WpfApplication1.Views
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class AboutView : UserControl
    {
        private static bool swap = false;
        private static string color = "#FFFFFF";
        public AboutView()
        {
            InitializeComponent();
            testimg1.Source = new BitmapImage(new Uri("pack://application:,,,/vlive1.png"));
            checkColor();
        }

        public static void updateColor(string color1)
        {
            swap = true;
            color = color1;
        }

        private async void checkColor()
        {
            while (true)
            {
                if (swap)
                {
                    
                    swap = false;
                    //return;
                }
                await Task.Delay(2000);
            }
        }
    }
}
