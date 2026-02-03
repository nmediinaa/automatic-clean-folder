using automatic_clean_folder;
using Microsoft.Extensions.Logging;

using var factory = LoggerFactory.Create(builder => builder.AddConsole());
var logger = factory.CreateLogger<Program>();
var loggerMapper = factory.CreateLogger<FileMapper>();
var loggerCleaner = factory.CreateLogger<FileCleaner>();

logger.LogInformation("Program has started");

String filePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
var mapper = new FileMapper(filePath, loggerMapper);
var fileFromDownload = mapper.GetFiles();


var fileCleaner = new FileCleaner(fileFromDownload, loggerCleaner);
fileCleaner.ExcludeFiles();

