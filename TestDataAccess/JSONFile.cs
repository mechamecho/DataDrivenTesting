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
            if (!String.IsNullOrEmpty(name))
                _name = name;
            else
            {
                throw new ArgumentException($"File name can't be null or empty '{name}'.");
            }

            if (!String.IsNullOrEmpty(path))
                FilePath = $"{path}{_name}";
            else
            {
                throw new ArgumentException($"File Path can't be null or empty '{FilePath}'.");
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
            if (!String.IsNullOrEmpty(fullPath))
                if (FilePathIsFullAndExists(fullPath))
                {
                    FilePath = fullPath;
                }

                else
                {
                    throw new FormatException(
                        $"File Path is not in the correct format or the File doesn't exist {fullPath} .");
                }
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
