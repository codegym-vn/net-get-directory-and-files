using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GetDirectories
{
    class SearchHandler
    {
        public static List<string> GetFiles(string path, string pattern)
        {
            try
            {
                var listFiles = new List<string>();
                DirectoryInfo directory = new DirectoryInfo(path);
                FileInfo[] Files = directory.GetFiles(pattern);
                foreach (FileInfo file in Files)
                {
                    listFiles.Add(file.Name);
                }
                return listFiles;
            }
            catch (UnauthorizedAccessException)
            {
                return new List<string>();
            }
        }

        public static List<string> GetDirectories(string path)
        {
            try
            {
                return Directory.GetDirectories(path).ToList();
            }
            catch (UnauthorizedAccessException)
            {
                return new List<string>();
            }
        }
    }
}
