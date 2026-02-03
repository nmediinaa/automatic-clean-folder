namespace automatic_clean_folder;

public class FileCleaner
{
    public List<FileInfo> Files { get; set; }

    public FileCleaner(List<FileInfo> files)
    {
        this.Files = files;
    }

    public void ExcludeFiles()
    {
        foreach (var file in Files)
        {
            if (file.LastWriteTime < DateTime.Now.AddDays(-30))
            {
                Console.WriteLine($"{file.Name} {file.LastWriteTimeUtc.ToShortDateString()} [apagado]");
            }
        }
    }
}