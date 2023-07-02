namespace PrawoJazdy.Extentions;

public static class FileSystemExtentions
{
    public static string GetPathToFileInAppData(this IFileSystem fileSystem, string fileName)
    {
        var appData = fileSystem.AppDataDirectory;
        return Path.Combine(appData, fileName);
    }
}
