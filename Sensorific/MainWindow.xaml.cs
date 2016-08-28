using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Sensorific
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        string sensor = "";
        string sign = "";
        string value = "";
        string action = "";
        static string str = "";

        string hsensor = "";
        string component = "";
        string hsign = "";
        string hvalue = "";
        string haction = "";
        static string hstr = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task t = new Task(DownloadPageAsync);
            t.Start();
        }

        static async void DownloadPageAsync()
        {
            // ... Target page.
            string page = "http://10.1.0.72:5000/";

            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                // ... Display the result.
                if (result != null &&
                result.Length >= 50)
                {
                    Console.WriteLine(result);
                }
            }
        }

        static async void DownloadPageAsyncStr()
        {
            // ... Target page.
            string page = "http://10.1.0.72:5000/new/" + str;

            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                // ... Display the result.
                if (result != null &&
                result.Length >= 50)
                {
                    Console.WriteLine(result);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            sensor = "optical";
            hsensor = "a Luminosidade do ambiente ";
            hstr = "Se " + hsensor + hsign + value;
            hCond.Text = hstr;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            sensor = "temperature";
            hsensor = "a Temperatura do ambiente ";
            hstr = "Se " + hsensor + hsign + value;
            hCond.Text = hstr;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            sensor = "barometer";
            hsensor = "a Pressão do ambiente ";
            hstr = "Se " + hsensor + hsign + value;
            hCond.Text = hstr;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            sign = "<";
            hsign = "for menor do que ";
            hstr = "Se " + hsensor + hsign + value;
            hCond.Text = hstr;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            sign = "=";
            hsign = "for igual a ";
            hstr = "Se " + hsensor + hsign + value;
            hCond.Text = hstr;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            sign = ">";
            hsign = "for maior do que ";
            hstr = "Se " + hsensor + hsign + value;
            hCond.Text = hstr;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            action = "led off";
            haction = "desligue o ar condicionado ";
            hstr = "Se " + hsensor + hsign + value + ", então " + haction;
            hCond.Text = hstr;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            action = "led on";
            haction = "ligue o ar condicionado. ";
            hstr = "Se " + hsensor + hsign + value + ", então " + haction;
            hCond.Text = hstr;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            str = "if " + sensor + " " + sign + " " + TxtValue.Text + " then " + action + " end";
            Console.Write(str);

            Task t = new Task(DownloadPageAsyncStr);
            t.Start();
        }

        private void TxtValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            value = TxtValue.Text;
            hstr = "Se " + hsensor + hsign + value;
        }
    }
}
