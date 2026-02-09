namespace automatic_clean_folder;

public static class LogWriter
{
   private static readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + 
                           @$"\temporaria\logs{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.txt";
   
    public static void Write(string logMessage)
    {
        using var stream = new FileStream(_path, FileMode.Append);
        using var writer = new  StreamWriter(stream);
        
        writer.WriteLine($"{logMessage} | {DateTime.Now}");
        writer.Close();
    }

    public static string GetLogPath()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + 
                @$"\temporaria";
    }
}