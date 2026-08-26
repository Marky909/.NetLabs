using AsyncDemo;
Console.WriteLine("Application started\n");
FileDownloader downloader = new FileDownloader();
//start downloading
Task downloadTask = downloader.DownloadFileAsync();

for(int i= 1;i<=5;i++)
{
    Console.WriteLine($"Application is doing other work... {i}");
    await Task.Delay(1000);
}

await downloadTask;
Console.WriteLine("\nApplication Finished");
