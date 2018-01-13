using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace TasksInWPF4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Task task2 = new Task(() =>
            {
                var client = new WebClient();
                client.DownloadStringAsync(new Uri("https://www.microsoft.com/pl-pl/"));
                client.DownloadStringCompleted += Client_DownloadStringCompleted;
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
    }
}
