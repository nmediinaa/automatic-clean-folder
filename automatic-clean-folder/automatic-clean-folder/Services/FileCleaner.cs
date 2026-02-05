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
        using var factory = LoggerFactory.Create(builder => builder.AddConsole());
        var loggerCleaner = factory.CreateLogger<FileCleaner>();
        loggerCleaner.LogInformation("Trying to exclude files");
        
        foreach (var file in Files)
        {
                if (file.LastWriteTime < DateTime.Now.AddDays(-30))
                {
                    try
                    {
                        loggerCleaner.LogInformation($"Deleting {file.Name}");
                        Thread.Sleep(500);
                    }catch(Exception e)
                    {
                        loggerCleaner.LogError(e.Message);
                    }
                }
        }
    }
}