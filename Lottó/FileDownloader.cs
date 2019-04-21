using System;
using System.ComponentModel;
using System.Net;

namespace Lottó
{
    public static class FileDownloader
    {
        public static void DownloadFileAsync(string link, string filename, AsyncCompletedEventHandler completed)
        {
            DownloadFileAsync(link, filename, null, completed);
        }

        public static void DownloadFileAsync(string link, string filename, DownloadProgressChangedEventHandler progress_changed, AsyncCompletedEventHandler completed)
        {
            var client = new WebClient();
            client.DownloadFileCompleted += completed;
            client.DownloadProgressChanged += progress_changed;
            client.DownloadFileAsync(new Uri(link), filename);
        }
    }
}
