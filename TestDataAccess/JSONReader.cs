using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestDataAccess
{
    class JSONReader
    {
        public static Dictionary<string, string[]> TestValues;
        public static Dictionary<string, string[]> TestJsonArrayValues;
        public static Dictionary<string, string> TestCaseValues;
        public static int ListCount;

        //To check if the file path matches the expected pattern, and modify it accordingly if it doesn't
        private static string adjustJSONFilePath(string directoryPath, string JSONFileName)
        {
            string corrdirectoryPath = directoryPath +
                                       (JSONFileName.Contains("QA Automation\\") ? "" : "\\QA Automation\\") +
                                       (JSONFileName.Contains("TestCases\\") ?
                                           "" : (JSONFileName.Contains("TestCase\\") ?
                                               "" : (JSONFileName.Contains("TestData\\") ? "" : "TestData\\"))) +
                                       JSONFileName;

            return corrdirectoryPath;
        }

        /// <summary>
        /// To convert the JSON file contents to a JObject to use to to filter the JSON Object, and find the
        ///the requested test data
        /// </summary>
        /// <returns>JObject that represents the JSON file</returns>
        private static JObject ConvertFileToJObject(string directoryPath
            , string jsonFileName)
        {
            using (StreamReader file = File.
                OpenText(adjustJSONFilePath(directoryPath, jsonFileName)))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    return (JObject)JToken.ReadFrom(reader);
                }
            }

        }

        /// <summary>
        /// To retrieve the unfiltered test data from the JSON File to use in the constructors for this class
        /// </summary>
        /// <param name="directoryPath">directory of JSON file</param>
        /// <param name="jsonFileName">Name of JSON file</param>
        /// <param name="testDataKey">key property for the testdata</param>
        /// <param name="index">Index of the testcase(s)</param>
        /// <returns></returns>
        private JObject testData(string directoryPath, string jsonFileName,
            string testDataKey, int index)
        {
            return (JObject)ConvertFileToJObject(directoryPath, jsonFileName)
                .GetValue(testDataKey).ElementAt(index);
        }

        /// <summary>
        /// Constructor for a JSONReader to read the testCaseValues from a JSON File
        /// </summary>
        /// <param name="testDataKey"></param>
        /// <param name="testDataIndex">Index of the test case in JSON file</param>
        /// <param name="directoryPath"></param>
        /// <param name="jsonFileName"></param>
        public JSONReader(string directoryPath, string jsonFileName,
            string testDataKey, int testDataIndex)
        {
            JObject testDataAtTestDataIndex =
                (JObject)testData(directoryPath, jsonFileName, testDataKey, testDataIndex);
            TestCaseValues = JsonConvert
                .DeserializeObject<Dictionary<string, string>>(testDataAtTestDataIndex.ToString());

        }

        /// <summary>
        /// Read a value from JSon Data Structure with indices having conbination of subnodes and no subnodes
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="jsonFileName">Json File name in which Test data is present</param>  
        /// <param name="testDataKey">To access the value of the JSON property representing
        /// the test data</param>
        /// <param name="testDataIndex"></param>
        /// <param name="subKey">to get the the value of the subKey in the JSON Object</param>
        /// <param name="subIndex">Array Index of the value to be read in the subKey</param> 
        public JSONReader(string directoryPath, string jsonFileName, string testDataKey,
            int testDataIndex, string subKey, int subIndex)
        {
            {

                JObject testDataAtTestDataSubIndex =
                    (JObject)testData(directoryPath, jsonFileName, testDataKey, testDataIndex)
                    .GetValue(subKey).ElementAt(subIndex);
                TestCaseValues =
                    JsonConvert
                    .DeserializeObject<Dictionary<string, string>>(testDataAtTestDataSubIndex.ToString());
                ListCount = TestCaseValues.Count;

            }
        }

    }

}
