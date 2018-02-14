using System;

namespace TestDataAccess
{
    public class JSONFile
    {
        public string Path { get; set; }
        private readonly string _name;


        public JSONFile(string path, string name)
        {
            if (name != null)
                _name = name;

            if (path != null)
                Path = $"{path}{_name}";

            JSONFilePathValidation();
        }

        public JSONFile()
        {
            JSONFilePathValidation();
        }

        public JSONFile(string fullPath)
        {
            if (fullPath != null)
                Path = fullPath;

            JSONFilePathValidation();
        }

        private void JSONFilePathValidation()
        {
            if (!Path.Contains("//") || !Path.Contains(".json"))
                throw new FormatException("Path not in the correct format");
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
