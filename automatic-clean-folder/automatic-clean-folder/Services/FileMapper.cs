using Microsoft.Extensions.Logging;

namespace automatic_clean_folder;

public class FileMapper
{
    private readonly ILogger<FileMapper> _logger;
    public List<FileInfo> Files { get; set; }
    public string Path { get; set; }


    public FileMapper(string path)
    {
        this.Path = path;
    }

    public void GetFiles()
    {
        //_logger.LogInformation($"Getting files from {Path}");
        
        DirectoryInfo directoryInfo = new DirectoryInfo(Path);
        Files = directoryInfo.GetFiles("*.*").ToList();
        
        var fileCleaner = new FileCleaner(Files);
        fileCleaner.ExcludeFiles();
        
    }
}