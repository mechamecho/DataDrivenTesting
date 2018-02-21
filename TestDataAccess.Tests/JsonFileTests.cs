using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace TestDataAccess.Tests
{
    [TestFixture]
    public class JsonFileTests
    {
        private static readonly string SolutionBinary = System.AppContext.BaseDirectory;
        private static readonly string SolutionName = "TestDataAccess.Tests";
        private static readonly string RootDirectory = SolutionBinary.Substring(0, SolutionBinary.IndexOf(SolutionName) + SolutionName.Length);

        private const string JsonFileName = "testData.json";
        private static readonly string FullFilePath = $"{RootDirectory}{Path.DirectorySeparatorChar}{JsonFileName}";

        [SetUp]
        public void CreateJSONFileAndJSONReader()
        {
            jsonFile = new JSONFile(FullFilePath);
            jsonReader = CreateJSONReader(jsonFile);
        }

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
            var testDataKey = "SingleProperty";
            var expectedValue = "LeagueIsGreat";
            var testValue = jsonReader.ReadSinglePropertyFromJSONFile(testDataKey);


            Assert.AreEqual(testValue, expectedValue);
        }

        [Test]
        public void CanReadJSONArray()
        {
            var testDataKey = "Array";
            var expectedValue = new List<string>(){
                "Caitlyn",
                "Quinn",
                "Jinx",
                "Kog'Maw"};

            var testValue = jsonReader.ReadJsonArray(testDataKey);

            Assert.AreEqual(testValue, expectedValue);
        }

        [Test]
        public void CanReadJSONObjectWithProperty()
        {
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

        [TearDown]
        public void Dispose()
        {
            jsonFile = null;
            jsonReader = null;
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
        private static JSONFile jsonFile;
        private static JSONReader jsonReader;
    }
}
