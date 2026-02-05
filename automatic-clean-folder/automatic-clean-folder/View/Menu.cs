namespace automatic_clean_folder;

public class Menu
{
    private string _title = "Automatic clean folder";

    public void Exibir()
    {
        int cmd;
        Console.WriteLine(_title);
        Console.WriteLine("=".PadLeft(_title.Length, '='));
        Console.WriteLine("[1] Clean Folder");
        Console.WriteLine("[2] Exit Program");
        Console.WriteLine("");
        Console.Write(">> ");
        cmd = Convert.ToInt32(Console.ReadLine()!);
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
        fileMapper.GetFiles();
    }
}