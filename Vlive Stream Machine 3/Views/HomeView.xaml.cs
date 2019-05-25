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
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Drawing.Drawing2D;
using System.Drawing;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.PhantomJS;
using System.Net;

namespace WpfApplication1.Views
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private static bool started = false;
        private bool stop = false;
        private int current = 0;
        private int total = 0;
        private string currentL;
        private static double percent = 0;

        public HomeView()
        {
            InitializeComponent();
            testimg.Source = new BitmapImage(new Uri("pack://application:,,,/vlive1.jpg"));

        }

        private async void TestButton_Click(object sender, RoutedEventArgs e)
        {
            //testimg.Source = new BitmapImage(new Uri("C:\\Users\\Brandon Duong\\Music\\vlive1.jpg"));
            if (started)
            {
                stop = true;
                timer.Text = "Attempting to stop...";
                return;
            }
            console_box.Clear();
            timer.Text = "Attempting to start...";
            await Task.Delay(500);
            if (!SettingsView.getQuick())
            {
                setName();
            }
            current = 0;
            total = 0;
            string dank;
            string[] array;
            started = true;
            TestButton.Content = "STOP";
            for (int i = 0; i < 6; i++)
            {
                dank = PrivateView.getText(i);
                array = dank.Split(new string[] { "\n" }, StringSplitOptions.None);
                if (i == 1)
                {
                    total += (int)Math.Ceiling((double)((array.Length - 1)) / 15) * 4800;
                    total += (int)Math.Ceiling((double)((array.Length - 1)) / 15) * 180;
                }
                if (i == 2) { 
                    total += (int)Math.Ceiling((double)((array.Length - 1)) / 15) * 2700;
                    total += (int)Math.Ceiling((double)((array.Length - 1)) / 15) * 180;
                }
                if (i == 3)
                {
                    total += (int)Math.Ceiling((double)((array.Length - 1)) / 15) * 1380;
                    total += (int)Math.Ceiling((double)((array.Length - 1)) / 15) * 180;
                }
                if (i == 4)
                {
                    total += (int)Math.Ceiling((double)((array.Length - 1)) / 15) * 960;
                    total += (int)Math.Ceiling((double)((array.Length - 1)) / 15) * 180;
                }
                if (i == 5)
                {
                    total += (int)Math.Ceiling((double)((array.Length - 1)) / 15) * 360;
                    total += (int)Math.Ceiling((double)((array.Length - 1)) / 15) * 180;
                }

                if (i == 0)
                {
                    total += (int)Math.Ceiling((double)((array.Length - 1)) / 15) * 120;
                    total += (int)Math.Ceiling((double)((array.Length - 1)) / 15) * 180;
                }
                    //total += array.Length-1;
                    //console_box.Text += (array.Length-1) + "\n";
                }
            if (total == 0)
            {
                timer.Text = "NEED LINKS BOI";
                group.Text = "NEED LINKS BOI";
                started = false;
                TestButton.Content = "START";
                return;
            }
            for (int i = 0; i < 6; i++)
            {
                dank = PrivateView.getText(i);
                array = dank.Split(new string[] { "\n" }, StringSplitOptions.None);
                total += (array.Length - 1) * 15;
                //total += array.Length-1;
                //console_box.Text += (array.Length-1) + "\n";
            }
            total = total * PrivateView.getLoops();
            percentage.Text = ((current / total) * 100).ToString() + "%";
            percent = (double)((double)current / (double)total);;

            for (int k = 0; k < PrivateView.getLoops(); k++)
            {
                console_box.Text += "::::::LOOP " + (k + 1) + "::::::\n";
                int counter = 0;
                dank = PrivateView.getText(1);
                array = dank.Split(new string[] { "\n" }, StringSplitOptions.None);
                //-----------ONE HOUR----------//
                if (array.Length <= 1) goto thirtyminsec;
                console_box.Text += "----ONE HOUR SECTION----\n";
                for (int i = 0; i < array.Length-1; i++)
                {
                    
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }

                    timer.Text = "Opening link " + (i+1) + "/" + (array.Length-1);
                    console_box.Text += (i + 1) + ". " + array[i] + "\n";
                    System.Diagnostics.Process.Start("microsoft-edge:" + array[i]);
                    counter++;
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString();
                    await Task.Delay(2500);
                    for (int a = 0;  a < 15; a++)
                    {
                        percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                        percent = (double)((double)current / (double)total);
                        await Task.Delay(10);
                    }
                    if (counter > 14)
                    {
                        for (int x = 0; x < 4800; x++)
                        {
                            timer.Text = "Sleep time remaining: " + (4799 - x) + " seconds";
                            percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                            percent = (double)((double)current / (double)total);
                            await Task.Delay(1000);
                            if (stop)
                            {
                                started = false;
                                stop = false;
                                TestButton.Content = "START";
                                timer.Text = "";
                                return;
                            }

                        }
                        timer.Text = "Closing links..";
                        closeTabs(counter);
                        counter = 0;
                        for (int x = 0; x < 180; x++)
                        {
                            timer.Text = "Closing links.." + (179 - x);
                            await Task.Delay(1000);
                            percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                            percent = (double)((double)current / (double)total);
                            if (stop)
                            {
                                started = false;
                                stop = false;
                                TestButton.Content = "START";
                                timer.Text = "";
                                return;
                            }
                        }
                        timer.Text = "";


                    }

                }
                for (int x = 0; x < 4800; x++)
                {
                    timer.Text = "Sleep time remaining: " + (4799 - x) + " seconds";
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                    percent = (double)((double)current / (double)total);
                    await Task.Delay(1000);
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                }
                timer.Text = "Closing links..";
                closeTabs(counter);
                counter = 0;
                for (int x = 0; x < 180; x++)
                {
                    timer.Text = "Closing links.." + (179 - x);
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                    percent = (double)((double)current / (double)total);
                    await Task.Delay(1000);
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                }
                timer.Text = "";

                thirtyminsec:
                dank = PrivateView.getText(2);
                array = dank.Split(new string[] { "\n" }, StringSplitOptions.None);
                //-----------THIRTY MINTUES----------//
                if (array.Length <= 1) goto twentyminsec;
                console_box.Text += "----THIRTY MINTUE SECTION----\n";
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                    timer.Text = "Opening link " + (i + 1) + "/" + (array.Length - 1);
                    console_box.Text += (i + 1) + ". " + array[i] + "\n";
                    System.Diagnostics.Process.Start("microsoft-edge:" + array[i]);
                    await Task.Delay(2500);
                    counter++;
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString();
                    for (int a = 0; a < 15; a++)
                    {
                        percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                        percent = (double)((double)current / (double)total);
                        await Task.Delay(10);
                    }
                    if (counter > 14)
                    {
                        for (int x = 0; x < 2700; x++)
                        {
                            timer.Text = "Sleep time remaining: " + (2699 - x) + " seconds";
                            percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                            percent = (double)((double)current / (double)total);
                            await Task.Delay(1000);
                            if (stop)
                            {
                                started = false;
                                stop = false;
                                TestButton.Content = "START";
                                timer.Text = "";
                                return;
                            }
                        }
                        timer.Text = "Closing links..";
                        closeTabs(counter);
                        counter = 0;
                        for (int x = 0; x < 180; x++)
                        {
                            timer.Text = "Closing links.." + (179 - x);
                            percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                            percent = (double)((double)current / (double)total);
                            await Task.Delay(1000);
                            if (stop)
                            {
                                started = false;
                                stop = false;
                                TestButton.Content = "START";
                                timer.Text = "";
                                return;
                            }
                        }
                        timer.Text = "";

                    }

                }
                for (int x = 0; x < 2700; x++)
                {
                    timer.Text = "Sleep time remaining: " + (2699 - x) + " seconds";
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                    percent = (double)((double)current / (double)total);
                    await Task.Delay(1000);
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                }
                timer.Text = "Closing links..";
                closeTabs(counter);
                counter = 0;
                for (int x = 0; x < 180; x++)
                {
                    timer.Text = "Closing links.." + (179 - x);
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                    percent = (double)((double)current / (double)total);
                    await Task.Delay(1000);
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                }
                timer.Text = "";

                twentyminsec:
                dank = PrivateView.getText(3);
                array = dank.Split(new string[] { "\n" }, StringSplitOptions.None);
                //-----------TWENTY MINUTES----------//
                if (array.Length <= 1) goto tenminsec;
                console_box.Text += "----TWENTY MINUTE SECTION----\n";
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                    timer.Text = "Opening link " + (i + 1) + "/" + (array.Length - 1);
                    console_box.Text += (i+1) + ". " + array[i] + "\n";
                    System.Diagnostics.Process.Start("microsoft-edge:" + array[i]);
                    await Task.Delay(2500);
                    counter++;
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString();
                    for (int a = 0; a < 15; a++)
                    {
                        percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                        percent = (double)((double)current / (double)total);
                        await Task.Delay(10);
                    }
                    if (counter > 14)
                    {
                        for (int x = 0; x < 1380; x++)
                        {
                            timer.Text = "Sleep time remaining: " + (1379 - x) + " seconds";
                            percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                            percent = (double)((double)current / (double)total);
                            await Task.Delay(1000);
                            if (stop)
                            {
                                started = false;
                                stop = false;
                                TestButton.Content = "START";
                                timer.Text = "";
                                return;
                            }
                        }
                        timer.Text = "Closing links..";
                        closeTabs(counter);
                        counter = 0;
                        for (int x = 0; x < 180; x++)
                        {
                            timer.Text = "Closing links.." + (179 - x);
                            percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                            percent = (double)((double)current / (double)total);
                            await Task.Delay(1000);
                            if (stop)
                            {
                                started = false;
                                stop = false;
                                TestButton.Content = "START";
                                timer.Text = "";
                                return;
                            }
                        }
                        timer.Text = "";

                    }

                }
                for (int x = 0; x < 1380; x++)
                {
                    timer.Text = "Sleep time remaining: " + (1379 - x) + " seconds";
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                    percent = (double)((double)current / (double)total);
                    await Task.Delay(1000);
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                }
                timer.Text = "Closing links..";
                closeTabs(counter);
                counter = 0;
                for (int x = 0; x < 180; x++)
                {
                    timer.Text = "Closing links.." + (179 - x);
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                    percent = (double)((double)current / (double)total);
                    await Task.Delay(1000);
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                }
                timer.Text = "";

                tenminsec:
                dank = PrivateView.getText(4);
                array = dank.Split(new string[] { "\n" }, StringSplitOptions.None);
                //-----------TEN MINUTES----------//
                if (array.Length <= 1) goto fiveminsec;
                console_box.Text += "----TEN MINUTE SECTION----\n";
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                    timer.Text = "Opening link " + (i + 1) + "/" + (array.Length - 1);
                    console_box.Text += (i + 1) + ". " + array[i] + "\n";
                    System.Diagnostics.Process.Start("microsoft-edge:" + array[i]);
                    await Task.Delay(2500);
                    counter++;
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString();
                    for (int a = 0; a < 15; a++)
                    {
                        percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                        percent = (double)((double)current / (double)total);
                        await Task.Delay(10);
                    }
                    if (counter > 14)
                    {
                        for (int x = 0; x < 960; x++)
                        {
                            timer.Text = "Sleep time remaining: " + (959 - x) + " seconds";
                            percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                            percent = (double)((double)current / (double)total);
                            await Task.Delay(1000);
                            if (stop)
                            {
                                started = false;
                                stop = false;
                                TestButton.Content = "START";
                                timer.Text = "";
                                return;
                            }
                        }

                        timer.Text = "Closing links..";
                        closeTabs(counter);
                        counter = 0;
                        for (int x = 0; x < 180; x++)
                        {
                            timer.Text = "Closing links.." + (179 - x);
                            percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                            percent = (double)((double)current / (double)total);
                            await Task.Delay(1000);
                            if (stop)
                            {
                                started = false;
                                stop = false;
                                TestButton.Content = "START";
                                timer.Text = "";
                                return;
                            }
                        }
                        timer.Text = "";

                    }

                }
                for (int x = 0; x < 960; x++)
                {
                    timer.Text = "Sleep time remaining: " + (959 - x) + " seconds";
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                    percent = (double)((double)current / (double)total);
                    await Task.Delay(1000);
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                }
                timer.Text = "Closing links..";
                closeTabs(counter);
                counter = 0;
                for (int x = 0; x < 180; x++)
                {
                    timer.Text = "Closing links.." + (179 - x);
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                    percent = (double)((double)current / (double)total);
                    await Task.Delay(1000);
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                }
                timer.Text = "";

                fiveminsec:
                dank = PrivateView.getText(5);
                array = dank.Split(new string[] { "\n" }, StringSplitOptions.None);
                //-----------FIVE MINUTES----------//
                if (array.Length <= 1) goto oneminsec;
                console_box.Text += "----FIVE MINUTE SECTION----\n";
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                    timer.Text = "Opening link " + (i + 1) + "/" + (array.Length - 1);
                    console_box.Text += (i + 1) + ". " + array[i] + "\n";
                    System.Diagnostics.Process.Start("microsoft-edge:" + array[i]);
                    await Task.Delay(2500);
                    counter++;
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString();
                    for (int a = 0; a < 15; a++)
                    {
                        percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                        percent = (double)((double)current / (double)total);
                        await Task.Delay(10);
                    }
                    if (counter > 14)
                    {
                        for (int x = 0; x < 360; x++)
                        {
                            timer.Text = "Sleep time remaining: " + (359 - x) + " seconds";
                            percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                            percent = (double)((double)current / (double)total);
                            await Task.Delay(1000);
                            if (stop)
                            {
                                started = false;
                                stop = false;
                                TestButton.Content = "START";
                                timer.Text = "";
                                return;
                            }
                        }

                        timer.Text = "Closing links..";
                        closeTabs(counter);
                        counter = 0;
                        for (int x = 0; x < 180; x++)
                        {
                            timer.Text = "Closing links.." + (179 - x);
                            percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                            percent = (double)((double)current / (double)total);
                            await Task.Delay(1000);
                            if (stop)
                            {
                                started = false;
                                stop = false;
                                TestButton.Content = "START";
                                timer.Text = "";
                                return;
                            }
                        }
                        timer.Text = "";

                    }

                }
                for (int x = 0; x < 360; x++)
                {
                    timer.Text = "Sleep time remaining: " + (359 - x) + " seconds";
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                    percent = (double)((double)current / (double)total);
                    await Task.Delay(1000);
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                }
                timer.Text = "Closing links..";
                closeTabs(counter);
                counter = 0;
                for (int x = 0; x < 180; x++)
                {
                    timer.Text = "Closing links.." + (179 - x);
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                    percent = (double)((double)current / (double)total);
                    await Task.Delay(1000);
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                }
                timer.Text = "";

                oneminsec:
                dank = PrivateView.getText(6);
                array = dank.Split(new string[] { "\n" }, StringSplitOptions.None);
                //-----------ONE MINUTE----------//
                console_box.Text += "----ONE MINUTE SECTION----\n";
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                    timer.Text = "Opening link " + (i + 1) + "/" + (array.Length - 1);
                    console_box.Text += (i + 1) + ". " + array[i] + "\n";
                    System.Diagnostics.Process.Start("microsoft-edge:" + array[i]);
                    await Task.Delay(2500);
                    counter++;
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString();
                    for (int a = 0; a < 15; a++)
                    {
                        percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                        percent = (double)((double)current / (double)total);
                        await Task.Delay(10);
                    }
                    if (counter > 14)
                    {
                        for (int x = 0; x < 120; x++)
                        {
                            timer.Text = "Sleep time remaining: " + (119 - x) + " seconds";
                            percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                            percent = (double)((double)current / (double)total);
                            await Task.Delay(1000);
                            if (stop)
                            {
                                started = false;
                                stop = false;
                                TestButton.Content = "START";
                                timer.Text = "";
                                return;
                            }
                        }

                        timer.Text = "Closing links..";
                        closeTabs(counter);
                        counter = 0;
                        for (int x = 0; x < 180; x++)
                        {
                            timer.Text = "Closing links.." + (179 - x);
                            percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                            percent = (double)((double)current / (double)total);
                            await Task.Delay(1000);
                            if (stop)
                            {
                                started = false;
                                stop = false;
                                TestButton.Content = "START";
                                timer.Text = "";
                                return;
                            }
                        }
                        timer.Text = "";

                    }

                }
                for (int x = 0; x < 120; x++)
                {
                    timer.Text = "Sleep time remaining: " + (119 - x) + " seconds";
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                    percent = (double)((double)current / (double)total);
                    await Task.Delay(1000);
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                }
                timer.Text = "Closing links..";
                closeTabs(counter);
                counter = 0;
                await Task.Delay(180000);
                for (int x = 0; x < 180; x++)
                {
                    timer.Text = "Closing links.." + (179 - x);
                    percentage.Text = ((double)((double)++current / (double)total) * 100).ToString("##0.000") + "%";
                    percent = (double)((double)current / (double)total);
                    await Task.Delay(1000);
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                }
                for (int a = 0; a < 600; a++)
                {
                    timer.Text = "Loop " + (k + 1) + " finished. Next loop in " + (599 - a) + "s";
                    await Task.Delay(1000);
                    if (stop)
                    {
                        started = false;
                        stop = false;
                        TestButton.Content = "START";
                        timer.Text = "";
                        return;
                    }
                }
                
            }
            started = false;
            TestButton.Content = "START";
            timer.Text = "";
            
        }

        public static bool isStarted()
        {          
            return started;
        }
        private async void closeTabs(int counter)
        {
            for (int j = counter; j > 0; j--)
            {
                //CLOSE PAGE
                InputSimulator sim = new InputSimulator();
                sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.F4);
                console_box.Text += "Closed... " + j + "\n";
                await Task.Delay(8000);
                if (stop)
                {
                    started = false;
                    stop = false;
                    TestButton.Content = "START";
                    timer.Text = "";
                    return;
                }

            }
        }

        private void setName()
        {
            string dank;
            for (int i = 1; i <= 6; i++)
            {
                dank = PrivateView.getText(i);
                Match match1 = Regex.Match(dank, "vlive");
                if (match1.Success)
                {
                    goto success;
                }

            }
            return;
            success:
            string[] array = dank.Split(new string[] { "\n" }, StringSplitOptions.None);
            string groupName = Regex.Replace(array[0], ".*=", "");
            var url = "http://channels.vlive.tv/" + groupName + "/video";
            //this.current = url;
            var client = new WebClient();
            using (var stream = client.OpenRead(url))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //textBox6.AppendText(line + "\n");
                    Regex regex = new Regex("og:title");
                    Regex regex2 = new Regex("og:image");
                    Match match2 = regex2.Match(line);
                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        string result = Regex.Replace(line, ".*=", "");
                        string result1 = Regex.Replace(result, " :.*", "");
                        string result3 = Regex.Replace(result1, "[()]", "");
                        string result2 = result3.Trim().Trim('"');
                        group.Text = result2;
                        read_elements(url);
                    }
                    
                }
            }
        }

        private void read_elements(string url)
        {
            //var driver = new ChromeDriver();
            //TimeSpan timer = TimeSpan.FromSeconds(10);
            //driver.Manage().Timeouts().PageLoad = timer;
            //driver.Navigate().GoToUrl(url);
            var driverService = PhantomJSDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            var phantom = new PhantomJSDriver(driverService);
            phantom.Navigate().GoToUrl(url);
            //System.Threading.Thread.Sleep(2000);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //doc.LoadHtml(driver.PageSource);
            doc.LoadHtml(phantom.PageSource);
            while (doc.DocumentNode.SelectNodes("//*[@id=\"container\"]/channel/div/div/div") == null)
            {
                doc.LoadHtml(phantom.PageSource);

            }
            phantom.Quit();
            string dank = doc.DocumentNode.SelectNodes("//*[@id=\"container\"]/channel/div/div/div")[0].OuterHtml;
            string danki = Regex.Replace(dank, ".*background-image", "", RegexOptions.Singleline);
            //string danker = danki.Substring(0, 200);
            string dankii = Regex.Replace(danki, "background-color.*", "", RegexOptions.Singleline);
            string danker = Regex.Replace(dankii, "quot", "");
            string why = Regex.Replace(danker, "[();&]", "");
            string whyy = Regex.Replace(why, ": url", "");
            string whyyy = Regex.Replace(whyy, "\\?type=nf720_342.*", "", RegexOptions.Singleline);
            string whyyyy = Regex.Replace(whyyy, " ", "");

            testimg.Source = new BitmapImage(new Uri(whyyy + "?type=nf720_342"));
            currentL = whyyy + "?type=nf720_342";
            console_box.Text += current + "\n";
            testimg.Width = 389;
            testimg.Height = 185;
            testimg.Margin = new Thickness(-2, 0, 0, 0);
            TestButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#C2D5D5D5"));
            colourSet();
        }
        private void colourSet()
        {
            Bitmap bmp = new Bitmap(1, 1);
            System.Net.WebRequest request =
            System.Net.WebRequest.Create(currentL);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();
 
            Bitmap orig = new Bitmap(responseStream);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // updated: the Interpolation mode needs to be set to 
                // HighQualityBilinear or HighQualityBicubic or this method
                // doesn't work at all.  With either setting, the results are
                // slightly different from the averaging method.
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(orig, new System.Drawing.Rectangle(0, 0, 1, 1));
            }
            System.Drawing.Color pixel = bmp.GetPixel(0, 0);
            byte r = pixel.R;
            byte ge = pixel.G;
            byte b = pixel.B;
            // pixel will contain average values for entire orig Bitmap
            System.Drawing.Color myColor = System.Drawing.Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(ge), Convert.ToInt32(b));
            string hex = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
            console_box.Text += hex + "\n";
            console_label.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#" + hex));
            HomeScreen.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#"+hex));
            string background = "#" + hex;
            int red = Convert.ToInt32(r);
            int green = Convert.ToInt32(ge);
            int blue = Convert.ToInt32(b);
            if (red < 50) red = 0;
            else red = red - 50;
            if (green < 50) green = 0;
            else green = green - 50;
            if (blue < 50) blue = 0;
            else blue = blue - 50;
            System.Drawing.Color myColor1 = System.Drawing.Color.FromArgb(red, green, blue);
            hex = myColor1.R.ToString("X2") + myColor1.G.ToString("X2") + myColor1.B.ToString("X2");
            MainWindow.updateColor("#" +hex, background);
            PrivateView.updateColor("#" + hex);
            SettingsView.updateColor(background);
        }

        public static double getPercent()
        {
            return percent;
        }
    }
}
