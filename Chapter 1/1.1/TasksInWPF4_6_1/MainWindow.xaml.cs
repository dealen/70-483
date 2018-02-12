using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace TasksInWPF4_6_1
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var httpClient = new HttpClient();

            var content = await httpClient.GetStringAsync("http://www.microsoft.com").ConfigureAwait(false);

            textBlockBig.Text = content;
        }

        private async void okButton2_Click(object sender, RoutedEventArgs e)
        {
            var httpClient = new HttpClient();

            var content = await httpClient.GetStringAsync("http://www.microsoft.com").ConfigureAwait(false);

            using (FileStream sourceStream = new FileStream("temp.html", FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true))
            {
                byte[] encodedText = Encoding.Unicode.GetBytes(content);
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length).ConfigureAwait(false);
            }
        }
    }
}
