using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFDownloadManager
{
    public partial class MainPage : ContentPage
    {
        IDownloader downloader = DependencyService.Get<IDownloader>();
        public MainPage()
        {
            InitializeComponent();
            downloader.OnFileDownloaded += OnFileDownloaded;
        }

        private void OnFileDownloaded(object sender, DownloadEventArgs e)
        {
            if (e.FileSaved)
            {
                DisplayAlert("XF Downloader", "File Saved Successfully", "Close");
            }
            else
            {
                DisplayAlert("XF Downloader", "Error while saving the file", "Close");
            }
        }

        private void DownloadClicked(object sender, EventArgs e)
        {
            downloader.DownloadFile("http://www.dada-data.net/uploads/image/hausmann_abcd.jpg", "XF_Downloads");
        }
    }
}
