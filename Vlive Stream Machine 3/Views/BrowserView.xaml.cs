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
using System.Text.RegularExpressions;
namespace WpfApplication1.Views
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class BrowserView : UserControl
    {
        private static bool swap = false;
        private static string color = "#FFFFFF";
        public BrowserView()
        {
            
            InitializeComponent();
            for (int i = 2; i < 16; i++)
            {
                WebBrowser browser1 = new WebBrowser();
                browser1.Navigate("http://google.com");
                TabItem TI = new TabItem() { Header = i, Content = (browser1 as WebBrowser) };

                ControlsHelper.SetHeaderFontSize(TI, 12);
                
                Tabs.Items.Add(TI);
            }
            checkColor();
        }

        public static void updateColor(string color1)
        {
            swap = true;
            color = color1;
            
        }
        private bool vlive = true;
        private int amount = 2;
        private async void checkColor()
        {
            while (true)
            {
                if (swap)
                {
                    
                    swap = false;
                    //return;
                }
                await Task.Delay(1000);
                if (vlive)
                {
                    browser.Navigate("http://vlive.tv");
                    for (int i = 0; i < 15; i++)
                    {
                        TabItem dank = Tabs.Items[i] as TabItem;
                        WebBrowser aBrowser = dank.Content as WebBrowser;
                        aBrowser.Navigate("http://vlive.tv");
                    }
                }
                
                
                if (browser.Source != null)
                {
                    debug.Text = browser.Source.ToString();
                    Match match = Regex.Match(browser.Source.ToString(), "vlive");
                    if (match.Success)
                    {
                        vlive = false;
                    }
                }
            }
        }

    }
}
