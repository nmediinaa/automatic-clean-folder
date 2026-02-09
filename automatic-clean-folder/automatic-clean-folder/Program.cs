using System.Reflection.Metadata;
using automatic_clean_folder;
using Microsoft.Extensions.Logging;

using var factory = LoggerFactory.Create(builder => builder.AddConsole());
var logger = factory.CreateLogger<Program>();

logger.LogInformation("Program has started");

LogWriter.Write("[INFO] The Program has started");

Thread.Sleep(1000);

Menu menu = new Menu();
while (true)
{
    menu.Exibir();    
}

