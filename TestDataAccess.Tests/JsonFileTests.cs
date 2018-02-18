using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;

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
        public void CanReadJSONReader()
        {
            var jsonFile = new JSONFile(FullFilePath);
            var testDataKey = "Animals";
            var testDataIndex = 0;
            var expectedValue = "Dog";

            var jsonReader = CreateJSONReader(jsonFile);
            var testValue = jsonReader.GetJsonPropertyValue(testDataKey, testDataIndex);


            Assert.AreEqual(testValue, expectedValue);
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
