using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDirectories
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Please input directory: ");
            string directory = Console.ReadLine();
            Console.WriteLine("\nResult:");

            if (Directory.Exists(directory))
                GetHierarchicalFolderList(directory, "*");
            else
                Console.WriteLine("Not Exist!");

            Console.ReadLine();
        }

        private static void GetHierarchicalFolderList(string path, string searchPattern = "*")
        {
            List<string> folders = SearchHandler.GetDirectories(path);
            string folder = string.Empty;
            foreach (var item in folders)
            {
                Console.WriteLine(item);
                folder = item;
                GetHierarchicalChildItems(ref folder, searchPattern, 1);
            }
        }

        private static void GetHierarchicalChildItems(ref string folder, string searchPattern, int level)
        {
            List<string> files = SearchHandler.GetFiles(folder, searchPattern);
            if (files.Count <= 0) return;

            var indent = string.Empty;
            var splash = string.Empty;
            for (var i = 0; i < level; i++)
            {
                indent += "---";
                splash += "|  ";
            }

            foreach (var file in files)
                Console.WriteLine(splash + indent + file);

            List<string> folders = SearchHandler.GetDirectories(folder);
            if (folders.Count > 0)
            {
                string subFolder = string.Empty;
                foreach (var item in folders)
                {
                    Console.WriteLine(splash + item);
                    subFolder = item;
                    GetHierarchicalChildItems(ref subFolder, searchPattern, level + 1);
                }
            }
        }
    }
}
