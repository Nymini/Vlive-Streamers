using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using Windows.Foundation.Metadata;
using Windows.UI.ViewManagement;
using Windows.UI;
using Windows.ApplicationModel;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Vlive_Stream_Machine
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {



        private string groupname = "";
        private bool flagList = false;
        private bool started = false;
        private static ArrayList listLinks = new ArrayList();
        private static ArrayList listTimes = new ArrayList();
        private static ArrayList group_queue = new ArrayList();
        private static ArrayList group_videos = new ArrayList();

        private int loops = 1;
        private int browsers = 11;
        private static int totalSec = 0;
        private static int totalElapse = 0;
        private bool blackFont = true;

        private static bool[] isSeen = new bool[15];
        private bool swapFlag = false;
        private bool setPercent = false;
        private static int total = 0;
        private static int curr = 0;
        int[] browseTimes = new int[15];
        int[] maxTimes = new int[15];


        public MainPage()
        {
            this.InitializeComponent();
            this.SizeChanged += onResize;
            WebView browser1 = new WebView();
            browser1.Navigate(new Uri("http://vlive.tv"));
            TextBlock dank = new TextBlock() { Text = "Home", Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88)) };
            PivotItem TI = new PivotItem() { Header = dank, Content = (browser1 as WebView) };
            Tabs.Items.Add(TI);
            for (int i = 1; i < 12; i++)
            {
                browser1 = new WebView();
                browser1.Navigate(new Uri("http://google.com"));
                if (i < 10)
                {
                    dank = new TextBlock() { Text = " " + i, Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88)) };
                    TI = new PivotItem() { Header = dank, Content = (browser1 as WebView) };
                    TI.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
                }
                else
                {
                    dank = new TextBlock() { Text = i.ToString(), Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88)) };
                    TI = new PivotItem() { Header = dank, Content = (browser1 as WebView) };
                    TI.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
                }

                Tabs.Items.Add(TI);
            }

            ScrollViewer.SetVerticalScrollBarVisibility(vids, ScrollBarVisibility.Auto);
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;

                if (titleBar != null)
                {
                    titleBar.ButtonBackgroundColor = Color.FromArgb(255, 65, 72, 88);
                    titleBar.ButtonForegroundColor = Colors.White;
                    titleBar.BackgroundColor = Color.FromArgb(255, 65, 72, 88);
                    titleBar.ForegroundColor = Colors.White;
                }
            }
            string fileName = "ms-appx:///Assets/" + "vlive2.jpg";
            img.Source = new BitmapImage(new Uri(fileName));
            //readfile();
            load_dropdown();
        }
        private void onResize(object sender, RoutedEventArgs e)
        {
            if (((Frame)Window.Current.Content).ActualHeight > 350)
            {
                vids.Height = ((Frame)Window.Current.Content).ActualHeight - 350;
                vidb.Height = ((Frame)Window.Current.Content).ActualHeight - 350;
            }
            //vids.Text = vids.Height.ToString();
        }

        private async void readfile()
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            var myFile = await folder.TryGetItemAsync("vids.txt");
            if (myFile != null)
            {
                Windows.Storage.StorageFile sampleFile = await folder.GetFileAsync("vids.txt");
                vids.Text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
                string all = vids.Text;
                //string all = "dank";
                string[] array1 = all.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                for (int i = 0; i < array1.Length - 1; i++)
                {
                    string[] array2 = array1[i].Split(' ');
                    listLinks.Add(array2[0]);
                    listTimes.Add(myTimeConverter(array2[1]));
                }
                setName();
            }

            load_dropdown();


        }

        private async void load_dropdown()
        {
            StorageFolder folder2 = ApplicationData.Current.LocalFolder;

            IReadOnlyList<StorageFile> files = await folder2.GetFilesAsync();
            foreach (StorageFile file in files)
            {
                if (file.Name.Contains("videos"))
                {
                    string conv1 = Regex.Replace(file.Name, "videos", "");
                    conv1 = Regex.Replace(conv1, ".txt", "");
                    ComboBoxItem TI = new ComboBoxItem();
                    TI.Content = conv1;
                    dropdown.Items.Add(TI);
                }
            }
        }
        private async void fun()
        {

            while (true)
            {
                Random rnd = new Random();
                int r = rnd.Next(0, 256);
                int g = rnd.Next(0, 256);
                int b = rnd.Next(0, 256);
                main.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b)));
                await Task.Delay(30);

            }
        }

        
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (flagList)
            {
                if (started)
                {
                    started = false;
                    start.Content = "Start";
                    for (int i = 1; i < 12; i++)
                    {
                        ((Tabs.Items[i] as PivotItem).Content as WebView).Navigate(new Uri("http://google.com"));
                    }

                }
                else
                {
                    started = true;
                    start.Content = "Pause";

                }
            }

            if (!flagList)
            {
                if (group_queue.Count >= 1)
                {
                    swap_image();
                }
                if (group_queue.Count >= 1)
                {
                    StorageFolder folder = ApplicationData.Current.LocalFolder;
                    for (int i =0; i < group_queue.Count; i++)
                    {

                        var myFile = await folder.TryGetItemAsync("videos" + group_queue[i] + ".txt");
                        if (myFile != null)
                        {
                            Windows.Storage.StorageFile sampleFile = await folder.GetFileAsync("videos" + group_queue[i] + ".txt");
                            string tmp = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
                            string[] tmp_vids = tmp.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                            tmp_vids = tmp_vids.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                            ArrayList tmp_ls = new ArrayList(tmp_vids);
                            
                            group_videos.Add(tmp_ls);
                        }
                    }
                    int n_adds = 0;
                    vids.Text = "";
                    while (true)
                    {
                        for (int i = 0; i < group_videos.Count; i++)
                        {
                            if ((group_videos[i] as ArrayList).Count > 0)
                            {
                                vids.Text += (group_videos[i] as ArrayList)[0] + "\n";
                                (group_videos[i] as ArrayList).RemoveAt(0);
                                n_adds++;
                            }
                        }
                        if (n_adds == 0) break;
                        n_adds = 0;
                    }

                }
                
                string all = vids.Text;
                //string all = "dank";
                string[] array = all.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                for (int i = 0; i < array.Length - 1; i++)
                {
                    string[] array2 = array[i].Split(' ');
                    listLinks.Add(array2[0]);
                    listTimes.Add(myTimeConverter(array2[1]));
                    totalSec += myTimeConverter(array2[1]);
                    totalSec += ((int)myTimeConverter(array2[1]) / 10) + 20;
                }
                flagList = true;
                started = true;
                int numVids = listLinks.Count;
                for (int i = 0; i < loops - 1; i++)
                {
                    for (int j = 0; j < numVids; j++)
                    {
                        listLinks.Add(listLinks[j]);
                        listTimes.Add(listTimes[j]);
                        totalSec += (int)listTimes[j];
                        totalSec += ((int)listTimes[j] / 10) + 20;
                    }
                }
                browserStuff();
                start.Content = "Pause";
            }

        }

        
        private async void browserStuff()
        {
            while (true)
            {
                while (flagList)
                {

                    for (int i = 1; i < Tabs.Items.Count; i++)
                    {
                        if (browseTimes[i - 1] >= maxTimes[i - 1])
                        {
                            if (listLinks.Count > 0)
                            {
                                //((Tabs.Items[i] as TabItem).Content as WebBrowser).Source = new Uri(listLinks[0].ToString());
                                ((Tabs.Items[i] as PivotItem).Content as WebView).Navigate(new Uri(listLinks[0].ToString()));
                                listLinks.RemoveAt(0);
                                browseTimes[i - 1] = 0;
                                maxTimes[i - 1] = (int)listTimes[0] + ((int)listTimes[0] / 10) + 20;

                                listTimes.RemoveAt(0);
                                data.Text = listLinks.Count.ToString() + " videos left in the queue\n" + (totalSec - totalElapse) + " seconds left until finished";
                                await Task.Delay(500);
                                isSeen[i - 1] = false;


                            }
                            if (listLinks.Count == 0)
                            {
                                isSeen[i - 1] = false;
                            }
                        }

                    }
                    if (!swapFlag)
                    {
                        swapFocus();
                        swapFlag = true;
                    }
                    for (int i = 0; i < 15; i++)
                    {
                        if (isSeen[i])
                        {
                            browseTimes[i]++;

                            totalElapse++;
                            data.Text = listLinks.Count.ToString() + " videos left in the queue\n" + (totalSec - totalElapse) + " seconds left until finished";
                            while (!started)
                            {
                                await Task.Delay(1000);
                                data.Text = listLinks.Count.ToString() + " videos left in the queue(PAUSED)\n" + (totalSec - totalElapse) + " seconds left until finished(PAUSED)";
                            }
                            //curr++;
                        }
                    }
                    await Task.Delay(1000);

                    for (int i = 0; i < 15; i++)
                    {
                    }

                }
                await Task.Delay(2000);
            }
        }

        private async void swapFocus()
        {
            while (true)
            {
                for (int i = 1; i < Tabs.Items.Count; i++)
                {
                    if (!isSeen[i - 1])
                    {
                        while (!started)
                        {
                            await Task.Delay(1000);
                            data.Text = listLinks.Count.ToString() + " videos left in the queue(PAUSED)\n" + (totalSec - totalElapse) + " seconds left until finished(PAUSED)";
                        }
                        Tabs.SelectedIndex = i;
                        isSeen[i - 1] = true;
                        await Task.Delay(10000);
                    }
                }
                await Task.Delay(5000);
            }
        }


        private int myTimeConverter(string time)
        {
            Regex temp = new Regex(@"[0-9]+:[0-9]+:[0-9]+");
            int seconds = 0;
            if (temp.IsMatch(time))
            {
                string[] array = time.Split(new string[] { ":" }, StringSplitOptions.None);
                seconds += int.Parse(array[2]);
                seconds += (int.Parse(array[1]) * 60);
                seconds += (int.Parse(array[0]) * 60 * 60);
            }
            else
            {
                string[] array = time.Split(new string[] { ":" }, StringSplitOptions.None);
                seconds += (int.Parse(array[1]));
                seconds += (int.Parse(array[0]) * 60);
            }
            return seconds;
        }

        private void convertHTML(string html)
        {
            vids.Text = "";
            string[] array = html.Split(new string[] { "\n", "\t", "\r" }, StringSplitOptions.None);
            ArrayList seen = new ArrayList();
            for (int i = 0; i < array.Length - 1; i++)
            {

                Match match = Regex.Match(array[i], "channelCode");
                Match match2 = Regex.Match(array[i], "article_time");
                Match match3 = Regex.Match(array[i], "playlist");
                if (match.Success)
                {
                    string conv = Regex.Replace(array[i], ".*https:", "https:");
                    conv = Regex.Replace(conv, "\".*", "");
                    if (seen.Contains(conv))
                    {

                    }
                    else
                    {
                        vids.Text += conv;
                        seen.Add(conv);
                    }
                }
                if (match2.Success)
                {
                    string conv1 = Regex.Replace(array[i], ".*Play Time</em>", "");
                    conv1 = Regex.Replace(conv1, "</span.*", "");
                    vids.Text += " " + conv1 + "\n";
                }

                if (match3.Success)
                {
                    vids.Text += " " + "1:11\n";
                }

            }

            add_to_list();
            
        }

        private async void add_to_list()
        {
            string all = vids.Text;
            //string all = "dank";
            //vids.Text = "";
            string[] array1 = all.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < array1.Length - 1; i++)
            {

                string[] array2 = array1[i].Split(' ');
                listLinks.Add(array2[0]);
                listTimes.Add(myTimeConverter(array2[1]));
            }
            setName();
        }

        private async void setName()
        {
            string dank;
            for (int i = 1; i <= 6; i++)
            {
                dank = vids.Text;
                Match match1 = Regex.Match(dank, "vlive");
                if (match1.Success)
                {
                    goto success;
                }

            }
            return;
            success:
            await Task.Delay(1500);
            string groupNamel = Regex.Replace(listLinks[0].ToString(), ".*=", "");
            var url = "http://channels.vlive.tv/" + groupNamel + "/video";

            StorageFolder appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFolder assets = await appInstalledFolder.GetFolderAsync("Assets");
            string[] files = Directory.GetFiles(assets.Path);
            //vids.Text = string.Join(", ", files);
            string fileName = "";
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Contains(groupNamel))
                {
                    fileName = files[i];
                }
            }
            if (fileName == "")
            {
                ((Tabs.Items[0] as PivotItem).Content as WebView).NavigationCompleted += setimg;
            } else
            {
                fileName = Regex.Replace(fileName, ".*]", "", RegexOptions.Singleline);
                fileName = Regex.Replace(fileName, ".jpg", "", RegexOptions.Singleline);
                read_elements(fileName);
            }
            
            ((Tabs.Items[0] as PivotItem).Content as WebView).Navigate(new Uri(url));
            //((Tabs.Items[0] as PivotItem).Content as WebView).NavigationCompleted -= setimg;



        }

        private async void setimg(object sender, WebViewNavigationCompletedEventArgs e)
        {
            string html = await ((Tabs.Items[0] as PivotItem).Content as WebView).InvokeScriptAsync("eval", new string[] { "document.documentElement.outerHTML;" });
            Regex regex = new Regex(@"og:title");
            Match match = regex.Match(html);
            if (match.Success)
            {
                string result = Regex.Replace(html, ".*og:title\" content=\"", "", RegexOptions.Singleline);
                string result1 = Regex.Replace(result, " : V LIVE.*", "", RegexOptions.Singleline);
                string result2 = result1.Trim().Trim('"');
                result2 = Regex.Replace(result2, ".*title>", "", RegexOptions.Singleline);
                read_elements(result2);
            }
        }
        private async void read_elements(string url)
        {

            //vids.Text = Directory.GetCurrentDirectory();

            StorageFolder appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFolder assets = await appInstalledFolder.GetFolderAsync("Assets");
            string[] files = Directory.GetFiles(assets.Path);
            //vids.Text = string.Join(", ", files);
            string fileName = "";
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Contains(url))
                {
                    fileName = files[i];
                }
            }
            if (fileName == "")
            {
                groupname = url;
                //name.Text = url;
                set_vlive();
                return;
            }
            groupname = url;
            fileName = Regex.Replace(fileName, @".*\\", "");
            fileName = "ms-appx:///Assets/" + fileName;
            name.Text = url;
            data.Text = fileName;
            img.Source = new BitmapImage(new Uri(fileName));
            BitmapImage a = new BitmapImage(new Uri(fileName));
            start.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(105, 255, 255, 255));
            conv.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(105, 255, 255, 255));
            min.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(105, 255, 255, 255));
            max.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(105, 255, 255, 255));
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(fileName));

            using (var stream = await file.OpenAsync(FileAccessMode.Read))
            {
                //Create a decoder for the image
                var decoder = await BitmapDecoder.CreateAsync(stream);

                //Create a transform to get a 1x1 image
                var myTransform = new BitmapTransform { ScaledHeight = 1, ScaledWidth = 1 };
                myTransform.InterpolationMode = BitmapInterpolationMode.Fant;
                //Get the pixel provider
                var pixels = await decoder.GetPixelDataAsync(
                    BitmapPixelFormat.Rgba8,
                    BitmapAlphaMode.Ignore,
                    myTransform,
                    ExifOrientationMode.IgnoreExifOrientation,
                    ColorManagementMode.DoNotColorManage);

                //Get the bytes of the 1x1 scaled image
                var bytes = pixels.DetachPixelData();

                //read the color 
                main.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, bytes[0], bytes[1], bytes[2]));
                int red = bytes[0];
                int green = bytes[1];
                int blue = bytes[2];
                if (red < 50) red = 0;
                else red = red - 50;
                if (green < 50) green = 0;
                else green = green - 50;
                if (blue < 50) blue = 0;
                else blue = blue - 50;
                if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
                {
                    var titleBar = ApplicationView.GetForCurrentView().TitleBar;

                    if (titleBar != null)
                    {
                        titleBar.ButtonBackgroundColor = Color.FromArgb(255, Convert.ToByte(red), Convert.ToByte(green), Convert.ToByte(blue));
                        titleBar.ButtonForegroundColor = Colors.White;
                        titleBar.BackgroundColor = Color.FromArgb(255, Convert.ToByte(red), Convert.ToByte(green), Convert.ToByte(blue));
                        titleBar.ForegroundColor = Colors.White;
                    }
                }
                vids.Background = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(red), Convert.ToByte(green), Convert.ToByte(blue)));
                vids.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                numloops.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                bp.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                bm.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                bar.Background = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(red), Convert.ToByte(green), Convert.ToByte(blue)));
                vidb.Background = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(red), Convert.ToByte(green), Convert.ToByte(blue)));
            }

            if (!no_clear)
            {
                listLinks.Clear();
                listTimes.Clear();
            }
            //fun();
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            convertHTML(vids.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (loops > 1)
            {
                loops--;
            }
            
            numloops.Text = loops.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (loops < 9)
            {
                loops++;
            }
            numloops.Text = loops.ToString();

        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (browsers > 1)
            {
                Tabs.Items.RemoveAt(browsers);
                browsers--;

            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (browsers < 11)
            {
                WebView browser1 = new WebView();
                TextBlock dank = new TextBlock() { Text = "Home", Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255)) };
                PivotItem TI = new PivotItem() { Header = dank, Content = (browser1 as WebView) };
                browsers++;
                browser1 = new WebView();
                browser1.Navigate(new Uri("http://google.com"));
                if (browsers < 10)
                {
                    dank = new TextBlock() { Text = " " + browsers, Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255)) };
                    TI = new PivotItem() { Header = dank, Content = (browser1 as WebView) };
                    TI.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
                }
                else
                {
                    dank = new TextBlock() { Text = browsers.ToString(), Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255)) };
                    TI = new PivotItem() { Header = dank, Content = (browser1 as WebView) };
                    TI.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
                }

                Tabs.Items.Add(TI);
            }
        }

        private async void Button_Click_5(object sender, RoutedEventArgs e)
        {
            await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
        }


        private void change_font_colour(object sender, RoutedEventArgs e)
        {
            if (blackFont)
            {
                blackFont = false;
                bp.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                bm.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                intb.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                conv.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                start.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                font_col.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                min.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                max.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                numloops.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)); 
                Tabs.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)); 
                data.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                for (int i = 0; i < Tabs.Items.Count; i++)
                {
                    ((Tabs.Items[i] as PivotItem).Header as TextBlock).Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                }
            } else
            {
                blackFont = true;
                bp.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88));
                bm.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88));
                intb.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88));
                conv.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88));
                start.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88));
                font_col.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88));
                min.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88));
                max.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88));
                numloops.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88));
                Tabs.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88));
                data.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88));
                for (int i = 0; i < Tabs.Items.Count; i++)
                {
                    ((Tabs.Items[i] as PivotItem).Header as TextBlock).Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88));
                }
            }
        }
        private async void set_vlive()
        {
            ScrollViewer.SetVerticalScrollBarVisibility(vids, ScrollBarVisibility.Auto);
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;

                if (titleBar != null)
                {
                    titleBar.ButtonBackgroundColor = Color.FromArgb(255, 65, 72, 88);
                    titleBar.ButtonForegroundColor = Colors.White;
                    titleBar.BackgroundColor = Color.FromArgb(255, 65, 72, 88);
                    titleBar.ForegroundColor = Colors.White;
                }
            }
            main.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 84, 247, 255));
            string fileName = "ms-appx:///Assets/" + "vlive2.jpg";
            img.Source = new BitmapImage(new Uri(fileName));
            start.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88));
            conv.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88));
            min.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88));
            max.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 65, 72, 88));
            data.Text = "";
            vids.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            vids.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            data.Foreground = new SolidColorBrush(Color.FromArgb(255, 65, 72, 88));
            bar.Background = new SolidColorBrush(Color.FromArgb(255, 65, 72, 88));
            numloops.Foreground = new SolidColorBrush(Color.FromArgb(255, 65, 72, 88));
            vidb.Background = new SolidColorBrush(Color.FromArgb(255, 65, 72, 88));

            if (!no_clear)
            {
                listLinks.Clear();
                listTimes.Clear();
            }
        }

        private async void save_Click(object sender, RoutedEventArgs e)
        {
            bool seen = false;
            for (int i = 0; i < dropdown.Items.Count; i++)
            {
                if (groupname == (string)(dropdown.Items[i] as ComboBoxItem).Content)
                {
                    seen = true;
                }
            }
            if (!seen)
            {
                ComboBoxItem TI = new ComboBoxItem();
                TI.Content = groupname;
                dropdown.Items.Add(TI);
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("videos" + groupname + ".txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
                await Windows.Storage.FileIO.WriteTextAsync(sampleFile, vids.Text);
            } else
            {
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("videos" + groupname + ".txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
                await Windows.Storage.FileIO.WriteTextAsync(sampleFile, vids.Text);
                return;
            }

        }

        private async void dropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            data.Text = "DANK";
            var comboBoxItem = e.AddedItems[0] as ComboBoxItem;
            if (comboBoxItem == null) return;
            var content = comboBoxItem.Content as string;
            data.Text = content;
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            //TODO REMOVE vids.txt DEPENDENCY
            var myFile = await folder.TryGetItemAsync("vids.txt");
            if (myFile != null)
            {
                Windows.Storage.StorageFile sampleFile = await folder.GetFileAsync("videos" + content + ".txt");
                vids.Text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
            }
            add_to_list();
        }

        private void add_group_Click(object sender, RoutedEventArgs e)
        {
            var comboBoxItem = dropdown.Items[dropdown.SelectedIndex] as ComboBoxItem;
            if (comboBoxItem == null) return;
            if (!group_queue.Contains(comboBoxItem.Content as string))
            {
                group_queue.Add(comboBoxItem.Content as string);
            }
            data.Text = "Added " + comboBoxItem.Content + " to the group queue";
        }

        private bool no_clear = false;
        private async void swap_image()
        {
            
            while(true)
            {
                no_clear = true;
                for (int i = 0; i < group_queue.Count; i++)
                {
                    StorageFolder appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                    StorageFolder assets = await appInstalledFolder.GetFolderAsync("Assets");
                    string[] files = Directory.GetFiles(assets.Path);
                    //vids.Text = string.Join(", ", files);
                    string fileName = "";
                    for (int j = 0; j < files.Length; j++)
                    {
                        if (files[j].Contains(group_queue[i] as string))
                        {
                            fileName = files[j];
                        }
                    }
                    if (fileName == "")
                    {
                        name.Text = "";
                        set_vlive();
                    }
                    else
                    {
                        fileName = Regex.Replace(fileName, ".*]", "", RegexOptions.Singleline);
                        fileName = Regex.Replace(fileName, ".jpg", "", RegexOptions.Singleline);
                        read_elements(fileName);
                    }
                    await Task.Delay(90000);
                }
                
            }
            
        }
    }

}
