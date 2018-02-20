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

        public string GetJsonPropertyValue(string propertyKey, int index)
        {
            var jsonProperty = GenerateJtokenFromJobject(propertyKey);
            var element = jsonProperty.ElementAt(index);

            return element.ToString();
        }

        public string GetJsonPropertyValue(string propertyKey)
        {
            var jsonProperty = GenerateJtokenFromJobject(propertyKey);

            return jsonProperty.ToString();
        }

        public List<string> ReadJsonArray(string propertyKey)
        {
            var jsonProperty = GenerateJtokenFromJobject(propertyKey);
            var JsonArray = JsonConvert
                .DeserializeObject<List<string>>(jsonProperty.ToString());

            return JsonArray;
        }

        public string ReadSinglePropertyFromJSONFile(string propertyKey)
        {
            return GetJsonPropertyValue(propertyKey);
        }

        public Dictionary<string, string> ReadJsonObject(string propertyKey)
        {
            var jsonProperty = GenerateJtokenFromJobject(propertyKey);
            var JsonObject = JsonConvert
                .DeserializeObject<Dictionary<string, string>>(jsonProperty.ToString());

            return JsonObject;
        }

        public List<string> ReadJsonObjectArray(string objectKey, string arrayKey)
        {
            var rootLevelJsonProperty = GenerateJtokenFromJobject(objectKey);
            var jTokenArray = rootLevelJsonProperty[arrayKey];

            var finalArray = JsonConvert
                .DeserializeObject<List<string>>(jTokenArray.ToString());

            return finalArray;
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

        private JToken GenerateJtokenFromJobject(string objectKey)
        {
            var jObject = this.ConvertJSONFileToJObject();
            var rootLevelJsonProperty = jObject.GetValue(objectKey);

            return rootLevelJsonProperty;
        }

        public JArray ReadArrayOfJsonObjects(string arrayKey)
        {
            var jObjectOfJsonFile = this.ConvertJSONFileToJObject();
            var jArrayofObjects = (JArray)jObjectOfJsonFile.GetValue(arrayKey);



            return jArrayofObjects;


        }
    }
}
