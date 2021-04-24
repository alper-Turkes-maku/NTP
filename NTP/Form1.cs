using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace NTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Alper TÜRKEŞ
            // 1812901034
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XmlTextReader veri = new XmlTextReader("https://www.cnnturk.com/feed/rss/all/news");
            listBox1.Items.Clear();
            while (veri.Read())
            {
                if (veri.Name == "title")
                {
                    listBox1.Items.Add(veri.ReadString());
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 20000;
            timer1.Start();
            XmlTextReader veri = new XmlTextReader("https://www.cnnturk.com/feed/rss/all/news");
            listBox1.Items.Clear();


            while (veri.Read())
            {
                if (veri.Name == "title")
                {
                    listBox1.Items.Add(veri.ReadString());
                }
            }


            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(@"C:\Users\alper\source\repos\NTP\NTP\bin\Debug\netcoreapp3.1\veri.txt");
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item.ToString());


            }

            SaveFile.WriteLine("Bitti");
            SaveFile.Close();
            if (listBox1.Items.Count >= 38)
            {
                MessageBox.Show("Yeni Haber Geldi. ");

            }
        }
    }
}
