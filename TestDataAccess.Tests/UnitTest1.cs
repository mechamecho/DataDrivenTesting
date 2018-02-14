using NUnit.Framework;

namespace TestDataAccess.Tests
{
    [TestFixture]
    public class JsonFile
    {
        private const string RootDirectory = "//";
        private const string JsonFileName = "testData.json";
        private static readonly string FullFilePath = $"{RootDirectory}{JsonFileName}";

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
                var jsonReader = CreateJSONReader(jsonFile, testDataKey, testDataIndex);
            });
        }

        [TestCase]
        public void CanReadJSONReader()
        {
            var jsonFile = new JSONFile(FullFilePath);
            var testDataKey = "Animals";
            var testDataIndex = 0;

            var jsonReader = CreateJSONReader(jsonFile, testDataKey, testDataIndex);

            Assert.Equals(jsonReader, "Dog");
        }

        private static JSONReader CreateJSONReader(JSONFile jsonFile, string testDataKey, int testDataIndex)
        {
            return new JSONReader(jsonFile, testDataKey, testDataIndex);
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
