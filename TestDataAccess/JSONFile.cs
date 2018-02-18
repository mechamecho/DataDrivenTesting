using System;
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
                throw new ArgumentException($"File name can't be null '{name}' .");
            }

            if (path != null)
                FilePath = $"{path}{_name}";
            else
            {
                throw new ArgumentException($"File Path can't be null '{FilePath}' .");
            }

            if (!FilePathIsFullAndExists(FilePath))
                throw new FormatException($"File path is not in the correct format, or File doesn't exist '{FilePath}'.");

            //FilePathIsFullAndExists();
        }

        public JSONFile()
        {

        }

        public JSONFile(string fullPath)
        {
            if (fullPath != null && FilePathIsFullAndExists(fullPath))
                FilePath = fullPath;
            else
            {
                throw new FormatException($"File Path is not in the correct format or the File doesn't exist {fullPath} .");
            }

            //FilePathIsFullAndExists();
        }

        private bool FilePathIsFullAndExists(string fullPath)
        {
            if (Path.GetFullPath(fullPath) == fullPath &&
                Directory.Exists(GetFilePathWithoutFileName(fullPath)))
                return true;
            return false;
        }

        private string GetFilePathWithoutFileName(string fullPath)
        {
            return (Directory.GetParent(fullPath).ToString());
        }

    }
}
