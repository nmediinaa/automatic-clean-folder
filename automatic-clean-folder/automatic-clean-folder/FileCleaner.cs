using Microsoft.Extensions.Logging;

namespace automatic_clean_folder;

public class FileCleaner
{
    private readonly ILogger<FileCleaner> _logger;
    public List<FileInfo> Files { get; set; }

    public FileCleaner(List<FileInfo> files,  ILogger<FileCleaner> logger)
    {
        this.Files = files;
        this._logger = logger;
    }

    public void ExcludeFiles()
    {
        _logger.LogInformation("Trying to exclude files");
        foreach (var file in Files)
        {
            if (file.LastWriteTime < DateTime.Now.AddDays(-30))
            {
                Console.WriteLine($"{file.Name} {file.LastWriteTimeUtc.ToShortDateString()} [apagado]");
            }
        }
    }
}