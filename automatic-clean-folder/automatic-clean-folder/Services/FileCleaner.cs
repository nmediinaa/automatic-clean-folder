using Microsoft.Extensions.Logging;

namespace automatic_clean_folder;

public class FileCleaner
{
    private readonly ILogger<FileCleaner> _logger;
    public List<FileInfo> Files { get; set; }

    public FileCleaner(List<FileInfo> files)
    {
        this.Files = files;
    }

    public void ExcludeFiles()
    {
        //_logger.LogInformation("Trying to exclude files");
        foreach (var file in Files)
        {
                if (file.LastWriteTime < DateTime.Now.AddDays(-30))
                {
                    try
                    {
                        //_logger.LogInformation($"Deleting {file.Name}");
                        Console.WriteLine($"Deleting {file.Name}");
                        Thread.Sleep(500);
                        Console.Clear();
                    }catch(Exception e)
                    {
                        //_logger.LogError(e.Message);
                        Console.WriteLine(e.Message);
                    }
                }
        }
    }
}