using automatic_clean_folder;
String filePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
var mapper = new FileMapper(filePath);
var fileFromDownload = mapper.GetFiles();


var fileCleaner = new FileCleaner(fileFromDownload);
fileCleaner.ExcludeFiles();

