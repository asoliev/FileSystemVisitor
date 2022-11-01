// See https://aka.ms/new-console-template for more information
using FileSystemVisitor;

Console.Write("Enter the path of the directory: ");
string? rootDirectorypath = Console.ReadLine();
if (string.IsNullOrEmpty(rootDirectorypath))
{
    Console.WriteLine("Wrong path. Empty string.");
    Console.ReadKey();
    return;
}

Notifications n = new Notifications();
n.Notify += DisplayMessage;
n.Start();

void DisplayMessage(string message) => Console.WriteLine(message);

Console.WriteLine($"Getting directory tree of '{rootDirectorypath}'");
DirectoryTree.PrintDirectoryTree(rootDirectorypath);

n.Finish();

Console.Write("\nPlease type the extension (for example: *.txt, *.jpg, etc.) of the file" +
    "\nif you want to find the filtered file: *.");
string? fileExtension = Console.ReadLine();
if (string.IsNullOrEmpty(fileExtension))
{
    Console.WriteLine("Wrong extension. Empty string.");
    Console.ReadKey();
    return;
}
FilterByExtension.Filter(rootDirectorypath, fileExtension);

Console.WriteLine("\nPress 'Enter' to quit...");
Console.ReadLine();