using Newtonsoft.Json;
using System.IO;

namespace TestDataAccess
{
    public class JSONFile
    {
        public string Path { get; set; }
        private readonly string _name;
        public JsonTextReader JSONFileReader { get; set; }

        public JSONFile(string path, string name)
        {
            if (path != null)
                Path = $"{path}{JSONFilePathValidation()}{_name}";
            if (name != null)
                _name = name;

            using (StreamReader file = File.
                OpenText(Path))
            {
                JSONFileReader = new JsonTextReader(file);
            }
        }

        private string JSONFilePathValidation()
        {
            var qaDirectory = "QA Automation\\";
            var testDataDirectory = "TestData\\";

            return (_name.Contains(qaDirectory) ? "" : $"{qaDirectory}\\") +
                    (_name.Contains("TestCases\\") ?
                    "" : (_name.Contains("TestCase\\") ?
                    "" : (_name.Contains(testDataDirectory) ? "" : testDataDirectory)));
        }
    }
}
