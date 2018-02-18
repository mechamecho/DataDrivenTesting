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

        [TestCase]
        public void CanCreateEmptyJSONFile()
        {
            Assert.DoesNotThrow(() =>
            {
                var jsonFile = CreateJSONFile("");
            });
        }

        [TestCase]
        public void CanCreateNewJSONFile()
        {
            Assert.DoesNotThrow(() =>
            {
                var jsonFile = CreateJSONFile(FullFilePath);
            });
        }

        [TestCase]
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

        [TestCase]
        public void CanReadJSONSingleProperty()
        {
            var jsonFile = new JSONFile(FullFilePath);
            var testDataKey = "SingleProperty";
            var expectedValue = "LeagueIsGreat";

            var jsonReader = CreateJSONReader(jsonFile);
            var testValue = jsonReader.ReadSinglePropertyFromJSONFile(testDataKey);


            Assert.AreEqual(testValue, expectedValue);
        }

        [TestCase]
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
