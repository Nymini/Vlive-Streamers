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
using System.Windows;
using System.IO;
using System.Net;
using System.Windows.Media;

using System.Windows.Input;
using Microsoft.Win32;
namespace WpfApplication1.Views
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class PrivateView : UserControl
    {
        private static bool swap = false;
        private static string color = "#FFFFFF";
        private static string fileLoc;
        private static int loops = 1;
        public PrivateView()
        {
            InitializeComponent();
            checkColor();
            System.IO.StreamReader file1 = new System.IO.StreamReader("config.txt");
            string line;
            while ((line = file1.ReadLine()) != null)
            {
                Match match = Regex.Match(line, "rememberdata=true");
                if (match.Success)
                {
                    line = file1.ReadLine();
                    line = Regex.Replace(line, "datalocation=", "");
                    bool FileValid = File.Exists(line);
                    if (!FileValid)
                    {
                        return;
                    }
                    System.IO.StreamReader file2 = new System.IO.StreamReader(line);
                    int time = 0;
                    while ((line = file2.ReadLine()) != null)
                    {
                        if (line == "1HR")
                        {
                            time = 0;
                            continue;
                        }
                        else if (line == "30M")
                        {
                            time = 1;
                            continue;
                        }
                        else if (line == "20M")
                        {
                            time = 2;
                            continue;
                        }
                        else if (line == "10M")
                        {
                            time = 3;
                            continue;
                        }
                        else if (line == "05M")
                        {
                            time = 4;
                            continue;
                        }
                        else if (line == "01M")
                        {
                            time = 5;
                            continue;
                        }
                        else if (line == "30S")
                        {
                            time = 5;
                            continue;
                        }
                        if (line == "END")
                        {
                            time = -1;
                        }
                        if (time == 0)
                        {
                            onehour.Text += line + "\n";
                        }
                        if (time == 1)
                        {
                            thirtymin.Text += line + "\n";
                        }
                        if (time == 2)
                        {
                            twentymin.Text += line + "\n";
                        }
                        if (time == 3)
                        {
                            tenmin.Text += line + "\n";
                        }
                        if (time == 4)
                        {
                            fivemin.Text += line + "\n";
                        }
                        if (time == 5)
                        {
                            onemin.Text += line + "\n";
                        }
                    }
                    HR = onehour.Text;
                    THM = thirtymin.Text;
                    TWM = twentymin.Text;
                    TEM = tenmin.Text;
                    FIM = fivemin.Text;
                    ONM = onemin.Text;
                }
            }
        }
        public static int getLoops()
        {
            return loops;
        }
        
        public static string getFile()
        {
            return fileLoc;
        }
        private static string HR = "Dank";
        private static string THM = "Dank";
        private static string TWM = "Dank";
        private static string TEM = "Dank";
        private static string FIM = "Dank";
        private static string ONM = "Dank";

        private void onehour_TextChanged(object sender, MouseEventArgs e)
        {
            if (HomeView.isStarted())
            {
                onehour.IsReadOnly = true;
                onehour.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#AEAEAE"));

                thirtymin.IsReadOnly = true;
                thirtymin.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#AEAEAE"));

                twentymin.IsReadOnly = true;
                twentymin.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#AEAEAE"));

                tenmin.IsReadOnly = true;
                tenmin.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#AEAEAE"));

                fivemin.IsReadOnly = true;
                fivemin.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#AEAEAE"));

                onemin.IsReadOnly = true;
                onemin.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#AEAEAE"));
            } else
            {
                onehour.IsReadOnly = false;
                onehour.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

                thirtymin.IsReadOnly = false;
                thirtymin.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

                twentymin.IsReadOnly = false;
                twentymin.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

                tenmin.IsReadOnly = false;
                tenmin.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

                fivemin.IsReadOnly = false;
                fivemin.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

                onemin.IsReadOnly = false;
                onemin.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            }
            HR = onehour.Text;
            THM = thirtymin.Text;
            TWM = twentymin.Text;
            TEM = tenmin.Text;
            FIM = fivemin.Text;
            ONM = onemin.Text;
        }
        
        private void textChanged(object sender, TextChangedEventArgs e)
        {
            HR = onehour.Text;
            THM = thirtymin.Text;
            TWM = twentymin.Text;
            TEM = tenmin.Text;
            FIM = fivemin.Text;
            ONM = onemin.Text;
        }
        private void updatePrivate()
        {
            onehour.Text = HR;
            thirtymin.Text = THM;
            twentymin.Text = TWM;
            tenmin.Text = TEM;
            fivemin.Text = FIM;
            onemin.Text = ONM;
        }
        private void minus_button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (loops > 1)
            {
                loops--;
            }
            loop_block.Text = loops.ToString();
        }

        private void plus_button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (loops < 9)
            {
                loops++;
            }
            loop_block.Text = loops.ToString();
            

        }
        public static string getText(int type)
        {
            if (type == 1) return HR;
            if (type == 2) return THM;
            if (type == 3) return TWM;
            if (type == 4) return TEM;
            if (type == 5) return FIM;
            return ONM;

        }
        public TextBox getOneHr()
        {
            return onehour;
        }
        private void load_button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "TEXT|*.txt";
            if (openFileDialog1.ShowDialog() == false)
            {
                return;
            }

            string file = openFileDialog1.FileName;
            fileLoc = file;
            string[] arrLine = File.ReadAllLines("config.txt");
            arrLine[1] = "datalocation=" + file;
            File.WriteAllLines("config.txt", arrLine);
            string line;
            int time = 0;
            System.IO.StreamReader file1 = new System.IO.StreamReader(file);
            onehour.Text = string.Empty;
            thirtymin.Text = string.Empty;
            twentymin.Text = string.Empty;
            tenmin.Text = string.Empty;
            fivemin.Text = string.Empty;
            onemin.Text = string.Empty;

            while ((line = file1.ReadLine()) != null)
            {
                if (line == "1HR")
                {
                    time = 0;
                    continue;
                }
                else if (line == "30M")
                {
                    time = 1;
                    continue;
                }
                else if (line == "20M")
                {
                    time = 2;
                    continue;
                }
                else if (line == "10M")
                {
                    time = 3;
                    continue;
                }
                else if (line == "05M")
                {
                    time = 4;
                    continue;
                }
                else if (line == "01M")
                {
                    time = 5;
                    continue;
                }
                else if (line == "30S")
                {
                    time = 5;
                    continue;
                }
                if (line == "END")
                {
                    time = -1;
                }
                if (time == 0)
                {
                    onehour.Text += line + "\n";
                }
                if (time == 1)
                {
                    thirtymin.Text += line + "\n";
                }
                if (time == 2)
                {
                    twentymin.Text += line + "\n";
                }
                if (time == 3)
                {
                    tenmin.Text += line + "\n";
                }
                if (time == 4)
                {
                    fivemin.Text += line + "\n";
                }
                if (time == 5)
                {
                    onemin.Text += line + "\n";
                }
            }
            HR = onehour.Text;
            THM = thirtymin.Text;
            TWM = twentymin.Text;
            TEM = tenmin.Text;
            FIM = fivemin.Text;
            ONM = onemin.Text;
            
        }

        private void save_button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TEXT|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, string.Empty);
                File.AppendAllText(saveFileDialog.FileName, "1HR\n");
                File.AppendAllText(saveFileDialog.FileName, onehour.Text);
                File.AppendAllText(saveFileDialog.FileName, "30M\n");
                File.AppendAllText(saveFileDialog.FileName, thirtymin.Text);
                File.AppendAllText(saveFileDialog.FileName, "20M\n");
                File.AppendAllText(saveFileDialog.FileName, twentymin.Text);
                File.AppendAllText(saveFileDialog.FileName, "10M\n");
                File.AppendAllText(saveFileDialog.FileName, tenmin.Text);
                File.AppendAllText(saveFileDialog.FileName, "05M\n");
                File.AppendAllText(saveFileDialog.FileName, fivemin.Text);
                File.AppendAllText(saveFileDialog.FileName, "01M\n");
                File.AppendAllText(saveFileDialog.FileName, onemin.Text);
                File.AppendAllText(saveFileDialog.FileName, "END");

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
                    hrbox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                    thirbox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                    twebox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                    tenbox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                    fibox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                    onebox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
                    swap = false;
                    //return;
                }
                await Task.Delay(2000);
            }
        }
    }
}
