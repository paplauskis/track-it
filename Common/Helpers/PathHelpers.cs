namespace Common.Helpers;

public static class PathHelpers
{
    public static string GetSolutionRoot()
    {
        var path = Environment.CurrentDirectory;

        while (!Directory.GetFiles(path, "*.sln").Any())
        {
            path = Directory.GetParent(path)!.FullName;
        }

        if (path == null)
        {
            throw new InvalidOperationException("Solution root could not be found.");
        }

        return Environment.OSVersion.Platform == PlatformID.Unix ? path + "/" : path + "\\";
    }
}