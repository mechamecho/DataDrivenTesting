using System;
using System.IO;

namespace DataDrivenTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Path.GetFullPath("7838475y")} {Directory.Exists(Path.GetFullPath("7838475y"))}");
            Console.WriteLine(Path.GetPathRoot("\\Users\\Engineer\\Desktop\\Prep-eM\\Data-Driven-testing\\JsonReaderCsharp\\DataDrivenTesting\\TestDataAccess.Tests\\testData.json"));
            Console.WriteLine(Path.IsPathRooted("C:\\Users\\Engineer\\Desktop\\Prep-eM\\Data-Driven-testing\\JsonReaderCsharp\\DataDrivenTesting\\TestDataAccess.Tests\\testData.json"));

        }
    }
}
