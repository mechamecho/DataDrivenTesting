using Newtonsoft.Json;
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
                this.GetKeyAndIndexValueFromJObject(testDataKey, testDataIndex);

            return JsonConvert
                .DeserializeObject<Dictionary<string, string>>(testDataAtTestDataIndex.ToString());
        }

        /// <summary>
        /// Returns a nested level JSON collection value by specifying its key, collection index level and parent key and index.
        /// </summary>
        /// <param name="testDataKey"></param>
        /// <param name="testDataIndex"></param>
        /// <param name="subKey"></param>
        /// <param name="subIndex"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetNestedKeyAndIndexValue(string testDataKey, int testDataIndex, string subKey, int subIndex)
        {
            JObject testDataAtTestDataSubIndex =
                (JObject)this.GetKeyAndIndexValueFromJObject(testDataKey, testDataIndex)
                    .GetValue(subKey).ElementAt(subIndex);
            return JsonConvert
                    .DeserializeObject<Dictionary<string, string>>(testDataAtTestDataSubIndex.ToString());
        }

        /// <summary>
        /// Returns a root level JSON collection value by specifying its key.
        /// </summary>
        /// <param name="testDataKey"></param>
        /// <param name="testDataIndex"></param>
        /// <returns></returns>
        public Dictionary<string, string[]> GetArrayThruKeyAndIndexValue(string testDataKey, int testDataIndex)
        {
            JObject testDataAtTestDataIndex =
                (JObject)this.GetKeyAndIndexValueFromJObject(testDataKey, testDataIndex);

            return JsonConvert
                .DeserializeObject<Dictionary<string, string[]>>(testDataAtTestDataIndex.ToString());
        }

        /// <summary>
        /// To convert the JSON file contents to a JObject to use to to filter the JSON Object, and find the
        /// the requested test data
        /// </summary>
        /// <returns>JObject that represents the JSON file</returns>
        private JObject ConvertJSONFileToJObject()
        {
            if (this.JsonFile == null)
            {
                throw new ArgumentException($"JSONFile, {nameof(this.JsonFile)} can't be null");
            }

            using (StreamReader file = File.OpenText(this.JsonFile.FilePath))
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
        private JObject GetKeyAndIndexValueFromJObject(
            string testDataKey, int index)
        {
            var jObject = this.ConvertJSONFileToJObject();
            var value = jObject.GetValue(testDataKey);
            var element = value.ElementAt(index);

            return (JObject)element;
        }

        public string GetJsonPropertyValue(string testDataKey, int index)
        {
            var jObject = this.ConvertJSONFileToJObject();
            var value = jObject.GetValue(testDataKey);
            var element = value.ElementAt(index);

            return element.ToString();
        }

        public string GetJsonPropertyValue(string testDataKey)
        {
            var jObject = this.ConvertJSONFileToJObject();
            var value = jObject.GetValue(testDataKey);

            return value.ToString();
        }

        public string ReadSinglePropertyFromJSONFile(string propertyKey)
        {
            return GetJsonPropertyValue(propertyKey);
        }
    }
}
