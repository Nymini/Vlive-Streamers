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
using System.Drawing.Drawing2D;
using HtmlAgilityPack;
using System.Windows.Forms;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.PhantomJS;

namespace Vlive_Streamer
{
    public partial class Form1 : Form
    {
        private string current;
        private bool quick = false;

        public Form1()
        {
            InitializeComponent();
            //label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 44, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 52, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            current = "http://www.vlive.tv/home/new";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            label9.Text = "E\nM\nP\nT\nY\n";
            pictureBox1.Image = Image.FromFile("vlive.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            textBox1.Multiline = true;
            textBox1.MinimumSize = new Size(140, 250);
            textBox3.Multiline = true;
            textBox3.MinimumSize = new Size(140, 250);
            textBox4.Multiline = true;
            textBox4.MinimumSize = new Size(140, 250);
            textBox5.Multiline = true;
            textBox5.MinimumSize = new Size(140, 250);
            textBox7.Multiline = true;
            textBox7.MinimumSize = new Size(140, 250);
            textBox8.Multiline = true;
            textBox8.MinimumSize = new Size(140, 250);
            textBox2.AppendText("1");
            button1.Font = new Font(button2.Font.FontFamily, 12);
            button2.Font = new Font(button2.Font.FontFamily, 12);
            button3.Font = new Font(button2.Font.FontFamily, 12);

            textBox6.MinimumSize = new Size(319, 440);
            textBox6.Multiline = true;
            textBox6.ReadOnly = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = ((textBox1.Lines.Length) * int.Parse(textBox2.Lines[0]));
            this.BackColor = Color.FromArgb(31, 207, 255);

        }


        private async void button2_Click(object sender, EventArgs e)
        {

            if (!quick)
            {
                setName();
            }
            progressBar1.Maximum = (textBox7.Lines.Length - 1 + textBox1.Lines.Length - 1 + textBox3.Lines.Length - 1 +
                                    textBox8.Lines.Length - 1 + textBox4.Lines.Length - 1 + textBox5.Lines.Length - 1) * int.Parse(textBox2.Lines[0]);
            for (int k = 0; k < int.Parse(textBox2.Lines[0]); k++)
             {
                int counter = 0;
                //**********ONE HOUR**********//
                 for (int i = 0; i < textBox7.Lines.Length-1; i++)
                {
                    textBox6.AppendText(textBox7.Lines[i] + "\n");
                    progressBar1.Value++;
                    System.Diagnostics.Process.Start("microsoft-edge:" + textBox7.Lines[i]);
                    counter++;
                    
                    Thread.Sleep(15000);
                    if (counter > 14)
                    {
                        Thread.Sleep(4800000);

                        closeTabs(counter);
   
                        counter = 0;
                        Thread.Sleep(10000);

                    }

                }
                Thread.Sleep(4800000);
                closeTabs(counter);
                counter = 0;
                Thread.Sleep(10000);

                //**********30 MINUTES**********//
                for (int i = 0; i < textBox1.Lines.Length - 1; i++)
                {
                    textBox6.AppendText(textBox1.Lines[i] + "\n");
                    progressBar1.Value++;
                    System.Diagnostics.Process.Start("microsoft-edge:" + textBox1.Lines[i]);
                    counter++;
                    Thread.Sleep(15000);
                    if (counter > 14)
                    {
                        Thread.Sleep(2700000);
                        closeTabs(counter);
                        counter = 0;
                        Thread.Sleep(10000);

                    }

                }
                Thread.Sleep(2700000);
                closeTabs(counter);
                counter = 0;
                Thread.Sleep(10000);

                //**********20 MINUTES**********//
                for (int i = 0; i < textBox3.Lines.Length - 1; i++)
                {
                    textBox6.AppendText(textBox3.Lines[i] + "\n");
                    progressBar1.Value++;
                    System.Diagnostics.Process.Start("microsoft-edge:"+textBox3.Lines[i]);
                    counter++;
                    Thread.Sleep(15000);
                    if (counter > 14)
                    {
                        Thread.Sleep(1380000);
                        closeTabs(counter);
                        counter = 0;
                        Thread.Sleep(10000);

                    }

                }
                Thread.Sleep(1380000);
                closeTabs(counter);
                counter = 0;
                Thread.Sleep(10000);

                //**********10 MINUTES**********//
                for (int i = 0; i < textBox8.Lines.Length - 1; i++)
                {
                    textBox6.AppendText(textBox8.Lines[i] + "\n");
                    progressBar1.Value++;
                    System.Diagnostics.Process.Start("microsoft-edge:"+textBox8.Lines[i]);
                    counter++;
                    Thread.Sleep(15000);
                    if (counter > 14)
                    {
                        Thread.Sleep(960000);
                        closeTabs(counter);
                        counter = 0;
                        Thread.Sleep(960000);

                    }

                }
                Thread.Sleep(1380000);
                closeTabs(counter);
                counter = 0;
                Thread.Sleep(10000);

                //**********5 MINUTES**********//
                for (int i = 0; i < textBox4.Lines.Length - 1; i++)
                {
                    textBox6.AppendText(textBox4.Lines[i] + "\n");
                    progressBar1.Value++;
                    System.Diagnostics.Process.Start("microsoft-edge:"+textBox4.Lines[i]);
                    counter++;
                    Thread.Sleep(15000);
                    if (counter > 14)
                    {
                        Thread.Sleep(360000);
                        closeTabs(counter);
                        counter = 0;
                        Thread.Sleep(10000);

                    }

                }
                Thread.Sleep(360000);
                closeTabs(counter);
                counter = 0;
                Thread.Sleep(10000);

                //**********1 MINUTE**********//
                for (int i = 0; i < textBox4.Lines.Length - 1; i++)
                {
                    textBox6.AppendText(textBox4.Lines[i] + "\n");
                    progressBar1.Value++;
                    System.Diagnostics.Process.Start("microsoft-edge:"+textBox5.Lines[i]);
                    counter++;
                    Thread.Sleep(15000);
                    if (counter > 14)
                    {
                        Thread.Sleep(120000);
                        closeTabs(counter);
                        counter = 0;
                        Thread.Sleep(10000);

                    }

                }
                Thread.Sleep(120000);
                closeTabs(counter);
                counter = 0;
                Thread.Sleep(10000);
                textBox6.AppendText("LOOP FINISHED: SLEEPING FOR 120 SECONDS\n");
                Thread.Sleep(120000);
            }
            

        }

        private void closeTabs(int counter)
        {
            for (int j = counter; j > 0; j--)
            {
                //CLOSE PAGE
                SendKeys.SendWait("^{F4}");
                //System.Windows.Forms.SendKeys.SendWait("^{TAB}");
                Thread.Sleep(800);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void loadtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "TEXT|*.txt";
            openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName;

            string line;
            int time = 0;
            // Read the file and display it line by line.  
            textBox7.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox8.Clear();
            textBox4.Clear();
            textBox5.Clear();
            System.IO.StreamReader file1 = new System.IO.StreamReader(file);
            while ((line = file1.ReadLine()) != null)
            {
                if (line == "1HR")
                {
                    time = 0;
                    continue;
                } else if (line == "30M")
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
                } else if (line == "30S")
                {
                    time = 5;
                    continue;
                }
                if (line == "END")
                {
                    time = -1;
                }
                if (time == 0 )
                {
                    textBox7.AppendText(line + "\n");
                }
                if (time == 1)
                {
                    textBox1.AppendText(line + "\n");
                }
                if (time == 2)
                {
                    textBox3.AppendText(line + "\n");
                }
                if (time == 3)
                {
                    textBox8.AppendText(line + "\n");
                }
                if (time == 4)
                {
                    textBox4.AppendText(line + "\n");
                }
                if (time == 5)
                {
                    textBox5.AppendText(line + "\n");
                }
            }
            if (!quick)
            {
                setName();
            }
        }

        private void setName()
        {
            if (textBox7.Lines.Length == 0 && textBox1.Lines.Length == 0 && textBox3.Lines.Length == 0 && textBox4.Lines.Length == 0 && textBox5.Lines.Length == 0 && textBox8.Lines.Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("Please make sure no video input boxes are empty");
                return;

            }
            String[] toUse = textBox7.Lines;
            if (textBox7.Lines.Length == 0)
            {
                toUse = textBox1.Lines;
                if (textBox1.Lines.Length == 0)
                {
                    toUse = textBox3.Lines;
                    if (textBox3.Lines.Length == 0)
                    {
                        toUse = textBox4.Lines;
                        if (textBox4.Lines.Length == 0)
                        {
                            toUse = textBox5.Lines;
                            if (textBox5.Lines.Length == 0)
                            {
                                toUse = textBox8.Lines;
                                if (textBox8.Lines.Length == 0)
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            progressBar1.Maximum = ((textBox1.Lines.Length) * int.Parse(textBox2.Lines[0]));
            string groupName = Regex.Replace(toUse[0], ".*=", "");
            var url = "http://channels.vlive.tv/" + groupName + "/video";
            this.current = url;
            read_elements(url);
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
                        textBox6.AppendText(result2 + "\n");
                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < result2.Length; i++)
                        {
                            builder.Append(result2[i]);
                            builder.Append(Environment.NewLine);

                        }
                        label9.Text = builder.ToString();
                        label9.Font = new Font(label9.Font.FontFamily, (52 * 8) / (builder.ToString().Length / 2));
                    }
                    if (match2.Success)
                    {
                        
                        string imgurl = Regex.Replace(line, ".*content=", "");
                        string imgurl2 = Regex.Replace(imgurl, "\\?type=.*", "");
                        string imgurl3 = imgurl2.Trim().Trim('"');
                        textBox6.AppendText(imgurl3 + "\n");
                        //pictureBox1.Load(imgurl3);

                        Bitmap bmp = new Bitmap(1, 1);
                        Bitmap orig = new Bitmap(pictureBox1.Image);
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            // updated: the Interpolation mode needs to be set to 
                            // HighQualityBilinear or HighQualityBicubic or this method
                            // doesn't work at all.  With either setting, the results are
                            // slightly different from the averaging method.
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.DrawImage(orig, new Rectangle(0, 0, 1, 1));
                        }
                        Color pixel = bmp.GetPixel(0, 0);
                        byte r = pixel.R;
                        byte ge = pixel.G;
                        byte b = pixel.B;
                        // pixel will contain average values for entire orig Bitmap
                        this.BackColor = Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(ge), Convert.ToInt32(b));
                    }

                }
            }
            
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(current);

        }

        private  void read_elements(string url)
        {
            //var driver = new ChromeDriver();
            //TimeSpan timer = TimeSpan.FromSeconds(10);
            //driver.Manage().Timeouts().PageLoad = timer;
            //driver.Navigate().GoToUrl(url);
            PhantomJSDriver phantom = new PhantomJSDriver();

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
            textBox6.AppendText(whyyy + "\n");
            pictureBox1.Load(whyyy + "?type=nf720_342");


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.quick = !quick;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
