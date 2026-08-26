using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncDemo
{
   public class FileDownloader
    {
        public async Task DownloadFileAsync()
        {
            Console.WriteLine("starting file download.....");
            await Task.Delay(5000);
            Console.WriteLine("Download completed");
        }
    }
}
