namespace automatic_clean_folder;

public class Menu
{
    private string _title = "AUTOMATIC CLEAN FOLDER";

    public void Exibir()
    {
        string input;
        int cmd;
        Console.WriteLine(_title);
        Console.WriteLine("=".PadLeft(_title.Length, '='));
        Console.WriteLine("[1] Clean Folder".PadLeft(18));
        Console.WriteLine("[2] Exit Program".PadLeft(18));
        Console.WriteLine("[3] Get log path".PadLeft(18));
        Console.WriteLine("=".PadLeft(_title.Length, '='));
        Console.Write(">> ");
        input = Console.ReadLine()!;
        
        if (!int.TryParse(input, out cmd)) cmd = 0;
        
        switch (cmd)
        {
            case 1:
                CleanFolderMenu();
                break;
            case 2:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Please enter a valid option!");
                break;
        }
    }

    private void CleanFolderMenu()
    {
        Console.Clear();
        Console.WriteLine(_title);
        Console.WriteLine("=".PadLeft(_title.Length, '='));
        Console.WriteLine("Which folder would you like to clean?");
        Console.Write(">> ");
        var folderName = Console.ReadLine()!;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + $"\\{folderName}";
        
        var fileMapper = new FileMapper(path);        
        int totalFiles = fileMapper.LoadAndClean();

        Console.WriteLine($"Total files deleted: {totalFiles}");
        Thread.Sleep(5000);
        Console.Clear();
    }
}