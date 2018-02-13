namespace TestDataAccess
{
    public class JSONFile
    {
        public string Path { get; set; }
        private string _name;

        public JSONFile(string path, string name)
        {
            if (path != null)
                Path = path;
            if (name != null)
                _name = name;
        }

        public void adjustJSONFilePath()
        {
            string corrdirectoryPath = Path +
                                       (_name.Contains("QA Automation\\") ? "" : "\\QA Automation\\") +
                                       (_name.Contains("TestCases\\") ?
                                           "" : (_name.Contains("TestCase\\") ?
                                               "" : (_name.Contains("TestData\\") ? "" : "TestData\\"))) +
                                       _name;

            Path = corrdirectoryPath;
        }
    }
}
