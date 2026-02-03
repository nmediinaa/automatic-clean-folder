namespace automatic_clean_folder;

public class FileMapper
{
    public List<FileInfo> Files { get; set; }
    public string Path { get; set; }


    public FileMapper(string path)
    {
        this.Path = path;
    }

    public List<FileInfo> GetFiles()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Path);
        Files = directoryInfo.GetFiles("*.*").ToList();
        
        return Files;
    }
}