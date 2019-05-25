using System.Windows.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Windows.Media;
using System.Windows;
using Microsoft.Win32;

namespace WpfApplication1.Views
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        private static bool swap = false;
        private static string color = "#000000";
        private bool remember_button = false;
        private static bool quick_button = false;
        public SettingsView()
        {
            InitializeComponent();
            System.IO.StreamReader file1 = new System.IO.StreamReader("config.txt");
            string line;
            checkColor();
            while ((line = file1.ReadLine()) != null)
            {
                Match match = Regex.Match(line, "rememberdata=true");
                Match match2 = Regex.Match(line, "quickmode=true");
                if (match.Success)
                {
                    remember.Background = new SolidColorBrush(Colors.White);
                    remember1.Foreground = new SolidColorBrush(Colors.Black);
                    remember_button = true;
                    
                }
                if (match2.Success)
                {
                    quick.Background = new SolidColorBrush(Colors.White);
                    quick1.Foreground = new SolidColorBrush(Colors.Black);
                    quick_button = true;

                }
            }
        }

        public static bool getQuick()
        {
            return quick_button;
        }

        private void remember_Click_1(object sender, RoutedEventArgs e)
        {
            if (!remember_button)
            {
                remember.Background = new SolidColorBrush(Colors.White);
                remember1.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                remember_button = true;

                string[] arrLine = File.ReadAllLines("config.txt");
                arrLine[0] = "rememberdata=true";
                File.WriteAllLines("config.txt", arrLine);
            }
            else
            {
                remember.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                remember1.Foreground = new SolidColorBrush(Colors.White);
                remember_button = false;
                string[] arrLine = File.ReadAllLines("config.txt");
                arrLine[0] = "rememberdata=false";
                File.WriteAllLines("config.txt", arrLine);
            }
        }

        private void quick_Click(object sender, RoutedEventArgs e)
        {
            if (!quick_button)
            {
                quick.Background = new SolidColorBrush(Colors.White);
                quick1.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                quick_button = true;

                string[] arrLine = File.ReadAllLines("config.txt");
                arrLine[2] = "quickmode=true";
                File.WriteAllLines("config.txt", arrLine);
            }
            else
            {
                quick.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                quick1.Foreground = new SolidColorBrush(Colors.White);
                quick_button = false;

                string[] arrLine = File.ReadAllLines("config.txt");
                //arrLine[2] = "quickmode=false";
                File.WriteAllLines("config.txt", arrLine);
            }
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
                    if (remember_button)
                    {
                        remember.Background = new SolidColorBrush(Colors.White);
                        remember1.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                        
                    }
                    else
                    {
                        remember.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                        remember1.Foreground = new SolidColorBrush(Colors.White);
                        
                    }

                    if (quick_button)
                    {
                        quick.Background = new SolidColorBrush(Colors.White);
                        quick1.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                       
                    }
                    else
                    {
                        quick.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                        quick1.Foreground = new SolidColorBrush(Colors.White);
                       
                    }
                    swap = false;
                    //return;
                }
                await Task.Delay(2000);
            }
        }
    }
}
