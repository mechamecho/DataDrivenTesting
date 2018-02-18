﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestDataAccess
{
    public class JSONReader
    {
        private JSONFile JsonFile;
        public static Dictionary<string, string[]> TestValues;
        public static Dictionary<string, string[]> TestJsonArrayValues;
        public static Dictionary<string, string> TestCaseValues;
        public static int ListCount;

        public JSONReader(JSONFile jsonFile)
        {
            this.JsonFile = jsonFile;
        }

        /// <summary>
        /// Returns a root level JSON collection value by specifying its key and collection index level.
        /// </summary>
        /// <param name="testDataKey"></param>
        /// <param name="testDataIndex"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetKeyAndIndexValue(string testDataKey, int testDataIndex)
        {
            var testDataAtTestDataIndex =
                this.GetKeyAndIndexValueFromJObject(this.JsonFile, testDataKey, testDataIndex);

            return JsonConvert
                .DeserializeObject<Dictionary<string, string>>(testDataAtTestDataIndex.ToString());
        }

        public Dictionary<string, string> GetNestedKeyAndIndexValue(string testDataKey, int testDataIndex, string subKey, int subIndex)
        {
            JObject testDataAtTestDataSubIndex =
                (JObject)this.GetKeyAndIndexValueFromJObject(this.JsonFile, testDataKey, testDataIndex)
                    .GetValue(subKey).ElementAt(subIndex);
            return JsonConvert
                    .DeserializeObject<Dictionary<string, string>>(testDataAtTestDataSubIndex.ToString());
        }

        public Dictionary<string, string[]> GetArrayThruKeyAndIndexValue(string testDataKey, int testDataIndex)
        {
            JObject testDataAtTestDataIndex =
                (JObject)this.GetKeyAndIndexValueFromJObject(this.JsonFile, testDataKey, testDataIndex);

                return JsonConvert
                    .DeserializeObject<Dictionary<string, string[]>>(testDataAtTestDataIndex.ToString());
        }

        /// <summary>
        /// To convert the JSON file contents to a JObject to use to to filter the JSON Object, and find the
        /// the requested test data
        /// </summary>
        /// <returns>JObject that represents the JSON file</returns>
        private static JObject ConvertJSONFileToJObject(JSONFile jsonFile)
        {
            if (jsonFile == null)
            {
                throw new ArgumentException($"JSONFile, {nameof(jsonFile)} can't be null");
            }

            using (StreamReader file = File.
                OpenText(jsonFile.FilePath))
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
        /// <param name="jsonFile">JSON file containing the test data</param>
        /// <param name="testDataKey">key property for the testdata</param>
        /// <param name="index">Index of the testcase(s)</param>
        /// <returns></returns>
        private JObject GetKeyAndIndexValueFromJObject(JSONFile jsonFile,
            string testDataKey, int index)
        {
            return (JObject)ConvertJSONFileToJObject(jsonFile)
                .GetValue(testDataKey)
                .ElementAt(index);
        }
    }
}
