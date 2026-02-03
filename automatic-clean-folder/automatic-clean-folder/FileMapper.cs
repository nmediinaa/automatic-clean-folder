using Microsoft.Extensions.Logging;

namespace automatic_clean_folder;

public class FileMapper
{
    private readonly ILogger<FileMapper> _logger;
    public List<FileInfo> Files { get; set; }
    public string Path { get; set; }


    public FileMapper(string path,  ILogger<FileMapper> logger)
    {
        this.Path = path;
        this._logger = logger;
    }

    public List<FileInfo> GetFiles()
    {
        _logger.LogInformation($"Getting files from {Path}");
        
        DirectoryInfo directoryInfo = new DirectoryInfo(Path);
        Files = directoryInfo.GetFiles("*.*").ToList();
        
        return Files;
    }
}