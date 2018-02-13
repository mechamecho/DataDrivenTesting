using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestDataAccess
{
    public class JSONReader
    {
        public static Dictionary<string, string[]> TestValues;
        public static Dictionary<string, string[]> TestJsonArrayValues;
        public static Dictionary<string, string> TestCaseValues;
        public static int ListCount;

        //To check if the file path matches the expected pattern, and modify it accordingly if it doesn't


        /// <summary>
        /// To convert the JSON file contents to a JObject to use to to filter the JSON Object, and find the
        ///the requested test data
        /// </summary>
        /// <returns>JObject that represents the JSON file</returns>
        private static JObject ConvertJSONFileToJObject(JSONFile jsonfile)
        {
            if (jsonfile == null)
            {
                throw new ArgumentException("JSON File can't be null");
            }

            return (JObject)JToken.ReadFrom(jsonfile.JSONFileReader);
        }

        /// <summary>
        /// To retrieve the unfiltered test data from the JSON File to use in the constructors for this class
        /// </summary>
        /// <param name="jsonFile">JSON file containing the test data</param>
        /// <param name="testDataKey">key property for the testdata</param>
        /// <param name="index">Index of the testcase(s)</param>
        /// <returns></returns>
        private JObject testData(JSONFile jsonFile,
            string testDataKey, int index)
        {
            return (JObject)ConvertJSONFileToJObject(jsonFile)
                .GetValue(testDataKey).ElementAt(index);
        }

        /// <summary>
        /// Constructor for a JSONReader to read the testCaseValues from a JSON File
        /// </summary>
        /// <param name="testDataKey"></param>
        /// <param name="testDataIndex">Index of the test case in JSON file</param>
        /// <param name="testDataIsInArray">To check if the test data is in an array</param>
        public JSONReader(JSONFile jsonFile,
            string testDataKey, int testDataIndex, bool testDataIsInArray)
        {
            if (!testDataIsInArray)
            {
                JObject testDataAtTestDataIndex =
                    (JObject)testData(jsonFile, testDataKey, testDataIndex);
                TestCaseValues = JsonConvert
                    .DeserializeObject<Dictionary<string, string>>(testDataAtTestDataIndex.ToString());
            }
            else
            {
                JObject testDataAtTestDataIndex =
                    (JObject)testData(jsonFile, testDataKey, testDataIndex);
                TestJsonArrayValues = JsonConvert
                    .DeserializeObject<Dictionary<string, string[]>>(testDataAtTestDataIndex.ToString());
            }


        }

        /// <summary>
        /// Read a value from JSON Data Structure with Sub Objects and Sub Indexes
        /// </summary> 
        /// <param name="testDataKey">To access the value of the JSON property representing
        /// the test data</param>
        /// <param name="testDataIndex"></param>
        /// <param name="subKey">to get the the value of the subKey in the JSON Object</param>
        /// <param name="subIndex">Array Index of the value to be read in the subKey</param> 
        public JSONReader(JSONFile jsonFile, string testDataKey,
            int testDataIndex, string subKey, int subIndex)
        {
            {

                JObject testDataAtTestDataSubIndex =
                    (JObject)testData(jsonFile, testDataKey, testDataIndex)
                    .GetValue(subKey).ElementAt(subIndex);
                TestCaseValues =
                    JsonConvert
                    .DeserializeObject<Dictionary<string, string>>(testDataAtTestDataSubIndex.ToString());
                ListCount = TestCaseValues.Count;

            }
        }


    }

}
