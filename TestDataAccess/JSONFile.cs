﻿using System;
using System.IO;

namespace TestDataAccess
{
    public class JSONFile
    {
        public string FilePath { get; set; }
        private readonly string _name;


        public JSONFile(string path, string name)
        {
            if (name != null)
                _name = name;
            else
            {
                throw new ArgumentException("File name can't be null");
            }

            if (path != null)
                FilePath = $"{path}{_name}";
            else
            {
                throw new ArgumentException("File Path can't be null");
            }

            if (!JSONFilePathValidation(FilePath))
                throw new FormatException("File path is not in the correct format, or File doesn't exist.");

            //JSONFilePathValidation();
        }

        public JSONFile()
        {

        }

        public JSONFile(string fullPath)
        {
            if (fullPath != null && JSONFilePathValidation(fullPath))
                FilePath = fullPath;
            else
            {
                throw new FormatException("File Path is not in the correct format or the File doesn't exist.");
            }

            //JSONFilePathValidation();
        }

        private bool JSONFilePathValidation(string fullPath)
        {
            string fileName = Path.GetFileName(fullPath);

            if (Path.GetFullPath(fullPath) == fullPath && Directory.Exists(fullPath.Replace(fileName, "")))
                return true;
            return false;
        }

        //private string JSONFilePathValidation()
        //{
        //    var qaDirectory = "QA Automation\\";
        //    var testDataDirectory = "TestData\\";

        //    return (_name.Contains(qaDirectory) ? "" : $"{qaDirectory}\\") +
        //            (_name.Contains("TestCases\\") ?
        //            "" : (_name.Contains("TestCase\\") ?
        //            "" : (_name.Contains(testDataDirectory) ? "" : testDataDirectory)));
        //}
    }
}
