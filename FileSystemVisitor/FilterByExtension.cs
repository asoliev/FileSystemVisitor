namespace FileSystemVisitor
{
    public class FilterByExtension
    {
        public static void Filter(string rootDirectoryPath, string fileExtension)
        {
            if (string.IsNullOrEmpty(fileExtension))
            {
                DirectoryTree.PrintDirectoryTree(rootDirectoryPath);
            }
            else
            {
                try
                {
                    var files = Directory.EnumerateFiles(rootDirectoryPath, $"*.{fileExtension}", SearchOption.AllDirectories);

                    List<string> founds = new();
                    foreach (var file in files)
                        founds.Add(" - " + Path.GetFileName(file));
                    Console.WriteLine($"\n{files.Count()} files found:");
                    Console.WriteLine(string.Join('\n', founds));
                }
                catch (UnauthorizedAccessException uAEx)
                {
                    Console.WriteLine(uAEx.Message);
                }
                catch (PathTooLongException pathEx)
                {
                    Console.WriteLine(pathEx.Message);
                }
            }
        }
    }
}