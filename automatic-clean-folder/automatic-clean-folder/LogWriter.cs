namespace automatic_clean_folder;
/*
 Aqui Temos uma classe estatica, pois, não temos nenhuma propriedade
 da classe que usamos em métodos da mesma, temos somente um atributo, privado, estatico e readonly para o 
 programa anotar todos os logs de UMA EXECUÇÃO em UM só arquivo, pois o PATH nn muda de nome uma vez 
 definido. Nos permitindo assim, escrever nos arquivos de logs somente passando a LogMessage e não sendo
 nescessario a instancia de um objeto LogWriter.
 */
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