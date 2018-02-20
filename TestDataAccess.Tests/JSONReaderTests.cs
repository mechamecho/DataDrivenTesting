using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace TestDataAccess.Tests
{
    using System;

    [TestFixture]
    public class JSONReaderTests
    {
        private static readonly string SolutionBinary = System.AppContext.BaseDirectory;
        private static readonly string SolutionName = "TestDataAccess.Tests";
        private static readonly string RootDirectory = SolutionBinary.Substring(0, SolutionBinary.IndexOf(SolutionName) + SolutionName.Length);

        private const string JsonFileName = "testData.json";
        private static readonly string FullFilePath = $"{RootDirectory}{Path.DirectorySeparatorChar}{JsonFileName}";

        [Test]
        public void CanCreateEmptyJSONFile()
        {
            Assert.DoesNotThrow(() =>
            {
                var jsonFile = CreateJSONFile("");
            });
        }

        [Test]
        public void CanCreateNewJSONFile()
        {
            Assert.DoesNotThrow(() =>
            {
                var jsonFile = CreateJSONFile(FullFilePath);
            });
        }

        [Test]
        public void CanCreatesNewJSONReader()
        {
            var jsonFile = CreateJSONFile(FullFilePath);
            var testDataKey = "Animals";
            var testDataIndex = 0;

            Assert.DoesNotThrow(() =>
            {
                var jsonReader = CreateJSONReader(jsonFile);
            });
        }

        [Test]
        public void CanReadJSONSingleProperty()
        {
            var jsonFile = new JSONFile(FullFilePath);
            var testDataKey = "SingleProperty";
            var expectedValue = "LeagueIsGreat";

            var jsonReader = CreateJSONReader(jsonFile);
            var testValue = jsonReader.ReadSinglePropertyFromJSONFile(testDataKey);


            Assert.AreEqual(testValue, expectedValue);
        }

        [Test]
        public void CanReadJSONArray()
        {
            var jsonFile = new JSONFile(FullFilePath);
            var testDataKey = "Array";
            var expectedValue = new List<string>(){
                "Caitlyn",
                "Quinn",
                "Jinx",
                "Kog'Maw"};

            var jsonReader = CreateJSONReader(jsonFile);
            var testValue = jsonReader.ReadJsonArray(testDataKey);

            Assert.AreEqual(testValue, expectedValue);
        }

        [Test]
        public void CanReadJSONObjectWithProperty()
        {
            var jsonFile = new JSONFile(FullFilePath);
            var jsonReader = new JSONReader(jsonFile);
            var testDataKey = "ObjectWithProperty";
            var expectedValue = new Dictionary<string, string>()
            {
                {
                    "UserName", "quinnisgreat"

                },

                {
                    "Password", "bestpassword"
                }
            };

            var testValue = jsonReader.ReadJsonObject(testDataKey);

            Assert.AreEqual(expectedValue, testValue);
        }

        [Test]
        public void CanReadJsonObjectArray()
        {
            var jsonFile = new JSONFile(FullFilePath);
            var jsonReader = new JSONReader(jsonFile);
            var objectKey = "ObjectWithAnArray";
            var arrayKey = "ObjectArray";
            var expectedValue = new List<string>()
            {
                "HealthPotion",
                "InfinityEdge"
            };

            var testValue = jsonReader.ReadJsonObjectArray(objectKey, arrayKey);


            Assert.AreEqual(expectedValue, testValue);
        }

        [Test]
        public void CanReadArrayOfObjects()
        {
            var jsonFile = new JSONFile(FullFilePath);
            var jsonReader = new JSONReader(jsonFile);
            var arrayKey = "ArrayOfObjects";

            var expectedValue = JArray.Parse(@"[{
            'Name': 'QuinnAndValor',
            'Kingdom': {
                'State': 'Demacia',
                'Street': '1 Eagle St',
                'ZipCode': '02903'
            }
        },{
            'Name': 'Caitlyn',
            'Kingdom': {
                'State': 'Piltover',
                'Street': '1 Police Way',
                'ZipCode': '02907'
            }
        }]
        ");

            var testValue = jsonReader.ReadArrayOfJsonObjects(arrayKey);

            Assert.IsTrue(JToken.DeepEquals(testValue, expectedValue));
        }

        [Test]
        public static void PassingNullJsonFileRaisesArgumentException()
        {
            Assert.Catch(typeof(ArgumentException), (() => new JSONReader(null)));
        }

        private static JSONReader CreateJSONReader(JSONFile jsonFile)
        {
            return new JSONReader(jsonFile);
        }

        private static JSONFile CreateJSONFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return new JSONFile();
            }
            else
            {
                return new JSONFile(filePath);
            }
        }
    }
}
