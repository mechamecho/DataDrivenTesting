using NUnit.Framework;
using System;
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

        [Test]
        public static void PassingIncorrectPathToJsonFileRaisesException()
        {
            var fakePath = "C://banananananan";
            Assert.Throws(typeof(FormatException), () => new JSONFile(fakePath));
        }

        [Test]
        public static void PassingFolderAndNameCorrectlyDoesNotThrow()
        {
            var fileName = JsonFileName;
            var folderPath = RootDirectory;

            Assert.DoesNotThrow((() => new JSONFile(folderPath, fileName)));
        }

        [Test]
        public static void PassingNullFolderRaisesException()
        {
            string fileName = JsonFileName;
            string folderPath = null;

            Assert.Throws(typeof(ArgumentException), (() => new JSONFile(folderPath, fileName)));
        }

        [Test]
        public static void PassingNullFileNameRaisesException()
        {
            string fileName = null;
            string folderPath = RootDirectory;

            Assert.Throws(typeof(ArgumentException), (() => new JSONFile(folderPath, fileName)));
        }
    }
}
