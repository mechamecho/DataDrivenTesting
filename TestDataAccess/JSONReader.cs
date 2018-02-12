using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace TestDataAccess
{
    class JSONReader
    {
        public static Dictionary<string, string[]> TestValues;
        public static Dictionary<string, string[]> TestJsonArrayValues;
        public static Dictionary<string, string> TestCaseValues;
        public static int ListCount;


        /// <summary>
        /// Constructor for a JSONReader to read the testCaseValues from a 
        /// JSON File
        /// </summary>
        /// <param name="directoryPath">Directory of the JSON file</param>
        /// <param name="jsonFileName">Name of the JSON file</param>
        /// <param name="testDataKey"></param>
        /// <param name="testDataIndex"></param>
        public JSONReader(string directoryPath, string jsonFileName, string testDataKey, int testDataIndex)
        {

        }

        private static JObject ConvertFileToJObject(string directoryPath, string jsonFileName)
        {
            using (StreamReader file = File.OpenText(adjustJSONFilePath(directoryPath, jsonFileName)))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    return (JObject)JToken.ReadFrom(reader);
                }
            }
            {

            }
        }

        private static string adjustJSONFilePath(string directoryPath, string JSONFileName)
        {
            string corrdirectoryPath = directoryPath +
                (JSONFileName.Contains("QA Automation\\") ? "" : "\\QA Automation\\") +
                (JSONFileName.Contains("TestCases\\") ? "" : (JSONFileName.Contains("TestCase\\") ?
                "" : (JSONFileName.Contains("TestData\\") ? "" : "TestData\\"))) +
                JSONFileName;

            return corrdirectoryPath;
        }



    }

}
