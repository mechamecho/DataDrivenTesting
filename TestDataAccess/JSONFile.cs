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
            if (fullPath != null)
                FilePath = fullPath;

            //JSONFilePathValidation();
        }

        private void JSONFilePathValidation()
        {
            //if (!FilePath.Contains("/") || !FilePath.Contains(".json"))
            //    throw new FormatException("FilePath path not in the correct format");
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
