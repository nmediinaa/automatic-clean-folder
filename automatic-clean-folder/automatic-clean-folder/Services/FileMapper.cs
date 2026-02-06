using Microsoft.Extensions.Logging;

namespace automatic_clean_folder;

public class FileMapper
{
    public List<FileInfo> Files { get; set; }
    public string Path { get; set; }


    public FileMapper(string path)
    {
        this.Path = path;
    }

    public int LoadAndClean()
    {
        using var factory = LoggerFactory.Create(builder => builder.AddConsole());
        var loggerMapper = factory.CreateLogger<FileMapper>();
        loggerMapper.LogInformation($"Getting files from {Path}");
        Thread.Sleep(1000);
        
        DirectoryInfo directoryInfo = new DirectoryInfo(Path);
        if (!directoryInfo.Exists)
        {
            loggerMapper.LogInformation($"Directory {directoryInfo.FullName} does not exist");
        }
        else
        {
            Files = directoryInfo.GetFiles("*.*").ToList();
            var fileCleaner = new FileCleaner(Files);
            return fileCleaner.DeleteOldFiles();
        }
        
        return 0;
    }
}