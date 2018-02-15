using System;
using System.IO;

namespace DataDrivenTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullpath =
                "C:\\Users\\Engineer\\Desktop\\Prep-eM\\Data-Driven-testing\\JsonReaderCsharp\\DataDrivenTesting\\TestDataAccess.Tests\\testData.json";
            string fileName = Path.GetFileName(fullpath);
            Console.WriteLine($"{Path.GetFullPath(fullpath) == fullpath && Directory.Exists(fullpath.Replace(fileName, ""))} ");
            //            Console.WriteLine(Path.GetPathRoot("\\Users\\Engineer\\Desktop\\Prep-eM\\Data-Driven-testing\\JsonReaderCsharp\\DataDrivenTesting\\TestDataAccess.Tests\\testData.json"));
            //           Console.WriteLine(Path.IsPathRooted("C:\\Users\\Engineer\\Desktop\\Prep-eM\\Data-Driven-testing\\JsonReaderCsharp\\DataDrivenTesting\\TestDataAccess.Tests\\testData.json"));
            //{ Directory.Exists(Path.GetFullPath("7838475y"))}
        }
    }
}
