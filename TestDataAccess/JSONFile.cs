using System;
using System.IO;

namespace TestDataAccess
{
    public class JSONFile
    {
        public string FilePath { get; set; }
        private readonly string _name;


        public JSONFile(string path, string name)
        {
            if (name != null)
                _name = name;

            if (path != null)
                FilePath = $"{path}{_name}";

            //JSONFilePathValidation();
        }

        public JSONFile()
        {

        }

        public JSONFile(string fullPath)
        {
            if (fullPath != null && JSONFilePathValidation(fullPath))
                FilePath = fullPath;

            throw new FormatException("File Path is not in the correct format or the File doesn't exist.");


            //JSONFilePathValidation();
        }

        private bool JSONFilePathValidation(string fullPath)
        {
            //if (!FilePath.Contains("/") || !FilePath.Contains(".json"))
            //    throw new FormatException("FilePath path not in the correct format");
            string fileName = Path.GetFileName(fullPath);
            if (Path.GetFullPath(fullPath) == fullPath)
                Console.WriteLine("Ok");
            if (Directory.Exists(fullPath.Replace(fileName, "")))
            {
                Console.WriteLine("ok");

                return true;
            }

            return false;
        }

        //private string JSONFilePathValidation()
        //{
        //    var qaDirectory = "QA Automation\\";
        //    var testDataDirectory = "TestData\\";

        //    return (_name.Contains(qaDirectory) ? "" : $"{qaDirectory}\\") +
        //            (_name.Contains("TestCases\\") ?
        //            "" : (_name.Contains("TestCase\\") ?
        //            "" : (_name.Contains(testDataDirectory) ? "" : testDataDirectory)));
        //}
    }
}
