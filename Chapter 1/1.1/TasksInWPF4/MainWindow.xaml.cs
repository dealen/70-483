﻿using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TasksInWPF4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceReference1.IMyFirstService client;

        public MainWindow()
        {
            InitializeComponent();
            client = new ServiceReference1.MyFirstServiceClient();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Task task2 = new Task(() =>
            {
                /*var client = new WebClient();
                client.DownloadStringAsync(new Uri("https://www.microsoft.com/pl-pl/"));
                client.DownloadStringCompleted += Client_DownloadStringCompleted;*/

                // connecting WCF Service
                
                var a = client.GetNames();
                foreach (var item in a)
                {
                    Thread.Sleep(1000);
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        textBlockBig.Text += item + " ";
                    }));
                }
            });

            task2.ContinueWith((o) => {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    okButton.Content = "Some new data!";
                }));
            });

            Task task = Task.Factory.StartNew(() =>
            {
                var numbers = Enumerable.Range(1, 10);
                foreach (var item in numbers)
                {
                    Thread.Sleep(500);
                    Dispatcher.BeginInvoke((Action)(() => 
                    {
                        lblCounter.Content = "Current number equals = " + item.ToString();
                    }));                    
                }
            });

            task.ContinueWith((Action<Task>)((one) =>
            {
                if (task.IsCompleted)
                {
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        okButton.Content = "Completed!";
                    }));
                    task2.Start();
                }
            }));

        }

        private void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                textBlockBig.Text = e.Result;
            }));
        }

        private void textBlockBig_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void okButton2_Click(object sender, RoutedEventArgs e)
        {
            //var client = new WebClient();

            //string 
        }
    }
}
